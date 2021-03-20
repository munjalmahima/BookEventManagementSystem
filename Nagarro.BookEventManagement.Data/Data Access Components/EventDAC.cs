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

                    List<AddressDTO> addressList = new List<AddressDTO>();
                    foreach (var a in eventContext.Addresses)
                    {
                        AddressDTO addressDTO = new AddressDTO();
                        EntityConverter.FillDTOFromEntity(a, addressDTO);
                        addressList.Add(addressDTO);
                    }

                    bool flag = false;
                    foreach (var i in addressList)
                    {
                        if (i.Venue == address.Venue)
                        {
                            if (i.City == i.City)
                            {
                                if (i.State == i.State)
                                {
                                    address.Id = i.Id;
                                    eventDTO.AddressId = address.Id;
                                    eventDTO.Address = null;
                                    flag = true;
                                    break;
                                }

                            }
                        }
                    }

                    if (flag == false)
                    {
                        var address1 = eventContext.Addresses.Add(address);
                        eventDTO.AddressId = address1.Id;
                    }

                    EntityConverter.FillEntityFromDTO(eventDTO, e);

                    eventContext.Events.Add(e);
                    eventContext.SaveChanges();

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
                Event e = new Event();
                e = eventContext.Events.Include("Address").SingleOrDefault(ev => ev.Id == eventDTO.Id);
                
                if(e!=null)
                {
                    
                    EntityConverter.FillEntityFromDTO(eventDTO,e);
                    try
                    {
                        eventContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new DACException("No records found to update.",ex);
                    } 
                }

            }
            return true;
        }

        public bool DeleteEvent(EventDTO eventDTO)
        {
            using (BookEventManagementEntities eventContext = new BookEventManagementEntities())
            {

                Event e=eventContext.Events.Include("Address").SingleOrDefault(ev => ev.Id == eventDTO.Id);
                
                if(e!=null)
                {
                    eventContext.Events.Remove(e);
                    try
                    {
                        eventContext.SaveChanges();
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                        return false;
                    }

                }
          
            }
            return true;
        }

    }

       

       
}

