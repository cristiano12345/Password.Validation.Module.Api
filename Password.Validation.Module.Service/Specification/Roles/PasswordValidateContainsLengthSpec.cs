using NetDevPack.Specification;
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Service.Specification
{
    public class PasswordValidateContainsLengthSpec : Specification<ValueObject.PasswordValueObject>
    {
        public override Expression<Func<ValueObject.PasswordValueObject, bool>> ToExpression()
        {
           return password => Regex.IsMatch(password.Value, "[\\w\\W\\d]{9,}$");
        }
    }
}
