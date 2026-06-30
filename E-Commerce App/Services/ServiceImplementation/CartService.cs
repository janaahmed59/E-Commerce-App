using E_Commerce_App.DTOs.CartDTO;
using E_Commerce_App.DTOs.ProductDTO;
using E_Commerce_App.Models;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer.Interface;

namespace E_Commerce_App.Services.ServiceImplementation
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unit;
        public CartService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public GetCartDTO GetCart() 
        { 
            var repo = _unit.Repository<Cart>();
            var cart = repo.GetAll().Select(c => new GetCartDTO
            {
                Items = c.CartItems.Select(item => new CartitemsDTO
                {
                    productName = item.Product.Name,
                    Quantity = item.Quantity,
                }).ToList()
            }).FirstOrDefault();

            /*
                return List<GetCartDTO> 
                var cart = repo.GetAll().SelectMAny(c => c.CartItems)
                                .Select(items => new GetCartDTO
                                {
                                    productName = item.Product.Name,
                                    Quantity = item.Quantity
                                }).ToList();
                return cart;
            */
            return cart;
        }
        public void AddToCart(CartitemsDTO dto)
        {

        }
        public void RemoveFromCart()
        {

        }
        public void UpdateQuantity(UpdateQuantityDTO dto)
        {

        }

    }
}
