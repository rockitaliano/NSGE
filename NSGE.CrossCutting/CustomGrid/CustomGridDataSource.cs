namespace NSGE.CrossCutting.CustomGrid
{
    public class CustomGridDataSource<T> where T : class
    {
        public CustomGridDataSource()
        { }

        public CustomGridDataSource(IEnumerable<T> query, int? page, string property = null, string order = null, string method = null, int pageSize = 10, bool dontDefaultOrder = false)
        {
            setPage(page ?? 1);
            setPageSize(pageSize);
            PropertyGrouped = property;

            // Você pode ajustar a forma como os registros são paginados com Dapper.
            Records = query.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();

            // Você pode também considerar como calcular o TotalRecords usando Dapper.
            TotalRecords = query.Count();
        }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalRecords { get; set; }
        public ICollection<T> Records { get; set; }
        public bool HasRecords => Records?.Count > 0;
        public string PropertyGrouped { get; set; }

        public void setPage(int page)
        {
            // Ensure that the page number is not less than 1.
            PageNumber = page > 0 ? page : 1;
        }

        public void setPageSize(int size = 20)
        {
            // Ensure that the page size is not less than 1.
            PageSize = size > 0 ? size : 20;
        }

        public void setRecords(ICollection<T> records)
        {
            // If you need to set the records externally, you can use this method.
            Records = records;
        }
    }
}