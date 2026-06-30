using E_Commerce_App.DTOs.ProductDTO;
using E_Commerce_App.Models;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.UnitOfWorkLayer.Interface;
using System.Linq.Expressions;

namespace E_Commerce_App.Services.ServiceImplementation
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unit;
        public ProductService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public GetProduct GetById(int id)
        {
            var product = _unit.Repository<Product>().GetById(id);
            if (product == null)
                return null;

            return new GetProduct // because we return a Dto so we must map it
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Stock = product.Stock,
                CategoryName = product.Category != null ? product.Category.Name : null
            };
        }
        public void CreateProduct(CreateProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };
            var repo = _unit.Repository<Product>();
            repo.Create(product);
            _unit.Save();

        } // Admin
        public void UpdatePrice(int id ,UpdatePriceDTO dto)
        {
            var product = _unit.Repository<Product>().GetById(id);
            if(product != null)
            {
                product.Price = dto.NewPrice;
                _unit.Repository<Product>().Update(product);
                _unit.Save();
            }
        } // Admin
        public void UpdateDescription(int id, UpdateDescriptionDTO dto)
        {
            var product = _unit.Repository<Product>().GetById(id);
            if (product != null)
            {
                product.Description = dto.NewDescription;
                _unit.Repository<Product>().Update(product);
                _unit.Save();
            }
        } // Admin

        public void DeleteProduct(int id)
        {
            var product = _unit.Repository<Product>().GetById(id);
            if (product != null)
            {
                _unit.Repository<Product>().Delete(product);
                _unit.Save();
            }
        } // Admin
        public GetProduct SearchForProduct(string name)
        {
            var product = _unit.Repository<Product>();
            var list = product.GetAll().Where(x => x.Name.Contains(name))
                .Select(g => new GetProduct
                {
                   Name = g.Name,
                   Price = g.Price,
                   Description = g.Description,
                   Stock = g.Stock,
                   CategoryName = g.Category.Name
                }).FirstOrDefault();
            if(list != null) return list;
            else return null;
        }
        //public GetProduct FilterByCategory(int id);
    }
}
