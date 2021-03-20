
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nagarro.BookEventManagement.Shared;

namespace Nagarro.BookEventManagement.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            AddressDTO addressDTO = new AddressDTO()
            {
                Venue = "Hawa Mahal",
                City = "Jaipur",
                State = "Rajasthan"
            };

           
            EventDTO eventDTO = new EventDTO()
            {
                Id=5,
                Title = "Book-A-Bahaarazoxoc",
                Address = addressDTO,
                //Type="",
                Date = DateTime.Today,
                StartTime = DateTime.Today,
                
                Duration = 4,
                Description = "Mahima",
                OtherDetails = "Munjal",
                Invitations = "Very Good"
            };

            UserDTO userDTO = new UserDTO
            {
                Id=5,
                Name = "Mahima Munjal",
                Email = "mahima.munjal@nagarro.como",
                Password = "123456",
               
            };

            
            

            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
            OperationResult<EventDTO> result = eventFacade.CreateEvent(eventDTO);


            if (result.IsValid())
            {
                var resultData = result.Data;
                System.Console.WriteLine("Create Event");
                System.Console.WriteLine(resultData.Id);
                System.Console.WriteLine(resultData.Title);
                System.Console.WriteLine("Sucesss");
            }
            else
            {
                System.Console.WriteLine("Failure");
            }

          
            List<EventDTO> eventList = eventFacade.GetAllEvents();
            System.Console.WriteLine("Get Events");
            foreach (var i in eventList)
            {
                System.Console.WriteLine(i.Id);
                System.Console.WriteLine(i.Title);
            }
            
            eventDTO = eventFacade.GetEventById(eventList[0].Id);
  
            System.Console.WriteLine("Fetch Event");
            System.Console.WriteLine(eventDTO.Id);
            System.Console.WriteLine(eventDTO.Title);
            System.Console.WriteLine(eventDTO.Address.City);
            System.Console.WriteLine(eventDTO.Address.Venue);
            System.Console.WriteLine(eventDTO.Address.State);
            System.Console.WriteLine("Success");

            EventDTO eventDTO1 = eventList[0];
            eventDTO1.Title = "Booky-Fiesta";


           eventFacade.UpdateEvent(eventDTO1);
           eventFacade.DeleteEvent(eventList[2]);

                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<UserDTO> result1 = userFacade.RegisterUser(userDTO);

                 if (result1.IsValid())
                 {
                     var resultData = result1.Data;
                     System.Console.WriteLine("Create User");
                     System.Console.WriteLine(resultData.Id);
                     System.Console.WriteLine(resultData.Name);
                     System.Console.WriteLine("Sucesss");
                 }
                 else
                 {
                     System.Console.WriteLine("Failure");
                 }

                 List<UserDTO> userList = userFacade.GetAllUsers();

                 System.Console.WriteLine("Get Users");
                 foreach (var i in userList)
                 {

                     System.Console.WriteLine(i.Id);
                     System.Console.WriteLine(i.Name);
                 }

              userDTO = userFacade.GetUserById(userList[0].Id);
              System.Console.WriteLine("Fetch User");
              System.Console.WriteLine(userDTO.Id);
              System.Console.WriteLine(userDTO.Name);
              System.Console.WriteLine(userDTO.Email);

                userDTO = userFacade.GetUserByEmailAndPassword(userList[1].Email,userList[1].Password);
                System.Console.WriteLine("Fetch User");
                System.Console.WriteLine(userDTO.Id);
                System.Console.WriteLine(userDTO.Name);
                System.Console.WriteLine(userDTO.Email);

            CommentDTO commentDTO = new CommentDTO()
            {
                Id = 1,
                Comment1 = "Very Nice",
                EventId=eventList[1].Id,
                UserId=userList[1].Id
            };

            ICommentFacade commentFacade = (ICommentFacade)FacadeFactory.Instance.Create(FacadeType.CommentFacade);
            OperationResult<CommentDTO> result2 = commentFacade.AddNewComment(commentDTO);

            if (result2.IsValid())
            {
                var resultData = result2.Data;
                System.Console.WriteLine("Create Comment");
                System.Console.WriteLine(resultData.Id);
                System.Console.WriteLine(resultData.Comment1);
                System.Console.WriteLine("Sucesss");
            }
            else
            {
                System.Console.WriteLine("Failure");
            }
            List<CommentDTO> commentList = commentFacade.GetAllCommentsOfAnEvent(eventList[0].Id);
            System.Console.WriteLine("Get Comments");
            foreach (var i in commentList)
            {
                System.Console.WriteLine(i.Id);
                System.Console.WriteLine(i.Comment1);
                System.Console.WriteLine(i.UserId);
            }

            BookingEnrollmentDTO bookingDTO = new BookingEnrollmentDTO()
                {
                    Id = 2,
                    EventsId=eventList[0].Id,
                    UserId=userList[1].Id
                };

            IBookingEnrollmentFacade bookingFacade = (IBookingEnrollmentFacade)FacadeFactory.Instance.Create(FacadeType.BookingEnrollment);

            BookingEnrollmentDTO bookingResult = bookingFacade.CreateBooking(bookingDTO);
            System.Console.WriteLine("Create Booking");
            System.Console.WriteLine(bookingResult.Id);
            System.Console.WriteLine(bookingResult.EventsId);
            System.Console.WriteLine(bookingResult.UserId);

          
            List<UserDTO> Users= bookingFacade.GetAllUsersOfAEvent(eventList[0].Id);
            System.Console.WriteLine("All Users of Event "+eventList[0].Title);
            foreach (var i in Users)
            {
                System.Console.WriteLine(i.Id);
                System.Console.WriteLine(i.Name);
                System.Console.WriteLine(i.Email);
            }

            List<EventDTO> Events = bookingFacade.GetAllEventsOfAUser(userList[0].Id);
            System.Console.WriteLine("All Eventa of User " + userList[0]);
            foreach (var i in Events)
            {
                System.Console.WriteLine(i.Id);
                System.Console.WriteLine(i.Title);
                System.Console.WriteLine(i.Duration);
            }
            

            System.Console.ReadKey();

            
      
        }
    }
}


