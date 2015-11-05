using MovieStoreMVCDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreGateWay.Services
{
    public class OrderGateWayService : IGateWayService<Order>
    {
        public Order Add(Order t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:23512/api/order/", t).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public Order Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:23512/api/order/", id).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public Order Edit(Order t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:23512/api/order/", t).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public Order Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:23512/api/order/"+id).Result;
                return response.Content.ReadAsAsync<Order>().Result;
            }
        }

        public IEnumerable<Order> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:23512/api/order/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            }
        }
    }
}
