using System;
using System.Data.Entity;
using MovieWebDAL.Model;
using MovieWebDAL.Context;
using MovieWebDAL.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDAL.Repository
{
    public class OrderLineRepository : IRepository<OrderLine>
    {
        public IEnumerable<OrderLine> ReadAll()
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.OrderLines.Include(x => x.Order).Include(x => x.Movie).ToList();
            }
        }
        public OrderLine Get(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.OrderLines.Include(x => x.Movie).Include(x => x.Order).Where(x => x.OrderId == id).FirstOrDefault();
            }
        }
        public void Add(OrderLine orderLine)
        {
            using (var ctx = new MovieWebContext())
            {
                ctx.OrderLines.Add(orderLine);
                ctx.SaveChanges();
            }
        }

        public void Edit(OrderLine orderLine)
        {
            using (var ctx = new MovieWebContext())
            {
                OrderLine m = ctx.OrderLines.Where(x => x.OrderId == orderLine.OrderId).First();
                m.Amount = orderLine.Amount;
                m.OrderId = orderLine.OrderId;
                m.MovieId = orderLine.MovieId;
                m.Movie = orderLine.Movie;
                m.Order = orderLine.Order;
                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                OrderLine m = ctx.OrderLines.Where(x => x.OrderId == id).First();
                if (m != null)
                    ctx.OrderLines.Remove(m);
                ctx.SaveChanges();
            }
        }
    }
}
