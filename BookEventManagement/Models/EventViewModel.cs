using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookEventManagement.Models
{
    public class EventViewModel
    {
        public List<EventDTO> Events { get; set; }
    }
}