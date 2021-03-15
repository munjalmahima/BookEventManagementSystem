using FluentValidation;
using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Business
{
    public static class Validator<T, T1> where T : AbstractValidator<T1>, new()
    {
        public static NagarroSampleValidationResult Validate(T1 dto)
        {
            T validator = new T();
            return validator.Validate(dto).ToValidationResult();
        }

        public static NagarroSampleValidationResult Validate(T1 dto, string ruleSet)
        {
            T validator = new T();
            //return validator.Validate(dto, ruleSet: ruleSet).ToValidationResult();
            return validator.Validate(dto, options => options.IncludeRuleSets(ruleSet, ruleSet)).ToValidationResult();
            
        }
    }
}
