using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class PasswordValueObjectTest
    {
        [TestMethod]
        public void PasswordValueObjectIsSuccess()
        {
            var request = new ValueObject.PasswordValueObject("ret56$P0O9");
            request.Verify(request.VerificationCode);
            Assert.IsTrue(request.Verified);
        }

        [TestMethod]
        public void PasswordValueObjectEmptyIsFail()
        {
            var request = new ValueObject.PasswordValueObject("");
            request.Verify(request.VerificationCode);
            Assert.IsFalse(request.Verified);
        }

        [TestMethod]
        public void PasswordValueObjectVerificationCodeIsFail()
        {
            var request = new ValueObject.PasswordValueObject("ret56$P0O9");
            request.Verify(Guid.NewGuid().ToString().ToUpper()[..8]);
            Assert.IsFalse(request.Verified);
        }

        [TestMethod]
        public void PasswordValueObjectVerificationCodeExpireDateIsFail()
        {
            var request = new ValueObject.PasswordValueObject("ret56$P0O9");
            request.SetVerificationCodeExpireDate(DateTime.Now.AddDays(-40));
            request.Verify(request.VerificationCode);

            Assert.IsFalse(request.Verified);
        }
    }
}
