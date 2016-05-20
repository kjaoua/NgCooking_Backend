using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCooking.Models.Repositories
{
    public interface IREpository<T> where T : class
    {
        IQueryable<T> GetAll();
        //T GetbyID(int id);
        // ObservableCollection<T> LoadAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //void Delete(int id);
        void Save();

    }
}
