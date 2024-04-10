using NSGE.CrossCutting.BaseEntity;
using NSGE.CrossCutting.CustomGrid;
using NSGE.CrossCutting.Service;

namespace NSGE.CrosCutting.Service
{
    public abstract class BaseService<T> : IService<T> where T : EntityBase
    {
        
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item, bool saveChanges)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(T item, bool saveChanges)
        {
            throw new NotImplementedException();
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