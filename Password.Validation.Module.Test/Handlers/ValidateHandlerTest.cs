using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Password.Validation.Module.Application.Handlers;
using Password.Validation.Module.Contracts.Command;
using Password.Validation.Module.Contracts.Command.Contract;
using System.Threading.Tasks;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class ValidateHandlerTest
    {   

        [TestMethod]
        public async Task ValidateHandlerIsSuccess()
        {
            var command = new ValidateCommand("re5t6.P0O9");

            Mock<IValidatePasswordService> service = new();
            service
                .Setup(_ => _.ExecuteAsync(It.IsAny<ValueObject.PasswordValueObject>()))
                .ReturnsAsync((true));

            var handler = new ValidateHandler(service.Object);

            var result = await handler.ExecuteAsync(command);
            var genericCommandResult = (GenericCommandResult)result;
            Assert.IsTrue(genericCommandResult.Password);

        }

        [TestMethod]
        public async Task ValidateHandlerEmptyIsFail()
        {
            var command = new ValidateCommand("");

            Mock<IValidatePasswordService> service = new();
            service
                .Setup(_ => _.ExecuteAsync(It.IsAny<ValueObject.PasswordValueObject>()))
                .ReturnsAsync((true));

            var handler = new ValidateHandler(service.Object);
            var result = await handler.ExecuteAsync(command);

            var genericCommandResult = (GenericCommandResult)result;
            Assert.IsFalse(genericCommandResult.Password);
        }

        [TestMethod]
        public async Task ValidateHandlerIsFail()
        {
            var command = new ValidateCommand("YYYYYY");

            Mock<IValidatePasswordService> service = new();
            service
                .Setup(_ => _.ExecuteAsync(It.IsAny<ValueObject.PasswordValueObject>()))
                .ReturnsAsync((false));

            var handler = new ValidateHandler(service.Object);
            var result = await handler.ExecuteAsync(command);

            var genericCommandResult = (GenericCommandResult)result;
            Assert.IsFalse(genericCommandResult.Password);
        }
    }
}
