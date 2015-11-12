﻿using System;
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
    public class CustomerController : ApiController
    {
         Facade facade = new Facade();
       
        /// Will get all Customer from database 
        public IEnumerable<CustomerDto> GetAll()
        {
            var customer = new Facade().GetCustomerRepository().ReadAll();
            return new CustomerConverter().Convert(customer);
        }

        
        /// Will get a specific Customer found by the Id
        public HttpResponseMessage Get(int id)
        {
            var customer = new Facade().GetCustomerRepository().Get(id);
            CustomerDto customerDto = null;//Declare a variable
            if (customer != null)
            {
                customerDto = new CustomerConverter().Convert(customer);
                return Request.CreateResponse<CustomerDto>(HttpStatusCode.OK, customerDto);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Customer not found.")
            };
            throw new HttpResponseException(response);
        }

        
        /// Creates a Customer in the Database
        public HttpResponseMessage Post(CustomerDto customerDto)
        {
            try
            {
                var customer = new CustomerConverter().Convert(customerDto);
                 facade.GetCustomerRepository().Add(customer);

                var response = Request.CreateResponse<CustomerDto>(HttpStatusCode.Created, customerDto);
                var uri = Url.Link("GetCustomerById", new { customer.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a customer to the database")
                };
                throw new HttpResponseException(response);
            }
        }    
        /// Updates a Customer in Database
        public HttpResponseMessage Put(CustomerDto customerDto)
        {
            try
            {
                Customer customer = new CustomerConverter().Convert(customerDto);
                facade.GetCustomerRepository().Edit(customer);
                var response = Request.CreateResponse<CustomerDto>(HttpStatusCode.OK, customerDto);
                var uri = Url.Link("GetCustomerById", new { customer.Id });
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
        
        /// Delete a Customer in database
        public HttpResponseMessage Delete(int id)
        {
            facade.GetCustomerRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }
    }
}
