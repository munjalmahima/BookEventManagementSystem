using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface IBookingEnrollmentDAC : IDataAccessComponent
    {
        BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO);
        List<UserDTO> GetAllUsersOfAEvent(int EventId);
        List<EventDTO> GetAllEventsOfAUser(string Username);
    }
}
