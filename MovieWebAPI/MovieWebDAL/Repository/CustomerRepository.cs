using MovieWebDAL.Model;
using MovieWebDAL.Context;
using MovieWebDAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieWebDAL.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        public IEnumerable<Customer> ReadAll()
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.Customers.ToList();
            }
        }
        public Customer Get(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.Customers.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public void Add(Customer customer)
        {
            using (var ctx = new MovieWebContext())
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }
        public void Edit(Customer customer)
        {
            using (var ctx = new MovieWebContext())
            {
                Customer m = ctx.Customers.Where(x => x.Id == customer.Id).First();
                m.FirstName = customer.FirstName;
                m.LastName = customer.LastName;
                m.Address = customer.Address;
                m.Email = customer.Email;
                m.Orders = customer.Orders;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                Customer m = ctx.Customers.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.Customers.Remove(m);
                ctx.SaveChanges();
            }
        }
    }
}