using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MovieWebDTO.DTOs
{

    [DataContract(IsReference = true)]
    public class CustomerDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Email { get; set; }

        //[DataMember]
       // public virtual IEnumerable<OrderDto> Orders { get; set; }
    }
}