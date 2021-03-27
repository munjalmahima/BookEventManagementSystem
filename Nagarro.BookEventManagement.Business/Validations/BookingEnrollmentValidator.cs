using Nagarro.BookEventManagement.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Business
{
    public class BookingEnrollmentValidator : AbstractValidator<BookingEnrollmentDTO>
    {
        public BookingEnrollmentValidator()
        {
            RuleFor(dto => dto.Id).NotNull().NotEmpty();
            RuleFor(dto => dto.EventsId).NotNull().NotEmpty();
            RuleFor(dto => dto.UserId).NotNull().NotEmpty();
        }
    }
}

