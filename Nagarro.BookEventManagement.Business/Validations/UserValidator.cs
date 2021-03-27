using Nagarro.BookEventManagement.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Business
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(dto => dto.Id).NotNull().NotEmpty();
            RuleFor(dto => dto.Email).NotNull().NotEmpty();
            RuleFor(dto => dto.Name).NotNull().NotEmpty();
            RuleFor(dto => dto.Password).NotNull().NotEmpty();

        }
    }
}
