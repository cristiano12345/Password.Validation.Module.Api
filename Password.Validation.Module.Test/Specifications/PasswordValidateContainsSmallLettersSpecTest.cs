using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password.Validation.Module.Service.Specification;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class PasswordValidateContainsSmallLettersSpecTest
    {
        [TestMethod]
        public void PasswordValidateContainsSmallLettersIsSuccess()
        {
            var request = "re5t6.P0O9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsSmallLettersSpec().IsSatisfiedBy(password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordValidateContainsSmallLettersIsFail()
        {
            var request = "5T7*NWER9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsSmallLettersSpec().IsSatisfiedBy(password);

            Assert.IsFalse(result);
        }
    }
}
