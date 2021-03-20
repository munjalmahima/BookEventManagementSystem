using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Business
{
    public class BookingEnrollmentBDC : BDCBase,IBookingEnrollmentBDC
    {
        private readonly IDACFactory dacFactory;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public BookingEnrollmentBDC()
            : base(BDCType.BookingEnrollmentBDC)
        {
            dacFactory = DACFactory.Instance;
        }

        public BookingEnrollmentBDC(IDACFactory dacFactory)
            : base(BDCType.BookingEnrollmentBDC)
        {
            this.dacFactory = dacFactory;
        }

        public BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO)
        {
            IBookingEnrollmentDAC bookingDAC = (IBookingEnrollmentDAC)dacFactory.Create(DACType.BookingEnrollmentDAC);
            return bookingDAC.CreateBooking(bookingEnrollmentDTO);
        }
        #endregion



        

        public List<EventDTO> GetAllEventsOfAUser(int UserId)
        {
            IBookingEnrollmentDAC bookingDAC = (IBookingEnrollmentDAC)dacFactory.Create(DACType.BookingEnrollmentDAC);
            return bookingDAC.GetAllEventsOfAUser(UserId);
        }

        public List<UserDTO> GetAllUsersOfAEvent(int EventId)
        {
            IBookingEnrollmentDAC bookingDAC = (IBookingEnrollmentDAC)dacFactory.Create(DACType.BookingEnrollmentDAC);
            return bookingDAC.GetAllUsersOfAEvent(EventId);
        }
        
    }
}
