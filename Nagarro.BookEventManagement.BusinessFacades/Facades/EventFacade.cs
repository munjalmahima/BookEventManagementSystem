using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.BusinessFacades
{
    public class EventFacade:FacadeBase,IEventFacade
    {
        public EventFacade()
            : base(FacadeType.EventFacade)
        {

        }

        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.CreateEvent(eventDTO);
        }

        public bool DeleteEvent(EventDTO EventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.DeleteEvent(EventDTO);
        }

        public EventDTO GetEventById(int EventId)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetEventById(EventId);
        }

        

        public List<EventDTO> GetAllEvents()
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            List<EventDTO> result = eventBDC.GetAllEvents();
            return result;
        }

        public bool UpdateEvent(EventDTO EventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.UpdateEvent(EventDTO);
        }
    }
}
