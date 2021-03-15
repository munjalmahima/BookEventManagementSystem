using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Shared
{

    [EntityMapping("Address", MappingType.TotalExplicit)]
    public class AddressDTO:DTOBase
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Venue")]
        public string Venue { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "City")]
        public string City { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "State")]
        public string State { get; set; }
    }
}
