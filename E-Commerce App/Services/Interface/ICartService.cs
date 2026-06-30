using E_Commerce_App.DTOs.CartDTO;

namespace E_Commerce_App.Services.Interface
{
    public interface ICartService
    {
        public GetCartDTO GetCart();
        public void AddToCart(CartitemsDTO dto);
        public void RemoveFromCart();///
        public void UpdateQuantity(UpdateQuantityDTO dto);

        //CartService
        // |
        // |-- GetCart
        // |-- AddToCart
        // |-- RemoveFromCart
        // |-- UpdateQuantity

    }
}
