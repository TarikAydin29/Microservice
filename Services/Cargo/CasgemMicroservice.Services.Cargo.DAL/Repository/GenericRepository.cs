using CasgemMicroservice.Services.Cargo.DAL.Abstract;
using CasgemMicroservice.Services.Cargo.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasgemMicroservice.Services.Cargo.DAL.Repository
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        private readonly CargoContext context;

        public GenericRepository(CargoContext context)
        {
            this.context = context;
        }
        public void Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}
