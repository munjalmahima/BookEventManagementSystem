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
                using (BookEventManagementEntities dbContext = new BookEventManagementEntities())
                {
                    Event e = new Event();
                    Address address = new Address();
                    EntityConverter.FillEntityFromDTO(eventDTO.Address, address);

                    List<AddressDTO> addressList = GetAddresses();
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
                        var address1 = dbContext.Addresses.Add(address);
                        eventDTO.AddressId = address1.Id;
                    }

                    EntityConverter.FillEntityFromDTO(eventDTO, e);

                    dbContext.Events.Add(e);
                    dbContext.SaveChanges();

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

        public List<AddressDTO> GetAddresses()
        {
            List<AddressDTO> addressList = new List<AddressDTO>();
            using (var context = new BookEventManagementEntities())
            {
                foreach (var a in context.Addresses)
                {
                    AddressDTO addressDTO = new AddressDTO();
                    EntityConverter.FillDTOFromEntity(a, addressDTO);
                    addressList.Add(addressDTO);
                }
                return addressList;
            }
        }

        public List<EventDTO> GetEvents()
        {
            List<EventDTO> eventList = new List<EventDTO>();
            using (var context = new BookEventManagementEntities())
            {
                foreach (var e in context.Events)
                {
                    EventDTO eventDTO = new EventDTO();
                    EntityConverter.FillDTOFromEntity(e, eventDTO);
                    eventList.Add(eventDTO);
                }
            }
            
            return eventList;
        }

        public AddressDTO GetEventAddress(int AddressId)
        {
            AddressDTO add = new AddressDTO();
            List<AddressDTO> addressList = GetAddresses();
            foreach (var a in addressList)
            {
                if (a.Id==AddressId)
                {
                    EntityConverter.FillDTOFromEntity(a,add);
                }
            }
            return add;
        }

        public EventDTO GetEvent(int EventId)
        {
            EventDTO eventDTO = new EventDTO();
            List<EventDTO> eventList = GetEvents();
            foreach (var a in eventList)
            {
                if (a.Id == EventId)
                {
                    eventDTO.Address = GetEventAddress(a.AddressId);
                    EntityConverter.FillDTOFromEntity(a,eventDTO);
                }
            }
            return eventDTO;
        }

        public void UpdateEvent(EventDTO eventDTO)
        {
            using (BookEventManagementEntities updateContext = new BookEventManagementEntities())
            {
                Event e = new Event();
                var result = updateContext.Events.Include("Address").SingleOrDefault(ev => ev.Id == eventDTO.Id);
                
                if(result!=null)
                {
                    EntityConverter.FillDTOFromEntity(result, eventDTO);
                    eventDTO.Title = "Book-A-Holic";
                    EntityConverter.FillEntityFromDTO(eventDTO,e);
                    updateContext.SaveChanges();
                    Console.ReadKey();
                }
             

                //EntityConverter.FillEntityFromDTO(eventDTO, e);
                Console.WriteLine(e.Id);
                Console.WriteLine(e.Title);
                
            }

        }

        public void DeleteEvent(EventDTO eventDTO)
        {
            using (BookEventManagementEntities deleteContext = new BookEventManagementEntities())
            {
                
                Event e = new Event();

                EntityConverter.FillEntityFromDTO(eventDTO, e);
                Console.WriteLine(e.Id);
                Console.WriteLine(e.Title);

                deleteContext.Events.Remove(e);

               deleteContext.SaveChanges();
            }
        }
    }

       

       
}

