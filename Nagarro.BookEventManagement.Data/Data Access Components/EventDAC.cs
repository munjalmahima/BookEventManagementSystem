using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BookEventManagement.EntityDataModel;

namespace Nagarro.BookEventManagement.Data
{
    public class EventDAC : DACBase, IEventDAC
    {
        public EventDAC()
            : base(DACType.EventDAC)
        {

        }

        public EventDTO CreateEvent(EventDTO eventDTO)
        {
            EventDTO retVal = null;
            try
            {
                using (BookEventManagementEntities eventContext = new BookEventManagementEntities())
                {
                    Event e = new Event();
                    Address address = new Address();
                    
                    EntityConverter.FillEntityFromDTO(eventDTO.Address, address);

                    bool flag = false;
                    foreach (var i in eventContext.Addresses)
                    {
                        if (i.Venue == address.Venue)
                        {
                            if (i.City == address.City)
                            {
                                if (i.State == address.State)
                                {
                                    address.Id = i.Id;
                                    eventDTO.AddressId = address.Id;
                                    //eventDTO.Address = null;
                                    flag = true;
                                    break;
                                }

                            }
                        }
                    }

                    if (flag == false)
                    {
                        Address address1 = eventContext.Addresses.Add(address);
                        eventContext.SaveChanges();
                        foreach (var i in eventContext.Addresses)
                        {
                            if (i.Venue == address1.Venue)
                            {
                                if (i.City == address1.City)
                                {
                                    if (i.State == address1.State)
                                    {
                                        address1.Id = i.Id;
                                        eventDTO.AddressId = address1.Id;
                                        
                                    }

                                }
                            }
                        }
                        Console.WriteLine("\n\nAddress Id : "+address1.Id);
                        eventDTO.AddressId = address1.Id;
                        Console.WriteLine("\n\nAddress Id : " + eventDTO.AddressId);
                    }

                    EntityConverter.FillEntityFromDTO(eventDTO, e);
                    try
                    {
                        eventContext.Events.Add(e);
                        eventContext.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        ExceptionManager.HandleException(ex);
                        throw new DACException(ex.Message, ex);
                    }
                    

                    EntityConverter.FillDTOFromEntity(e, eventDTO);
                    retVal = eventDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }

            return retVal;
        }

        public List<EventDTO> GetAllEvents()
        {
            List<EventDTO> eventList = new List<EventDTO>();
            using (var eventContext = new BookEventManagementEntities())
            {
                foreach (var e in eventContext.Events)
                {
                    EventDTO eventDTO = new EventDTO();
                    EntityConverter.FillDTOFromEntity(e, eventDTO);
                    eventList.Add(eventDTO);
                }
            }
            
            return eventList;
        }

        public EventDTO GetEventById(int EventId)
        {
            EventDTO eventDTO = new EventDTO();
            AddressDTO addressDTO = new AddressDTO();
            using (var eventContext = new BookEventManagementEntities())
            {
                var result = eventContext.Events.Include("Address").FirstOrDefault(ev => ev.Id == EventId);
                if (result != null)
                {
                    EntityConverter.FillDTOFromEntity(result.Address, addressDTO);
                    eventDTO.Address = addressDTO;
                    EntityConverter.FillDTOFromEntity(result, eventDTO);
                }
            }
            return eventDTO; 
        }

        public bool UpdateEvent(EventDTO eventDTO)
        {
            using (BookEventManagementEntities eventContext = new BookEventManagementEntities())
            {
                Event e= eventContext.Events.Include("Address").SingleOrDefault(ev => ev.Id == eventDTO.Id);
                
                if(e!=null)
                {
                 
                    foreach(var i in eventContext.Addresses)
                    {
                        if(i.Id==eventDTO.AddressId)
                        {
                           
                            i.Venue = eventDTO.Address.Venue;
                            i.City = eventDTO.Address.City;
                            i.State = eventDTO.Address.State;
                        }
                    }
                   
                    EntityConverter.FillEntityFromDTO(eventDTO, e);
                   
                    try
                    {
                     
                        eventContext.SaveChanges();
                    }
                    catch 
                    {
                        return false;
                    } 
                }

            }
            return true;
        }

        public bool DeleteEvent(EventDTO eventDTO)
        {
            using (BookEventManagementEntities eventContext = new BookEventManagementEntities())
            {

                Event e=eventContext.Events.SingleOrDefault(ev => ev.Id ==eventDTO.Id);
                var comments = eventContext.Comments.Where(comment => comment.EventId == eventDTO.Id).Select(comment => comment);
                var bookings = eventContext.Booking_Enrollment.Where(booking => booking.EventsId == eventDTO.Id).Select(booking =>booking);

                if (e!=null)
                {
                    eventContext.Events.Remove(e);
                    foreach(var i in comments)
                        eventContext.Comments.Remove(i);
                    foreach (var i in bookings)
                        eventContext.Booking_Enrollment.Remove(i);
                    try
                    {
                        eventContext.SaveChanges();
                    }
                    catch
                    {
                        return false;
                        
                    }

                }
          
            }
            return true;
        }

    }

       

       
}

