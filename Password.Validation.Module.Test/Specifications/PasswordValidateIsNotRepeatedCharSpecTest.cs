using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password.Validation.Module.Service.Specification;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class PasswordValidateIsNotRepeatedCharSpecTest
    {
        [TestMethod]
        public void PasswordValidateIsNotRepeatedCharSpecIsSuccess()
        {
            var request = "re5t6.P0O9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateIsNotRepeatedCharSpec().IsSatisfiedBy(password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordValidateContainsNotSpaceIsFail()
        {
            var request = "rrtt5t6\nP0O9";
            var password = new ValueObject.PasswordValueObject(request);
            var result = new PasswordValidateIsNotRepeatedCharSpec().IsSatisfiedBy(password);

            Assert.IsFalse(result);
        }
    }
}
