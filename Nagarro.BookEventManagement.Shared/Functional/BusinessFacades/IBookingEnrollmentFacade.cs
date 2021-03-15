using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface IBookingEnrollmentFacade
    {
        BookingEnrollmentDTO CreateBooking(int EventId, int UserId);
        List<UserDTO> GetUsersOfAEvent(int EventId);
        List<EventDTO> GetEventsOfAUser(int UserId);
    }
}
