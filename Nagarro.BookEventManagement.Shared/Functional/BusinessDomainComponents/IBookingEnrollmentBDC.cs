using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface IBookingEnrollmentBDC : IBusinessDomainComponent
    {
        BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO);
        List<UserDTO> GetAllUsersOfAEvent(int EventId);
        List<EventDTO> GetAllEventsOfAUser(int UserId);
    }
}
