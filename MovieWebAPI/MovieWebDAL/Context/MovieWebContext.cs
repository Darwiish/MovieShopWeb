using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MovieWebDAL.Model;
using System.Diagnostics;

namespace MovieWebDAL.Context
{
    public class MovieWebContext : DbContext
    {
        public MovieWebContext() : base(" name=MovieWeb")
        {
            Database.SetInitializer(new MovieDBInitialize());

            //Add this line to make json conversin happy.
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             //Can only be used when you have List<> of objects
            //modelBuilder.Entity<Movie>().HasMany(g => g.Genres).WithMany();
        }
        //OnModelCreating States exactly which lists the tables are connected as many-to-many through
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        
    }
}




