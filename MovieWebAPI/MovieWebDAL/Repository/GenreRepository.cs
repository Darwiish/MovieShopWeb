using System;
using MovieWebDAL.Model;
using MovieWebDAL.Repository;
using MovieWebDAL.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDAL.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        public IEnumerable<Genre> ReadAll()
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.Genres.ToList();
            }
        }
        public Genre Get(int id)
        {
            using (var ctx = new MovieWebContext())
            {
                return ctx.Genres.Where(x => x.Id == id).FirstOrDefault();
            }
        }
        public void Add(Genre genre)
        {
            using (var ctx = new MovieWebContext())
            {

                ctx.Genres.Add(genre);
                ctx.SaveChanges();
            }
        }

        public void Edit(Genre genre)
        {
            using (var ctx = new MovieWebContext())
            {
                Genre m = ctx.Genres.Where(x => x.Id == genre.Id).First();
                m.Id = genre.Id;
                m.Name = genre.Name;
                ctx.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (var ctx = new MovieWebContext())
            {

                Genre m = ctx.Genres.Where(x => x.Id == id).First();
                if (m != null)
                    ctx.Genres.Remove(m);
                ctx.SaveChanges();
            }
        }

    }
}


