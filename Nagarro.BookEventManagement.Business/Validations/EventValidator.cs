using FluentValidation;
using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Business
{

    public class EventValidator : AbstractValidator<EventDTO>
    {
        public EventValidator()
        {
            RuleFor(dto => dto.Id).NotNull().NotEmpty();
            RuleFor(dto => dto.Title).NotNull().NotEmpty();
            RuleFor(dto => dto.Address).NotNull().NotEmpty();
            RuleFor(dto => dto.Duration).LessThan(5);

        }
    }

}
