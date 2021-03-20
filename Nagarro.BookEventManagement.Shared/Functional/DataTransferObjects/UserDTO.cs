using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{
    [EntityMapping("User", MappingType.TotalExplicit)]
    public class UserDTO:DTOBase
    {
        public UserDTO()
        {
            Type = "normal";
        }

        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        public string Email { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
        public string Password { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Name")]
        public string Name { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Type")]
        public string Type { get; set; }
    }
}
