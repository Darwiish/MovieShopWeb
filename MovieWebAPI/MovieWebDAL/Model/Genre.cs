using System;
using MovieWebDAL.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDAL.Model
{
    [DataContract(IsReference = true)]
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual IEnumerable<Movie> Movies { get; set; }

    }
}
