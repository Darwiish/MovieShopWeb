using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreMVCDto
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IEnumerable<OrderLine> OrderLines { get; set; }
    }
}
