using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebDAL.Repository
{

    public interface IRepository<T>
    {
        IEnumerable<T> ReadAll();

        T Get(int id);

        void Add(T t);

        void Delete(int id);

        void Edit(T t);


    }
}
