using NSGE.CrossCutting.CustomGrid;

namespace NSGE.CrossCutting.Service
{
    public interface IService<T> where T : class
    {
        void Delete(string id);

        void Delete(T item);

        void Delete(T item, bool saveChanges);

        void Insert(T item);

        void Insert(T item, bool saveChanges);

        IList<T> List();

        CustomGridDataSource<T> ListPaged(int? page, string property = null, string order = null, string method = null);

        T Load(string id);

        IList<string> NonEntitySqlQuery(string sql);

        void Update(T item);

        void Update(T item, bool saveChanges);

        void Update(T entity, params string[] propertiesToIgnore);

        void Update(T entity, bool saveChanges, params string[] propertiesToIgnore);
    }
}