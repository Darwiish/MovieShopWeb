using MovieWebDAL.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MovieWebDTO.DTOs
{
    [DataContract(IsReference = true)]
    public class GenreDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual IEnumerable<MovieDto> Movies { get; set; }
    }

    
}
