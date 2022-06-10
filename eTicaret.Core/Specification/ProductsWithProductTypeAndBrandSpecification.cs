using eTicaret.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTicaret.Core.Specification
{
    public class ProductsWithProductTypeAndBrandSpecification:BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
        public ProductsWithProductTypeAndBrandSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
