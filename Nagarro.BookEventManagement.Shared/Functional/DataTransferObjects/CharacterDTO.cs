using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    [EntityMapping("Character", MappingType.TotalExplicit)]
    public class CharacterDTO:DTOBase
    {

        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DatePosted")]
        public System.DateTime DatePosted { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
        public int EventId { get; set; }

        public EventDTO Event { get; set; }
        public UserDTO User { get; set; }
    }
}
