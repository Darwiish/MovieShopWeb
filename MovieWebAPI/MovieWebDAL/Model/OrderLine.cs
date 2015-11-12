using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDAL.Model
{

    [Table("OrderLine")]
    public class OrderLine
    {
        public int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public int Amount { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; internal set; }
        public int MovieId { get; internal set; }
        public object Name { get; set; }
    }
}
