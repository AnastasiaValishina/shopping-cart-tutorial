﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();
                var productCategories = await _productRepository.GetCategories();

                if (products == null || productCategories == null) 
                { 
                    return NotFound(); 
                }
                else
                {
                    var productDtos = products.ConvertToDto(productCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ProductDto>> GetItem(int id)
		{
			try
			{
				var product = await _productRepository.GetItem(id);

				if (product == null)
				{
					return BadRequest();
				}
				else
				{
                    var productCategory = await _productRepository.GetCategory(product.CategoryId);
                    var productDto = product.ConvertToDto(productCategory);

					return Ok(productDto);
				}
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database.");
			}
		}

        [HttpGet]
        [Route(nameof(GetProductCategories))]
        public async Task<ActionResult<IEnumerable<ProductCategoryDto>>> GetProductCategories()
        {
            try
            {
                var productCategories = await _productRepository.GetCategories();
                var productCategoriesDto = productCategories.ConvertToDto();

                return Ok(productCategoriesDto);
            }
            catch (Exception ex)
            {
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database.");
			}
        }

        [HttpGet]
		[Route("{categoryId}/GetItemsByCategory")]
		public async Task<ActionResult<IEnumerable<ProductDto>>> GetItemsByCategory(int categoryId)
        {
            try
            {
                var products = await _productRepository.GetItemsByCategory(categoryId);
                var productCategories = await _productRepository.GetCategories();
                var productDtos = products.ConvertToDto(productCategories);

                return Ok(productDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database.");
            }
        }
	}
}
