using E_Commerce_App.DTOs;
using E_Commerce_App.DTOs.CartDTO;

namespace E_Commerce_App.Services.Interface
{
    public interface ICartService
    {
        public GetCartDTO GetCart();
        public void AddToCart(int userid, AddToCartDTO dto);
        public void RemoveFromCart(int userid, RemoveFromCartDTO dto);///
        public void UpdateQuantity(int userid, UpdateQuantityDTO dto);

        //CartService
        // |
        // |-- GetCart
        // |-- AddToCart
        // |-- RemoveFromCart
        // |-- UpdateQuantity

    }
}
