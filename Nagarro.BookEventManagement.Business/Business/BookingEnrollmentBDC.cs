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
        #endregion

        public BookingEnrollmentDTO CreateBooking(int EventId, int UserId)
        {
            throw new NotImplementedException();
        }

       

        public List<EventDTO> GetEventsOfAUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> GetUsersOfAEvent(int EventId)
        {
            throw new NotImplementedException();
        }
    }
}
