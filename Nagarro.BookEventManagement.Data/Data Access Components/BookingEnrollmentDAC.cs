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

        public BookingEnrollmentDTO CreateBooking(BookingEnrollmentDTO bookingEnrollmentDTO)
        {
            BookingEnrollmentDTO retVal = null;
            try
            {
                using (BookEventManagementEntities dbContext = new BookEventManagementEntities())
                {
                    Booking_Enrollment bookingEnrollment = new Booking_Enrollment();
                    EntityConverter.FillEntityFromDTO(bookingEnrollmentDTO, bookingEnrollment);

                    bool flag = false;
                    foreach (var booking in dbContext.Booking_Enrollment)
                    {
                        if ((booking.EventsId == bookingEnrollmentDTO.EventsId) &&
                            (booking.UserId == bookingEnrollmentDTO.UserId))
                        {
                            bookingEnrollmentDTO.Id = booking.Id;
                            flag = true;
                        }
                            
                    }
                    if(flag==false)
                    {
                        dbContext.Booking_Enrollment.Add(bookingEnrollment);
                        dbContext.SaveChanges();
                    }
                    

                    EntityConverter.FillDTOFromEntity(bookingEnrollment, bookingEnrollmentDTO);
                    retVal = bookingEnrollmentDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<EventDTO> GetAllEventsOfAUser(int UserId)
        {
            List<int> EventIdList = new List<int>();
            List<EventDTO> EventList = new List<EventDTO>();
            AddressDTO addressDTO = new AddressDTO();

            using (var bookingEnrollmentContext = new BookEventManagementEntities())
            {
                foreach (var i in bookingEnrollmentContext.Booking_Enrollment)
                {
                    if (i.UserId == UserId)
                        EventIdList.Add((int)i.EventsId);
                }

                foreach (var eventId in EventIdList)
                {
                    EventDTO eventDTO = new EventDTO();
                    var Event = bookingEnrollmentContext.Events.Include("Address").FirstOrDefault(ev => ev.Id == eventId);
                    if (Event != null)
                    {
                        EntityConverter.FillDTOFromEntity(Event.Address, addressDTO);
                        eventDTO.Address = addressDTO;
                        EntityConverter.FillDTOFromEntity(Event, eventDTO);
                    }
                    EventList.Add(eventDTO);
                }


            }

            return EventList;
        }

        public List<UserDTO> GetAllUsersOfAEvent(int EventId)
        {
            List<int> UserIdList = new List<int>();
            List<UserDTO> UserList = new List<UserDTO>();
            using (var bookingEnrollmentContext = new BookEventManagementEntities())
            {
                foreach (var i in bookingEnrollmentContext.Booking_Enrollment)
                {
                    if (i.EventsId == EventId)
                        UserIdList.Add((int)i.UserId);
                }

                foreach(var userId in UserIdList)
                {
                    UserDTO userDTO = new UserDTO();
                    var User= bookingEnrollmentContext.Users.FirstOrDefault(user => user.Id==userId);
                    if (User!= null)
                    {
                        EntityConverter.FillDTOFromEntity(User, userDTO);
                    }
                    UserList.Add(userDTO);
                }

            }
            return UserList;
        }

        

       
    }
}
