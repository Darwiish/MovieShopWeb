using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDTO
{
   public abstract class AbstractDtoConverter<T, TD>
    {
        public IEnumerable<TD> Convert(IEnumerable<T> toConvert)
        {
            List<TD> converted = new List<TD>();
            foreach (var item in toConvert)
            {
                converted.Add(Convert(item));
            }
            return converted;
        }

        public abstract TD Convert(T item);
    }
}