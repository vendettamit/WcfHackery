using System;
using System.Collections.Generic;
using WcfRestAuthentication.Model;
using WcfRestAuthentication.Services.Api.Endpoints.Product;

namespace WcfRestAuthentication.Services.Api
{
    public partial class ApiService : IProductService
    {
        public IEnumerable<Product> GetList(Guid categoryId, int pageIndex, int pageSize)
        {
            var category1 = Guid.NewGuid();
            var category2 = Guid.NewGuid();

            return new List<Product>
            {
                Product.Create("Product1", "First Product", category1),
                Product.Create("Product2", "Second Product", category1),
                Product.Create("Product3", "Third Product", category2)
            };
        }

        public Product Put(Product product)
        {
            throw new NotImplementedException();
        }

        Product IProductService.Get(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Product Post(Product product)
        {
            throw new NotImplementedException();
        }
    }
}