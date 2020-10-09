using System;
using System.Collections.Generic;
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
        public ActionResult Post([FromBody] Model.ProductModel model)
        {
            if (model.ProductId!=null && model.ProductName!=null)
            {
                _productModelRepository.AddProductModel(model);
                return CreatedAtAction($"Post", StatusCode(200));
                ;
            }

            return BadRequest();
        }

        // PUT api/<OperationsController>/5
        [HttpPut("update/{productId}")]
        public void Put(string productId, [FromBody] Model.ProductModel model)
        {
            _productModelRepository.UpdateProductModel(productId,model);
        }

        // DELETE api/<OperationsController>/5
        [HttpDelete("delete/{productId}")]
        public ActionResult Delete(string productId)
        {
            try
            {
                var model = _productModelRepository.GetProductModelByProductId(productId);
                if (model == null)
                    throw new Exception();
                _productModelRepository.RemoveProductModel(productId);
                return Ok();
            }
            catch(Exception e)
            {
                return NotFound();
            }


        }
    }
}
