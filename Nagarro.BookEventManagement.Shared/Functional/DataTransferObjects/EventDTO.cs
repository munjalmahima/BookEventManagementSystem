
using System;
using System.ComponentModel.DataAnnotations;
//using Nagarro.BookEventManagement.EntityDataModel;

namespace Nagarro.BookEventManagement.Shared
{
    [EntityMapping("Event", MappingType.TotalExplicit)]
    public class EventDTO : DTOBase
    {
        public EventDTO()
        {
            Type = "public";
        }

        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id{ get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Title")]
        public string  Title{ get; set; }

        //[EntityPropertyMapping(MappingDirectionType.Both, "Address")]
        public AddressDTO Address { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "AddressId")]
        public int AddressId  { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Type")]
        public string Type { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "StartTime")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        

        [EntityPropertyMapping(MappingDirectionType.Both, "Duration")]
        [Range(0, 4)]
        public int Duration { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Invitations")]
        public string Invitations { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        [MaxLength(50)]
        public string Description { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "OtherDetails")]
        [MaxLength(500)]
        public string OtherDetails { get; set; }

        

       /* public string Address { get; set; }

         EventDTO(Event model)
         {
             Id = model.Id,
             Title= model.Title,
             AddressId= model.AddressId
             Address = model.Address.Venue + model.Address.City+model.Address.State;
         }*/
    }
}
