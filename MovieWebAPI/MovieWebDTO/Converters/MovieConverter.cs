using System;
using MovieWebDAL.Model;
using MovieWebDAL.Repository;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieWebDTO.DTOs;

namespace MovieWebDTO
{
    public class MovieConverter : AbstractDtoConverter<Movie, MovieDto>
    {
        public override MovieDto Convert(Movie item)
        {
            var dto = new MovieDto()
            {
                Id = item.Id,
                Title = item.Title,
                Price = item.Price,
                Year = item.Year,
                ImageUrl = item.ImageUrl,
                TralierUrl = item.TralierUrl,
            };
            if (item.OrderLines != null)
            {
                dto.OrderLines = new OrderLineConverter().Convert(item.OrderLines);
            }
            if (item.Genre != null)
            {
                dto.Genre = new GenreConverter().Convert(item.Genre);
            }
            return dto;
        }

        public Movie Convert(MovieDto movieDto)
        {
            throw new NotImplementedException();
        }
    }
}

