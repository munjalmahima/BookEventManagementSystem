using FluentValidation.Results;
using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Business
{
    public static class ValidationExtensions
    {
        public static NagarroSampleValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<NagarroSampleValidationFailure> errors = new List<NagarroSampleValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new NagarroSampleValidationResult(errors);
        }

        public static NagarroSampleValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new NagarroSampleValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }

    }
}
