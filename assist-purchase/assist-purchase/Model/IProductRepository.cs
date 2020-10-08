using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assist_purchase.Model
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        void AddProductModel(ProductModel model);
        void UpdateProductModel(string productId, ProductModel newModel);
        void RemoveProductModel(string productId);
    }
}
