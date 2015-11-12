using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDAL.Model
{

    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IEnumerable<OrderLine> OrderLines { get; set; }
        public int CustomerId { get; internal set; }
    }
}

