using Core;
using Microsoft.EntityFrameworkCore;

namespace Shop.Dal
{
    public abstract class BaseDataBaseRepository<T, TContext> : IRepository<T>
        where T : class, IPrimary, new()
        where TContext : DbContext
    {
        protected TContext Context;
        protected BaseDataBaseRepository(TContext context)
        {
            Context = context;
        }
        public virtual void Create(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }
        public virtual T Read(int id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id)!;
        }
        public virtual List<T> ReadAll()
        {
            return Context.Set<T>().ToList();
        }
        public virtual void Update(T item)
        {
            Context.Set<T>().Update(item);
            Context.SaveChanges();
        }
        public virtual void Delete(int id)
        {
            var entity = Read(id);
            if (entity != null)
            {
                Context.Set<T>().Remove(entity);
                Context.SaveChanges();
            }
        }
    }
}