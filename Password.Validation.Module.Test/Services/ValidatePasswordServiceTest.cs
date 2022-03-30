using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password.Validation.Module.Service;
using System.Threading.Tasks;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class ValidatePasswordServiceTest
    { 

        [TestMethod]
        public async Task ValidatePasswordServiceIsSuccess()
        {
            var password = new ValueObject.PasswordValueObject("ret56$P0O9");
            var service = new ValidatePasswordService();
            var result = await service.ExecuteAsync(password);                
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ValidatePasswordServiceCapitalLettersIsFail()
        {
            var password = new ValueObject.PasswordValueObject("ret56$09");
            var service = new ValidatePasswordService();
            var result = await service.ExecuteAsync(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task ValidatePasswordServiceSmallLettersIsFail()
        {
            var password = new ValueObject.PasswordValueObject("56$P0O9");
            var service = new ValidatePasswordService();
            var result = await service.ExecuteAsync(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task ValidatePasswordServiceNumbersIsFail()
        {
            var password = new ValueObject.PasswordValueObject("ret$PO");
            var service = new ValidatePasswordService();
            var result = await service.ExecuteAsync(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task ValidatePasswordServiceSpecialCharactersIsFail()
        {
            var password = new ValueObject.PasswordValueObject("ret56P0O9");
            var service = new ValidatePasswordService();
            var result = await service.ExecuteAsync(password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task ValidatePasswordServiceLengthIsFail()
        {
            var password = new ValueObject.PasswordValueObject("");
            var service = new ValidatePasswordService();
            var result = await service.ExecuteAsync(password);
            Assert.IsFalse(result);
        } 
    }
}
