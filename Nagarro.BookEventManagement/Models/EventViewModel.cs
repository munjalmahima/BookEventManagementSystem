using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nagarro.BookEventManagement.Shared;

namespace Nagarro.BookEventManagement.Models
{
    public class EventViewModel
    {
        public List<EventDTO> Events { get; set; }
        public IEnumerable<EventDTO> BookedEvents { get; set; }

    }
}