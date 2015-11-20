using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreMVCDto
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
