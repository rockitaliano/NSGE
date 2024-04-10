using NSGE.CrossCutting.BaseEntity;
using NSGE.CrossCutting.CustomGrid;
using NSGE.Infrastructure.Context.Interface;

namespace NSGE.Services.Services
{
    public abstract class BaseService<T> : IService<T> where T : EntityBase
    {
        private readonly IDapperContext _context;

        public BaseService(IDapperContext context)
        {
            _context = context;
        }
        public void Delete(string id)
        {
            Delete(id);
        }

        public void Delete(T item)
        {
            Delete(item.Id);
        }

        public void Delete(T item, bool saveChanges)
        {
            Delete(item, saveChanges);
        }

        public void Insert(T item)
        {
            //_context.Insert(item);
        }

        public void Insert(T item, bool saveChanges)
        {
            Insert(item);
            if (saveChanges)
            {
                _context.CreateConnection();
                
            }
        }

        public IList<T> List()
        {
            throw new NotImplementedException();
        }

        public CustomGridDataSource<T> ListPaged(int? page, string property = null, string order = null, string method = null)
        {
            throw new NotImplementedException();
        }

        public T Load(string id)
        {
            throw new NotImplementedException();
        }

        public IList<string> NonEntitySqlQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item, bool saveChanges)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity, params string[] propertiesToIgnore)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity, bool saveChanges, params string[] propertiesToIgnore)
        {
            throw new NotImplementedException();
        }
    }
}