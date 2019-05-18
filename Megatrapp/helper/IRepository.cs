using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatrapp.helper {
    interface IRepository<T> where T: class {
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Get(T entity);
        int Get(string query);
        List<T> All();
    }
}
