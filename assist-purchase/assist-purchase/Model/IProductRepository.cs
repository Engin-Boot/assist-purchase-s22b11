using System.Collections.Generic;

namespace assist_purchase.Model
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetAllProducts();
        void AddProductModel(ProductModel model);
        void UpdateProductModel(string productId, ProductModel newModel);
        void RemoveProductModel(string productId);
        ProductModel GetProductModelByProductId(string productId);
    }
}
