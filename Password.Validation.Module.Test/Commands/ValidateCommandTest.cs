using Microsoft.VisualStudio.TestTools.UnitTesting;
using Password.Validation.Module.Contracts.Command;

namespace Password.Validation.Module.Test.Specifications
{
    [TestClass]
    public class ValidateCommandTest
    {
        [TestMethod]
        public void ValidateCommandIsSuccess()
        {
            var request = "rrtt5t6\nwww9";
            var command = new ValidateCommand(request);

            Assert.IsTrue(command.IsValid);
        }

        [TestMethod]
        public void ValidateCommandIsPasswordEmptyIsFail()
        {
            var request = "";
            var command = new ValidateCommand(request);

            Assert.IsFalse(command.IsValid);
        }      


        //SetVerificationCode
    }
}
