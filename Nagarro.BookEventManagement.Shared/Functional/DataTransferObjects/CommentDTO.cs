using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    [EntityMapping("Comment", MappingType.TotalExplicit)]
    public class CommentDTO:DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Comment1")]
        public string Comment1 { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "DatePosted")]
        public DateTime? DatePosted { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int? UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "EventId")]
        public int? EventId { get; set; }

        public EventDTO Event { get; set; }
        public UserDTO User { get; set; }
    }
}
