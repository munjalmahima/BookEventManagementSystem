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

        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }
        
        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int? UserId { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "EventsId")]
        public int? EventsId { get; set; }

        public EventDTO Event { get; set; }
        public UserDTO User { get; set; }
    }
}
