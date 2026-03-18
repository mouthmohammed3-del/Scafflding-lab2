using Scaffoldinglab2.Data;
using Scaffoldinglab2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Scaffoldinglab2.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly dblab2DbContext context;

        public GenericRepository(dblab2DbContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            try
            {
               var res =  context.Add(entity);
                context.SaveChanges();
                return res.Entity;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return default(T);

            }
        }

        public bool Delete(T entity)
        {



            try
            {
                var res = context.Remove(entity);
                if (res.State == EntityState.Deleted)
                {
                    return true;
                }
                return false;


            }
            catch (Exception)
            {
                return false;


            }

        }

        public IEnumerable<T> GetAll()
        {
            
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

    

        public T Update(T entity)
        {
            try
            {
                var res = context.Update(entity);
                if(res.State == EntityState.Modified)
                {
                    return res.Entity;
                }
                return default(T);

            }
            catch  (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
               
            }
        }
    }
}
