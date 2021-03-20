using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nagarro.BookEventManagement.Shared;

namespace Nagarro.BookEventManagement.Business
{
    public class CommentValidator : AbstractValidator<CommentDTO>
    {
        public CommentValidator()
        {
            RuleFor(dto => dto.Id).NotNull().NotEmpty();
            RuleFor(dto => dto.Comment1).NotNull().NotEmpty();
        }
    }
}
