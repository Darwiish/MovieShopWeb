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
    public class OrderLineController : ApiController
    {
        Facade facade = new Facade();

        /// <summary>
        /// Will get all Orderlines from database
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<OrderLineDto> GetAll()
        {
            var orderLine = new Facade().GetOrderLineRepository().ReadAll();
            return new OrderLineConverter().Convert(orderLine);
        }
        /// <summary>
        /// Will get a specific Orderline found by the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>   
        public HttpResponseMessage Get(int id)
        {
            var orderLine = new Facade().GetOrderLineRepository().Get(id);
            OrderLineDto orderLineDto = null;
            if (orderLine != null)
            {
                orderLineDto = new OrderLineConverter().Convert(orderLine);
                return Request.CreateResponse<OrderLineDto>(HttpStatusCode.OK, orderLineDto);
            }
            var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent("OrderLine not found.")
            };
            throw new HttpResponseException(response);
        }

        /// <summary>
        /// Creates a Orderline
        /// </summary>
        /// <param name="orderLine"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(OrderLineDto orderLineDto)
        {
            try
            {
                var orderLine = new OrderLineConverter().Convert(orderLineDto);
                facade.GetOrderLineRepository().Add(orderLine);

                var response = Request.CreateResponse<OrderLineDto>(HttpStatusCode.Created, orderLineDto);
                var uri = Url.Link("GetOrderLineById", new { orderLine.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("Could not add a OrderLine to the database")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Updates a Orderline
        /// </summary>
        /// <param name="orderLine"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(OrderLineDto orderLineDto)
        {
            try
            {
                OrderLine orderLine = new OrderLineConverter().Convert(orderLineDto);
                facade.GetOrderLineRepository().Edit(orderLine);
                var response = Request.CreateResponse<OrderLineDto>(HttpStatusCode.OK, orderLineDto);
                var uri = Url.Link("GetOrderLineById", new { orderLine.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("No matching orderLine")
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// Deletes a Orderline
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            facade.GetOrderLineRepository().Delete(id);
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            return response;
        }
    }
}