using System;
using  System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieWebDAL.Model;
using MovieWebDAL.Context;

namespace MovieWebDAL.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        public IEnumerable<Order> ReadAll()
        {
            using (var ctx = new MovieWebContext())
            {

                return ctx.Orders.ToList();
            }
        }
        public Order Get(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.Orders.Include(x => x.Customer).Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public void Add(Order order)
        {
            using (var ctx = new MovieWebContext())
            {
                ctx.Orders.Add(order);
                ctx.SaveChanges();
            }
        }
        public void Edit(Order order)
        {
            using (var ctx = new MovieWebContext())
            {
                Order m = ctx.Orders.Where(x => x.Id == order.Id).First();
                m.Customer = order.Customer;
                m.CustomerId = order.CustomerId;
                m.OrderLines = order.OrderLines;
                m.Date = order.Date;
                m.Id = order.Id;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                Order m = ctx.Orders.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.Orders.Remove(m);
                ctx.SaveChanges();
            }
        }
    }
}
