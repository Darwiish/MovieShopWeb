using System;
using MovieWebDAL.Model;
using MovieWebDTO.DTOs;

namespace MovieWebDTO
{
    public class GenreConverter : AbstractDtoConverter<Genre, GenreDto>
    {
        public override GenreDto Convert(Genre item)
        {
            var dto = new GenreDto() {Id = item.Id, Name = item.Name};
            if (item.Movies != null)
            {
                dto.Movies = new MovieConverter().Convert(item.Movies);
            }
            return dto;
        }

        public Genre Convert(GenreDto genreDto)
        {
            throw new NotImplementedException();

        }


    }
}