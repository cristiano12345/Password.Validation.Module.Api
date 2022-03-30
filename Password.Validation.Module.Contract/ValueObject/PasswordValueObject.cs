using System;

namespace Password.Validation.Module.Contracts.ValueObject
{
    public class PasswordValueObject
    {
        public PasswordValueObject(string value)
        { 
            Value = value.Trim();

            if (string.IsNullOrEmpty(Value))
                return;

            Verified = false;
            VerificationCode = GenerateVerificationCode();
            VerificationCodeExpireDate = DateTime.UtcNow.AddHours(2);
        }

        public string Value { get; } = string.Empty;
        public bool Verified { get; private set; }
        public string VerificationCode { get; private set; } = string.Empty;
        public DateTime VerificationCodeExpireDate { get; private set; } = DateTime.UtcNow.AddHours(2);

        public void Verify(string verificationCode)
        {
            if (string.IsNullOrEmpty(this.Value))
                return;

            if (verificationCode != VerificationCode)
                return;

            if (DateTime.UtcNow > VerificationCodeExpireDate)
                return;

            Verified = true;
        }

        public void GenerateNewVerificationCode()
        {
            Verified = false;
            VerificationCode = GenerateVerificationCode();
            VerificationCodeExpireDate = DateTime.UtcNow.AddHours(8);
        }

        public void Expire() => Verified = false;

        private static string GenerateVerificationCode() => Guid.NewGuid().ToString().ToUpper()[..8];      

        public override string ToString() => Value;

        public void SetVerificationCodeExpireDate(DateTime date)
        {
            VerificationCodeExpireDate = date;
        }
    }
}
