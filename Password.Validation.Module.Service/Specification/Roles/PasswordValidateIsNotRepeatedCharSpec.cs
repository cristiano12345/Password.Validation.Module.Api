using NetDevPack.Specification;
using System;
using System.Linq;
using System.Linq.Expressions;
using ValueObject = Password.Validation.Module.Contracts.ValueObject;

namespace Password.Validation.Module.Service.Specification
{
    public class PasswordValidateIsNotRepeatedCharSpec : Specification<ValueObject.PasswordValueObject>
    {
        public override Expression<Func<ValueObject.PasswordValueObject, bool>> ToExpression()
        {
           return password => !password.Value
                    .ToCharArray()
                    .ToList()
                    .GroupBy(g => g)
                    .Select(s => new { Character = s.Key, Count = s.Count() })
                    .Where(x => x.Count > 1)
                    .Any();           
        }
    }
}
