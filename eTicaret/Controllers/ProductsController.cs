﻿
using eTicaret.Core.DbModels;
using eTicaret.Core.Interfaces;
using eTicaret.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTicaret.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //private readonly StoreContext _context;
        //private readonly IProductRepository _productRepository;

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;

        public ProductsController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
        }



        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await _productRepository.ListAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetByIdAsync(id);

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
