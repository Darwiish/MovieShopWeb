using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MovieWebDAL.Model;
using MovieWebDTO.DTOs;

namespace MovieWebDTO.DTOs
{
    [DataContract(IsReference = true)]
    public class MovieDto
    {
        [DataMember]
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
        public int GenreId { get; set; }
        [DataMember]
        public virtual GenreDto Genre { get; set; }
    }
}
