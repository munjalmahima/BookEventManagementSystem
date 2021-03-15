using Nagarro.BookEventManagement.EntityDataModel;
using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Data
{
    public class BookingEnrollmentDAC:DACBase,IBookingEnrollmentDAC
    {
        public BookingEnrollmentDAC()
           : base(DACType.BookingEnrollmentDAC)
        {

        }

        public BookingEnrollmentDTO CreateBooking(int EventId,int UserId)
        {
            BookingEnrollmentDTO retVal = null;
            try
            {
                using (BookEventManagementEntities dbContext = new BookEventManagementEntities())
                {
                    Booking_Enrollment b = new Booking_Enrollment();
                    BookingEnrollmentDTO bookingDTO = new BookingEnrollmentDTO();
                    
                    bookingDTO.EventsId = EventId;
                    bookingDTO.UserId = UserId;

                    EntityConverter.FillEntityFromDTO(bookingDTO, b);

                    dbContext.Booking_Enrollment.Add(b);
                    dbContext.SaveChanges();

                    EntityConverter.FillDTOFromEntity(b, bookingDTO);
                    retVal = bookingDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
    }

        public List<EventDTO> GetEventsOfAUser(int UserId)
        {
            List<EventDTO> eventList = new List<EventDTO>();
            using (var context = new BookEventManagementEntities())
            {
                foreach (var e in context.Booking_Enrollment)
                {
                    if(e.UserId==UserId)
                    {
                        EventDTO eventDTO = new EventDTO();
                        EntityConverter.FillDTOFromEntity(e, eventDTO);
                        eventList.Add(eventDTO);
                    }
                       
                }
                return eventList;
            }
        }

        public List<UserDTO> GetUsersOfAEvent(int EventId)
        {
            List<UserDTO> userList = new List<UserDTO>();
            using (var context = new BookEventManagementEntities())
            {
                foreach (var u in context.Booking_Enrollment)
                {
                    if (u.EventsId == EventId)
                    {
                        UserDTO userDTO = new UserDTO();
                        EntityConverter.FillDTOFromEntity(u, userDTO);
                        userList.Add(userDTO);
                    }

                }
                return userList;
            }
        }
    }
}
