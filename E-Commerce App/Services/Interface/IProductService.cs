using E_Commerce_App.DTOs.ProductDTO;
using E_Commerce_App.Migrations;
using E_Commerce_App.Models;

namespace E_Commerce_App.Services.Interface
{
    public interface IProductService
    {
        public GetProduct GetById(int id);
        public void CreateProduct(CreateProductDTO dto);
        public void UpdatePrice(int id, UpdatePriceDTO dto); // Admin
        public void UpdateDescription(int id, UpdateDescriptionDTO dto);
        public void DeleteProduct(int id); // Admin
        public GetProduct SearchForProduct(string name);
        //public GetProduct FilterByCategory(int id);
        
    }
}
//GetAllProducts
        // |-- GetProductById
        // |-- CreateProduct
        // |-- UpdateProduct
        // |-- DeleteProduct
        // |-- SearchProducts
        // |-- FilterByCategory