using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Components.Pages
{
	public class ProductDetailsBase : ComponentBase
	{
		[Parameter]
		public int Id { get; set; }

		[Inject]
		public IProductService ProductService { get; set; }
		public ProductDto Product { get; set; }
		public string ErrorMessage { get; set; } 

		protected override async Task OnInitializedAsync()
		{
			try
			{
				Console.WriteLine("1 " + Product);
				Product = await ProductService.GetItem(Id);
				Console.WriteLine("1 " + Product);
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}
	}
}
