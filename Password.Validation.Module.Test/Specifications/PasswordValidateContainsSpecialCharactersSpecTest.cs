using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password.Validation.Module.Service.Specification;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class PasswordValidateContainsSpecialCharactersSpecTest
    {
        [TestMethod]
        public void PasswordValidateContainsSpecialCharactersSpecIsSuccess()
        {
            var request = "re5t6@!P0O9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsSpecialCharactersSpec().IsSatisfiedBy(password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordValidateContainsSpecialCharactersSpecIsFail()
        {
            var request = "rrtt5t6nwww9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsSpecialCharactersSpec().IsSatisfiedBy(password);

            Assert.IsFalse(result);
        }
    }
}
