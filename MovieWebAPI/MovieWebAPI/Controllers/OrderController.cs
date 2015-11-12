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
    public class OrderController : ApiController
    {
        Facade facade = new Facade();

        /// Will get all Order from database.
        public IEnumerable<OrderDto> GetAll()
        {
            var order = new Facade().GetOrderRepository().ReadAll();
            return new OrderConverter().Convert(order);
        }

        /// Will get a specific Order found by the Id       
        public HttpResponseMessage Get(int id)
        {
            var order = new Facade().GetOrderRepository().Get(id);
            OrderDto orderDto = null;//Declare a variable
            if (order != null)
            {
                orderDto = new OrderConverter().Convert(order);
                return Request.CreateResponse<OrderDto>(HttpStatusCode.OK, orderDto);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("Order not found.")
            };
            throw new HttpResponseException(response);
        }

        /// Creates a Order in the Database
        public HttpResponseMessage Post(OrderDto orderDto)
        {
            try
            {
                var order = new OrderConverter().Convert(orderDto);
                facade.GetOrderRepository().Add(order);

                var response = Request.CreateResponse<OrderDto>(HttpStatusCode.Created, orderDto);
                var uri = Url.Link("GetOrderById", new { order.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a Order to the database")
                };
                throw new HttpResponseException(response);
            }
        }

        /// Updates a Order in Database
        public HttpResponseMessage Put(OrderDto orderDto)
        {
            try
            {
                Order order = new OrderConverter().Convert(orderDto);
                facade.GetOrderRepository().Edit(order);
                var response = Request.CreateResponse<OrderDto>(HttpStatusCode.OK, orderDto);
                var uri = Url.Link("GetOrderById", new { order.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching order")
                };
                throw new HttpResponseException(response);
            }
        }

        /// Delete a Order in database
        public HttpResponseMessage Delete(int id)
        {
            facade.GetOrderRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }
    }
}