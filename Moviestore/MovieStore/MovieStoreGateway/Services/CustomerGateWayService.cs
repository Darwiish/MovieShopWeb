﻿using MovieStoreMVCDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreGateWay.Services
{
    public class CustomerGateWayService : IGateWayService<Customer>
    {
        public IEnumerable<Customer> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:23512/api/customer/").Result;
                return response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            }
        }
        public Customer Get(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync("http://localhost:23512/api/customer/" + id).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }
        
        public Customer Add(Customer customer)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync("http://localhost:23512/api/customer/", customer).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }

        public Customer Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync("http://localhost:23512/api/customer/" +id).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }

        public Customer Edit(Customer customer)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync("http://localhost:23512/api/customer/", customer).Result;
                return response.Content.ReadAsAsync<Customer>().Result;
            }
        }

    }
}

