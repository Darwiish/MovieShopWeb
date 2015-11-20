using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStoreGateWay.Services;

namespace MovieStoreGateWay
{
   
   public class Facade
    {
       // private MovieGateWayService movieGateway;
        public MovieGateWayService GetMovieGateway()
        {
            return new MovieGateWayService();
        }
        public CustomerGateWayService GetCustomerGateway()
        {
            return new CustomerGateWayService();
        }
        public GenreGateWayService GetGenerrGateway()
        {
            return new GenreGateWayService();
        }
        public OrderGateWayService GetOrdereGateway()
        {
            return new OrderGateWayService();
        }
        public OrderLineGateWayService GetOrderLineGateway()
        {
            return new OrderLineGateWayService();
        }
    }
}

   