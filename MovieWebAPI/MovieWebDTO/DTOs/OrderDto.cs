using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MovieWebDTO.DTOs
{
    public class OrderDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public virtual CustomerDto Customer { get; set; }
        [DataMember]
        public virtual ICollection<OrderLineDto> OrderLines { get; set; }
    }
}