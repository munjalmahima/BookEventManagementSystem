using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface IEventDAC : IDataAccessComponent
    {
        EventDTO CreateEvent(EventDTO EventDTO);
        List<EventDTO> GetEvents();
        List<AddressDTO> GetAddresses();
        AddressDTO GetEventAddress(int AddressId);
        EventDTO GetEvent(int EventId);
        void UpdateEvent(EventDTO EventDTO);
        void DeleteEvent(EventDTO EventDTO);
    }
}
