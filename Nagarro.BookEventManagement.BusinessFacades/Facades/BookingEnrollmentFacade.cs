using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.BusinessFacades
{
    public class BookingEnrollmentFacade : FacadeBase,IBookingEnrollmentFacade
    {
        public BookingEnrollmentFacade()
            : base(FacadeType.BookingEnrollment)
        {

        }

        public BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.CreateBooking(bookingEnrollmentDTO);
        }

        
        public List<EventDTO> GetAllEventsOfAUser(string Username)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.GetAllEventsOfAUser(Username);
        }

        public List<UserDTO> GetAllUsersOfAEvent(int EventId)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.GetAllUsersOfAEvent(EventId);
        }
        
    }
}
