using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password.Validation.Module.Service.Specification;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class PasswordValidateContainsLengthSpecTest
    {
        [TestMethod]
        public void PasswordValidateContainsLengthSpecIsSuccess()
        {
            var request = "re5t6.P0O9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsLengthSpec().IsSatisfiedBy(password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordValidateContainsLengthSpecIsFail()
        {
            var request = "";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateContainsCapitalLettersSpec().IsSatisfiedBy(password);

            Assert.IsFalse(result);
        }
    }
}
