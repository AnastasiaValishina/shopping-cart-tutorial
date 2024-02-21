using Microsoft.AspNetCore.SignalR;

namespace ShopOnline.Api.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
