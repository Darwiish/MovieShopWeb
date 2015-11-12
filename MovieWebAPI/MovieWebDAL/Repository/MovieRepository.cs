using System;
using MovieWebDAL.Model;
using MovieWebDAL.Repository;
using MovieWebDAL.Context;
using System.Collections.Generic;
using  System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDAL.Repository
{
    public class MovieRepository : IRepository<Movie>
    {
       
        public IEnumerable<Movie> ReadAll()
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.Movies.Include(x => x.Genre).ToList();
            }
        }
        public Movie Get(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.Movies.Include(x => x.Genre).Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public void Add(Movie movie)
        {
            using (var ctx = new MovieWebContext())
            {
                ctx.Movies.Add(movie);
                ctx.SaveChanges();
            }
        }
        public void Edit(Movie movie)
        {
            using (var ctx = new MovieWebContext())
            {
                Movie m = ctx.Movies.Where(x => x.Id == movie.Id).First();
                m.ImageUrl = movie.ImageUrl;
                m.Title = movie.Title;
                m.Price = movie.Price;
                m.Year = movie.Year;
                m.TralierUrl = movie.TralierUrl;
                m.Genre = movie.Genre;
                m.GenreId = movie.GenreId;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                Movie m = ctx.Movies.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.Movies.Remove(m);
                ctx.SaveChanges();
            }
        }

    }
}


