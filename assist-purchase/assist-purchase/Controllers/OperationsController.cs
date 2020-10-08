using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assist_purchase.Model;
using Microsoft.AspNetCore.Mvc;


namespace assist_purchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        static Model.IProductRepository _productModelRepository;
        public OperationsController(Model.IProductRepository productRepository)
        {
            _productModelRepository = productRepository;
        }
        // GET: api/<OperationsController>
        [HttpGet("allproducts")]
        public IEnumerable<Model.ProductModel> Get()
        {
            return _productModelRepository.GetAllProducts();
        }

        // POST api/<OperationsController>
        [HttpPost("add")]
        public void Post([FromBody] Model.ProductModel model)
        {
            _productModelRepository.AddProductModel(model);
        }

        // PUT api/<OperationsController>/5
        [HttpPut("update/{productId}")]
        public void Put(string productId, [FromBody] Model.ProductModel model)
        {
            _productModelRepository.UpdateProductModel(productId,model);
        }

        // DELETE api/<OperationsController>/5
        [HttpDelete("delete/{productId}")]
        public void Delete(string productId)
        {
            _productModelRepository.RemoveProductModel(productId);
        }
    }
}
