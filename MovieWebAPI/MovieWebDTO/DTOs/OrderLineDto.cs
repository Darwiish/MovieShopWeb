using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDTO.DTOs
{
    public class OrderLineDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; internal set; }
        public int OrderId { get; internal set; }
    }
}
