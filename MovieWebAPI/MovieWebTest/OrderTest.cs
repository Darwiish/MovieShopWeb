using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieWebDAL.Model;
using NUnit.Framework;


namespace MovieWebTest
{
    [TestFixture]
    public class OrderTest
    {
        public Customer id { get; private set; }

        [Test]
        public void order_set_test()
        {
            //var order = new OrderTest();
            //var customer = new Customer() { Id = 1, FirstName = "Bog Foot" , LastName = " KKK" };
            //order.id = customer;
            //order.order_set_test();

            //Assert.AreEqual(order.id, 1);
            //Assert.AreEqual(order., 1302);
            //Assert.AreEqual(order.);

            //Assert.Throws<ArgumentNullException>(() => Order.(null, GetTestOrderLine(), GetTestProduct()));
            //Assert.Throws<ArgumentNullException>(() => Order.OrderSum(orders.ElementAt(0), null, GetTestProduct()));
            //Assert.Throws<ArgumentNullException>(() => Order.OrderSum(orders.ElementAt(0), GetTestOrderLine(), null));

            //Assert.Throws<Exception>(() => OrderSummarizer.OrderSum(orders.ElementAt(2), GetTestOrderLine(), GetTestProduct()));

        }
    }
}

