using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password.Validation.Module.Api.Controllers;
using Password.Validation.Module.Api.Models.Request;
using Password.Validation.Module.Application.Handlers;
using Password.Validation.Module.Contracts.Command;
using Password.Validation.Module.Contracts.Command.Contract;
using System.Threading.Tasks;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Controller
{
    [TestClass]
    public class ValidatePasswordControllerTest : GenericTestBase
    {
        public ValidatePasswordControllerTest() : base() {
          
        }

        [TestMethod]
        public async Task ValidatePasswordIsValidReturnTrue()
        {                    

            Mock<IValidatePasswordService> service = new();
            service
                .Setup(_ => _.ExecuteAsync(It.IsAny<ValueObject.PasswordValueObject>()))
                .ReturnsAsync((true));

            var handler = new ValidateHandler(service.Object); 
            PasswordController controller = new PasswordController(handler);

            var request = new ValidateRequest();
            request.Password = "re5t6.P0O9";            

            IActionResult endpointResponse = await controller.ValidatePassword(request);

            Assert.IsNotNull(endpointResponse);
            var contentResult = ((OkObjectResult)endpointResponse).Value;
            var result = (GenericCommandResult)contentResult;
            Assert.IsTrue(result.Password);
        }

        [TestMethod]
        public async Task ValidatePasswordIsEmptyReturnFalse()
        {
            Mock<IValidatePasswordService> service = new();
            service
                .Setup(_ => _.ExecuteAsync(It.IsAny<ValueObject.PasswordValueObject>()))
                .ReturnsAsync((false));

            var handler = new ValidateHandler(service.Object);
            PasswordController controller = new PasswordController(handler);

            var request = new ValidateRequest();
            request.Password = "";

            IActionResult endpointResponse = await controller.ValidatePassword(request);

            Assert.IsNotNull(endpointResponse);
            var contentResult = ((OkObjectResult)endpointResponse).Value;
            var result = (GenericCommandResult)contentResult;
            Assert.IsFalse(result.Password);
        }

        [TestMethod]
        public async Task ValidatePasswordIsIncorrectFormatReturnFalse()
        {
            Mock<IValidatePasswordService> service = new();
            service
                .Setup(_ => _.ExecuteAsync(It.IsAny<ValueObject.PasswordValueObject>()))
                .ReturnsAsync((false));

            var handler = new ValidateHandler(service.Object);
            PasswordController controller = new PasswordController(handler);

            var request = new ValidateRequest();
            request.Password = "rr";

            IActionResult endpointResponse = await controller.ValidatePassword(request);

            Assert.IsNotNull(endpointResponse);
            var contentResult = ((OkObjectResult)endpointResponse).Value;
            var result = (GenericCommandResult)contentResult;
            Assert.IsFalse(result.Password);
        }

    }
}
