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

        public BookingEnrollmentDTO CreateBooking(int EventId, int UserId)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.CreateBooking(EventId,UserId);
        }

        public List<EventDTO> GetEventsOfAUser(int UserId)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.GetEventsOfAUser(UserId);
        }

        public List<UserDTO> GetUsersOfAEvent(int EventId)
        {
            IBookingEnrollmentBDC bookingBDC = (IBookingEnrollmentBDC)BDCFactory.Instance.Create(BDCType.BookingEnrollmentBDC);
            return bookingBDC.GetUsersOfAEvent(EventId);
        }
    }
}
