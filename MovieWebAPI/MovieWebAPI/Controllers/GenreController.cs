using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieWebDAL.Model;
using MovieWebDAL.Repository;
using MovieWebDTO;
using MovieWebDTO.DTOs;

namespace MovieWebAPI.Controllers
{
    public class GenreController : ApiController
    {
        Facade facade = new Facade();

        /// <summary>
        /// Will get all Genre from database.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GenreDto> GetAll()
        {
            var genre = new Facade().GetGenryRepository().ReadAll();
            return new GenreConverter().Convert(genre);
        }
        /// <summary>
        /// Will get a specific Genre found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>    
        public HttpResponseMessage Get(int id)
        {
            var genre = new Facade().GetGenryRepository().Get(id);
            GenreDto genreDto = null;
            if (genre != null)
            {
                genreDto = new GenreConverter().Convert(genre);
                return Request.CreateResponse<GenreDto>(HttpStatusCode.OK, genreDto);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Genre not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a Genre in the Database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(GenreDto genreDto)
        {
            try
            {
                var genre = new GenreConverter().Convert(genreDto);
                facade.GetGenryRepository().Add(genre);

                var response = Request.CreateResponse<GenreDto>(HttpStatusCode.Created, genreDto);
                var uri = Url.Link("GetGenreById", new { genre.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a Genre to the database")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Updates a Genre in Database
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        /// Updates a Genre in Database
        public HttpResponseMessage Put(GenreDto genreDto)
        {
            try
            {
                Genre genre = new GenreConverter().Convert(genreDto);
                facade.GetGenryRepository().Edit(genre);
                var response = Request.CreateResponse<GenreDto>(HttpStatusCode.OK, genreDto);
                var uri = Url.Link("GetGenreById", new { genre.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching genre")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Delete a Genre in database
        /// </summary>
        /// <param name="id"></param>
        public HttpResponseMessage Delete(int id)
        {
            facade.GetGenryRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }
    }
}