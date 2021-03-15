
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
                Title = "Book-Fetish",
                Address = addressDTO,
                
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
                Email = "mahima.munjal@nagarro.com",
                Password = "123456",
               
            };

            IEventFacade eventFacade = (IEventFacade)FacadeFactory.Instance.Create(FacadeType.EventFacade);
        /*    OperationResult<EventDTO> result = eventFacade.CreateEvent(eventDTO);


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
            }*/
            

            List<EventDTO> eventList = eventFacade.GetEvents();
            System.Console.WriteLine("Get Events");
            foreach (var i in eventList)
            {
                System.Console.WriteLine(i.Id);
                System.Console.WriteLine(i.Title);
            }
            
            eventDTO = eventFacade.GetEvent(eventList[0].Id);
  
            System.Console.WriteLine("Fetch Event");
            System.Console.WriteLine(eventDTO.Id);
            System.Console.WriteLine(eventDTO.Title);
            System.Console.WriteLine(eventDTO.Address.City);
            System.Console.WriteLine(eventDTO.Address.Venue);
            System.Console.WriteLine(eventDTO.Address.State);
            System.Console.WriteLine("Success");

            eventFacade.UpdateEvent(eventList[5]);
            eventFacade.DeleteEvent(eventList[1]);
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            /*     OperationResult<UserDTO> result1 = userFacade.NewUser(userDTO);

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
                 }*/

                 List<UserDTO> userList = userFacade.GetUsers();

                 System.Console.WriteLine("Get Users");
                 foreach (var i in userList)
                 {

                     System.Console.WriteLine(i.Id);
                     System.Console.WriteLine(i.Name);
                 }

                userDTO = userFacade.GetUser(userList[0].Id);
                System.Console.WriteLine("Fetch User");
                System.Console.WriteLine(userDTO.Id);
                System.Console.WriteLine(userDTO.Name);
                System.Console.WriteLine(userDTO.Email);







            System.Console.ReadKey();

            
      
        }
    }
}
