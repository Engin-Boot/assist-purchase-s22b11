using assist_purchase.Model;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace assist_purchase.Test
{
    public class OperationsControllerTest
    {
        public IProductRepository GetMockProductRepository()
        {
            return new ProductRepository();
        }

        public Controllers.OperationsController GetMockController(IProductRepository repository)
        {
            return new Controllers.OperationsController(GetMockProductRepository());
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
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var repository = GetMockProductRepository();
            var controller = GetMockController(repository);
            var response = controller.Get();
            Assert.Equal(response, repository.GetAllProducts());

        }

        [Fact]
        public void Add_ValidProduct_ReturnsValidResponse()
        {
            var repository = GetMockProductRepository();
            var controller = GetMockController(repository);
            var response = controller.Post(GetValidMockProductModel());
            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var repository = GetMockProductRepository();
            var controller = GetMockController(repository);
            var badResponse = controller.Post(GetInvalidMockProductModel());
            Assert.IsType<BadRequestResult>(badResponse);
        }
        [Fact]
        public void Remove_NotExistingProductIdPassed_ReturnsNotFoundResponse()
        {
            var repository = GetMockProductRepository();
            var controller = GetMockController(repository);
            var notExistingProductId = "040";
            var badResponse = controller.Delete(notExistingProductId);
            Assert.IsType<NotFoundResult>(badResponse);
        }
    }
}
