using System;
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
    [Table("Movie")]
    public class Movie
    {
        [DataMember]
        [Key]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string TralierUrl { get; set; }
        [DataMember]
        public Genre Genre { get; set; }
        [DataMember]
        public int GenreId { get; set; }
    }
}