using System;
using System.Collections.Generic;

namespace MovieWebDTO.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual CustomerDto Customer { get; set; }
        public virtual ICollection<OrderLineDto> OrderLines { get; set; }
    }
}