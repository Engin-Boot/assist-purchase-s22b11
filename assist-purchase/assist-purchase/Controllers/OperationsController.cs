using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assist_purchase.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        static String ProductId = "";
        static List<String> Productpeak=new List<string>();
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
            if (model.ProductId != null && model.ProductName != null)
            {
                ProductId = model.ProductId;
                _productModelRepository.AddProductModel(model);
                return CreatedAtAction($"Post", StatusCode(200));

            }

            return BadRequest();
        }

        [HttpPost("addpic")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null) throw new Exception("File is null");
            if (file.Length == 0) throw new Exception("File is empty");

            if (FileUpload.CheckIfPicFile(file))
            {
                await FileUpload.WriteFile(file, ProductId);
            }
            else
            {
                return BadRequest(new { message = "wrong file extension" });
            }
            Productpeak.Add(ProductId);
            return CreatedAtAction($"Post", StatusCode(200));
        }

        [HttpGet("getpic/{productId}")]
        public IActionResult Get(string productId)
        {
            if (Productpeak.Contains(productId))
                {
                // FileStream stream= System.IO.File.Open(@"C:\\Users\\320090678\\assist-purchase-s22b11\\assist-purchase\\assist-purchase\\Upload\\files\\pic.jpg",FileMode.Open);   // You can use your own method over here.         
                return PhysicalFile(@"C:\\Users\\320090678\\assist-purchase-s22b11\\assist-purchase\\assist-purchase\\Upload\\files\\" + productId+".jpg", "image/jpg");
                }
             else if(_productModelRepository.CheckProductModel(productId))
             {
                return PhysicalFile(@"C:\\Users\\320090678\\assist-purchase-s22b11\\assist-purchase\\assist-purchase\\Upload\\files\\default.jpg", "image/jpg");
             }
            return BadRequest(new { message = "File Deleted" });


        }





        [HttpPost("sendemailsuccess")]
        public ActionResult Post([FromBody] Model.MailSender model)
        {
            try
            {
                Console.WriteLine(model.emailid+" "+model.productId);
                string[] productid = model.productId.Split(" ");
                OutlookMailHandler mail = new OutlookMailHandler();
                String subject = "Feedback Philips";
                String body = "Thank you for contacting us We will contact you soon for the respective product ";
                for (int i=0;i<productid.Length;i++)
                {
                    Console.WriteLine(productid[i]);
                    body+=productid[i];
                }
                if (mail.SendMail(model.emailid, subject, body).Equals("True"))
                {
                    return CreatedAtAction($"Post", StatusCode(200));
                }
                else
                {
                    return CreatedAtAction($"Post", mail.SendMail(model.emailid, subject, body));

                }

            }
            catch(Exception e)
            {
                return NotFound();
            }
        }


        // PUT api/<OperationsController>/5
        [HttpPut("update/{productId}")]
        public ActionResult Put(string productId, [FromBody] Model.ProductModel model)
        {
            try
            {
                var model1 = _productModelRepository.GetProductModelByProductId(productId);
                if (model1 == null)
                    throw new Exception();

                _productModelRepository.UpdateProductModel(productId, model);
                return Ok();
            }
            catch(Exception e)
            {
                 return NotFound();
            }
            

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
                Productpeak.Remove(productId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }
    }
}
