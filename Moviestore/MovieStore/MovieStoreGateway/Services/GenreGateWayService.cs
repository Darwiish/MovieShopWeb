﻿using MovieStoreMVCDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreGateWay.Services
{
    public class GenreGateWayService : IGateWayService<Genre>
    {
        public Genre Add(Genre t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4835/api/genre/", t).Result;
                return response.Content.ReadAsAsync<Genre>().Result;
            }
        }

        public Genre Delete(Genre t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4835/api/genre/", t).Result;
                return response.Content.ReadAsAsync<Genre>().Result;
            }
        }

        public Genre Edit(Genre t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4835/api/genre/", t).Result;
                return response.Content.ReadAsAsync<Genre>().Result;
            }
        }

        public Genre Get(Genre t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                        client.GetAsync("http://localhost:4835/api/genre/").Result;
                return response.Content.ReadAsAsync<Genre>().Result;
            }
        }

        public IEnumerable<Genre> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4835/api/genre/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            }
        }
    }
}
