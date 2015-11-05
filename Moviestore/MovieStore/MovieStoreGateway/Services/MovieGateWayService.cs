using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MovieStoreMVCDto;

namespace MovieStoreGateWay.Services
{
    public class MovieGateWayService : IGateWayService<Movie>
    {
        public IEnumerable<Movie> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:23512/api/movie/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            }
        }
        public Movie Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:23512/api/movie/" + id).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }
        public Movie Add(Movie movie)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:23512/api/movie/", movie).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }

        public Movie Edit(Movie movie)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:23512/api/movie/", movie).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }
        public Movie Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:23512/api/movie/" + id).Result;
                return response.Content.ReadAsAsync<Movie>().Result;
            }
        }


    }

}
