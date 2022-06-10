
using AutoMapper;
using eTicaret.Core.DbModels;
using eTicaret.Core.Interfaces;
using eTicaret.Core.Specification;
using eTicaret.Dtos;
using eTicaret.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicaret.Controllers
{
   
    public class ProductsController : BaseApiController
    {
        //private readonly StoreContext _context;
        //private readonly IProductRepository _productRepository;

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification();
            var data = await _productRepository.ListAsync(spec);
            // return Ok(data);

            //return data.Select(p => new ProductToReturnDto
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Description = p.Description,
            //    PictureUrl = p.PictureUrl,
            //    Price = p.Price,
            //    ProductBrand = p.ProductBrand.Name != null ? p.ProductBrand.Name : string.Empty,
            //    ProductType = p.ProductType.Name != null ? p.ProductType.Name : string.Empty
            //}).ToList();

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(id);

           // return await _productRepository.GetEntityWithSpec(spec);
           var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }


    }
}
