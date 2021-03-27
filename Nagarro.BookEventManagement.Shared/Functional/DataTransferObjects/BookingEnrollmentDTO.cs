using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{

    [EntityMapping("Address", MappingType.TotalExplicit)]
    public class BookingEnrollmentDTO:DTOBase
    {
        public BookingEnrollmentDTO()
        {
            Id = -1;
        }
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }
        
        [EntityPropertyMapping(MappingDirectionType.Both, "Username")]
        public string Username { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "EventsId")]
        public int? EventsId { get; set; }

        public EventDTO Event { get; set; }
       
    }
}
