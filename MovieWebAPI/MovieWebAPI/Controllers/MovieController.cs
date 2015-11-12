using System;
using MovieWebDAL.Model;
using MovieWebDAL.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieWebDTO;
using MovieWebDTO.DTOs;

namespace MovieWebAPI.Controllers
{
    public class MovieController : ApiController
    {
        Facade facade = new Facade();

       /// Will get all Movie from database 
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
       {
           var movies = new Facade().GetMovieRepository().ReadAll();
           return new MovieConverter().Convert(movies);
       }
        /// Will get a specific Movie found by the Id
        public HttpResponseMessage Get(int id)
        {
            var movie = new Facade().GetMovieRepository().Get(id);
            MovieDto movieDto = null;//Declare a variable
            if (movie != null)
            {
                movieDto = new MovieConverter().Convert(movie);
                return Request.CreateResponse<MovieDto>(HttpStatusCode.OK, movieDto);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(" Movie not found.")
            };
            throw new HttpResponseException(response);
        }


        /// Creates a Customer in the Database
        public HttpResponseMessage Post(MovieDto movieDto)
        {
            try
            {
                var movie = new MovieConverter().Convert(movieDto);
                facade.GetMovieRepository().Add(movie);

                var response = Request.CreateResponse<MovieDto>(HttpStatusCode.Created, movieDto);
                var uri = Url.Link("GetMovieById", new { movie.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a Movie to the database")
                };
                throw new HttpResponseException(response);
            }
        }
        /// Updates a Movie in Database
        public HttpResponseMessage Put(MovieDto movieDto)
        {
            try
            {
                Movie movie = new MovieConverter().Convert(movieDto);
                facade.GetMovieRepository().Edit(movie);
                var response = Request.CreateResponse<MovieDto>(HttpStatusCode.OK, movieDto);
                var uri = Url.Link("GetMovieById", new { movie.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching customer")
                };
                throw new HttpResponseException(response);
            }
        }

        /// Delete a Movie in database
        public HttpResponseMessage Delete(int id)
        {
            facade.GetMovieRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }
    }
}
