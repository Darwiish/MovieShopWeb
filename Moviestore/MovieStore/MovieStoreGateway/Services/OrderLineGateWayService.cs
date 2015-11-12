using MovieStoreMVCDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreGateWay.Services
{
    public class OrderLineGateWayService : IGateWayService<OrderLine>
    {
        public OrderLine Add(OrderLine t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4835/api/orderline/", t).Result;
                return response.Content.ReadAsAsync<OrderLine>().Result;
            }
        }

        public OrderLine Delete(OrderLine t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4835/api/orderline/", t).Result;
                return response.Content.ReadAsAsync<OrderLine>().Result;
            }
        }

        public OrderLine Edit(OrderLine t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:4835/api/orderline/", t).Result;
                return response.Content.ReadAsAsync<OrderLine>().Result;
            }
        }

        public OrderLine Get(OrderLine t)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4835/api/orderline/").Result;
                return response.Content.ReadAsAsync<OrderLine>().Result;
            }
        }

        public IEnumerable<OrderLine> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:4835/api/orderline/").Result;
                return response.Content.ReadAsAsync<IEnumerable<OrderLine>>().Result;
            }
        }
    }
}
