using System;
using System.Collections.Generic;


namespace assist_purchase.Model
{
    public class ProductRepository : IProductRepository
    {
        static List<ProductModel> _productModelList;

        public ProductRepository()
        {

            _productModelList = new List<ProductModel>();
            _productModelList.Add(new ProductModel
            {
                ProductId = "001",
                ProductName = "Tom",

            });
            _productModelList.Add(new ProductModel
            {
                ProductId = "002",
                ProductName = "Jerry",

            });

        }

        public ProductModel GetProductModelByProductId(string productId)
        {
            try
            {
                var model = _productModelList.Find(model => model.ProductId == productId);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void AddProductModel(ProductModel model)
        {
            _productModelList.Add(model);
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
          
            return _productModelList;
        }

        public void RemoveProductModel(string productId)
        {
            ProductModel model = _productModelList.Find(model => model.ProductId == productId);
            _productModelList.Remove(model);
        }

        public bool CheckProductModel(string productId)
        {
           for(int i=0;i<_productModelList.Count;i++)
            {
                if(_productModelList[i].ProductId==productId)
                {
                    return true;
                }
            }
            return false;
        }


        public void UpdateProductModel(string productId, ProductModel newModel)
        {
            int index = _productModelList.FindIndex(model => model.ProductId == productId); 
            _productModelList.RemoveAt(index);
            _productModelList.Insert(index, newModel);
        }
    }
}
