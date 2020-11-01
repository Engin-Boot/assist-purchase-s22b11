using RestSharp;
using assist_purchase.Model;


using Xunit;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

namespace assist_purchase.Test
{
    public class OperationsControllerIntegrationTest
    {
        private readonly RestClient _restClient;
        public IRestRequest _request;
        public JsonDeserializer _json;

        

        public OperationsControllerIntegrationTest()
        {
            _restClient = new RestClient("http://localhost:50664/api/Operations");
            _json = new JsonDeserializer();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            _request = new RestRequest("/allproducts",Method.GET);
            var response = _restClient.Execute(_request);
            var output = _json.Deserialize<IEnumerable<ProductModel>>(response);
            Assert.NotNull(output);
        }

        [Fact]
        public void Add_ValidProduct_ReturnsValidResponse()
        {
            _request = new RestRequest("/add",Method.POST);
            _request.RequestFormat = DataFormat.Json;
            _request.AddBody(new { ProductId = "010", ProductName = "Sam" });
            var response = _restClient.Execute(_request);
            Assert.Equal(201, (double)response.StatusCode);
        }

        [Fact]
        public void Add_InValidProduct_ReturnsInValidResponse()
        {
            _request = new RestRequest("/add", Method.POST);
            _request.RequestFormat = DataFormat.Json;
            _request.AddBody(new { ProductName = "Sam" });
            var response = _restClient.Execute(_request);
            Assert.Equal(400, (double)response.StatusCode);
        }
        
        
        [Fact]
        public void Remove_ExistingProductIdPassed_ReturnsOkResponse()
        {

            _request = new RestRequest("/delete/{productId}",Method.DELETE).AddUrlSegment("productId", "001");
            string productId = "001";
            _request.AddParameter("productId", productId,ParameterType.UrlSegment);
            var response = _restClient.Execute(_request);
            Assert.Equal(200, (double)response.StatusCode);
        }

        [Fact]
        public void Remove_NotExistingProductIdPassed_ReturnsNotFoundResponse()
        {
            _request = new RestRequest("/delete/{productId}", Method.DELETE).AddUrlSegment("productId", "011");
            string productId = "011";
            _request.AddParameter("productId", productId, ParameterType.UrlSegment);
            var response = _restClient.Execute(_request);
            Assert.Equal(404, (double)response.StatusCode);
        }

        [Fact]
        public void Update_ExistingProductIdPassed_ReturnsOkResponse()
        {
            _request = new RestRequest("/update/{productId}", Method.PUT).AddUrlSegment("productId", "002");
            string productId = "002";
            _request.RequestFormat = DataFormat.Json;
            _request.AddParameter("productId", productId, ParameterType.UrlSegment);
            _request.AddBody(new { ProductId = "002", ProductName = "Lion" });
            var response = _restClient.Execute(_request);
            Assert.Equal(200, (double)response.StatusCode);
        }

        [Fact]
        public void Update_NotExistingProductIdPassed_ReturnsNotFoundResponse()
        {
            _request = new RestRequest("/update/{productId}", Method.PUT).AddUrlSegment("productId", "012");
            string productId = "012";
            _request.RequestFormat = DataFormat.Json;
            _request.AddParameter("productId", productId, ParameterType.UrlSegment);
            _request.AddBody(new { ProductId = "002"});
            var response = _restClient.Execute(_request);
            Assert.Equal(404, (double)response.StatusCode);
        }

        [Fact]
        public void WhenProductIdExistsFileIsDisplayed()
        {
            _request = new RestRequest("/getpic/{productId}", Method.GET).AddUrlSegment("productId", "002");
            string productId = "002";
            _request.AddParameter("productId", productId, ParameterType.UrlSegment);
            var response = _restClient.Execute(_request);
            Assert.Equal(200, (double)response.StatusCode);

        }

        [Fact]
        public void WhenProductIdNotExistsFileIsNotDisplayed()
        {
            _request = new RestRequest("/getpic/{productId}", Method.GET).AddUrlSegment("productId", "012");
            string productId = "012";
            _request.AddParameter("productId", productId, ParameterType.UrlSegment);
            var response = _restClient.Execute(_request);
            Assert.Equal(400, (double)response.StatusCode);

        }






        public IProductRepository GetProductRepository()
        {
            return new ProductRepository();
        }

        public Controllers.OperationsController GetController(IProductRepository repository)
        {
            return new Controllers.OperationsController(GetProductRepository());
        }

        public ProductModel GetValidMockProductModel()
        {
            var mockModel = new ProductModel
            {
                ProductId = "010",
                ProductName = "Sam"
            };
            return mockModel;
        }

        public ProductModel GetInvalidMockProductModel()
        {
            var mockModel = new ProductModel
            {
                ProductId = "010"
            };
            return mockModel;
        }

        public MailSender GetValidMailInformation()
        {
            var mailsender = new MailSender
            {
                emailid = "mayankranjan2018@gmail.com",
                productId = "001"
            };
            return mailsender;
        }
    }
}
