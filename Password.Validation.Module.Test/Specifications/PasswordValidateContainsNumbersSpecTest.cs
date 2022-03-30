using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password.Validation.Module.Service.Specification;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class PasswordValidateContainsNumbersSpecTest
    {
        [TestMethod]
        public void PasswordValidateContainsNumbersSpecIsSuccess()
        {
            var request = "re5t6.P0O9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsCapitalLettersSpec().IsSatisfiedBy(password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordValidateContainsNumbersSpecIsFail()
        {
            var request = "rrttt\nwww";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsCapitalLettersSpec().IsSatisfiedBy(password);

            Assert.IsFalse(result);
        }
    }
}
