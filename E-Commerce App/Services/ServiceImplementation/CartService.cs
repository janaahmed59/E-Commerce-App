using E_Commerce_App.DTOs;
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
        public void AddToCart(int userid ,AddToCartDTO dto)
        {
            // cart, cart item 

            var cartRepo = _unit.Repository<Cart>();
            var cartitemRepo = _unit.Repository<CartItem>();
            var cart = cartRepo.GetAll().FirstOrDefault(c => c.UserId == userid); // get cart of user (انهي يوزر صاحب الكارت دا)
            var cartitem = cartitemRepo.GetAll().FirstOrDefault(c => c.CartId == cart.Id && c.ProductId == dto.ProductId);
            // get the items in this cart and the product that  i have added to it and check if it exist in cart or not
            if(cart == null) // create new cart for this user if he doesnot have one
            {
                var NewCart = new Cart
                {
                    UserId = userid
                };
                cartRepo.Create(NewCart);
            }
            if (cartitem == null)
            {
                var newitem = new CartItem
                {
                    CartId = cart.Id,
                    Quantity = dto.Quantity,
                    ProductId = dto.ProductId
                };
                cartitemRepo.Create(newitem);
            }
            if(cartitem != null)
            {
                cartitem.Quantity += dto.Quantity;
                cartitem.ProductId = dto.ProductId;
                cartitemRepo.Update(cartitem);
            }
            _unit.Save();
        }
        public void RemoveFromCart(int userid, RemoveFromCartDTO dto )
        {
            var itemRepo = _unit.Repository<CartItem>();
            var item = itemRepo.GetAll().FirstOrDefault(i => i.Id == dto.CartItemId && i.Cart.UserId == userid);
            if(item != null)
            {
                itemRepo.Delete(item);
                _unit.Save();
            }
            else throw new Exception("Item not found in cart");
        }
        public void UpdateQuantity(int userid, UpdateQuantityDTO dto)
        {
            var itemRepo = _unit.Repository<CartItem>();
            var item = itemRepo.GetAll().FirstOrDefault(i => i.Id == dto.CartItemId && i.Cart.UserId == userid);
            if (item != null)
            {
                item.Quantity = dto.NewQuantity;
                itemRepo.Update(item);
                _unit.Save();
            }
            else throw new Exception("Item not found in cart");
        }

    }
}
