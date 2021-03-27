using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    public interface IEventFacade:IFacade
    {
        OperationResult<EventDTO> CreateEvent(EventDTO EventDTO);
        List<EventDTO> GetAllEvents();
        EventDTO GetEventById(int EventId);
        bool UpdateEvent(EventDTO EventDTO);
        bool DeleteEvent(EventDTO eventDTO);

    }
}
