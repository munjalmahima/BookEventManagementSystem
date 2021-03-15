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

        public void DeleteEvent(EventDTO EventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            eventBDC.DeleteEvent(EventDTO);
        }

        public EventDTO GetEvent(int EventId)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            return eventBDC.GetEvent(EventId);
        }

        

        public List<EventDTO> GetEvents()
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            List<EventDTO> result = eventBDC.GetEvents();
            return result;
        }

        public void UpdateEvent(EventDTO EventDTO)
        {
            IEventBDC eventBDC = (IEventBDC)BDCFactory.Instance.Create(BDCType.EventBDC);
            eventBDC.UpdateEvent(EventDTO);
        }
    }
}
