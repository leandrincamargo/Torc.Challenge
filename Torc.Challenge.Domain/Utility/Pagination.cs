namespace Torc.Challenge.Domain.Utility
{
    public class Pagination<T>
    {
        public IEnumerable<T> Items { get; private set; }
        public int PageCount { get; private set; }
        public int TotalItemCount { get; private set; }
        public int PageSize { get; private set; }
        public int CurrentPage { get; private set; }

        public Pagination(IEnumerable<T> items, int totalItemCount, int pageSize, int currentPage)
        {
            Items = items;
            PageCount = CalculatePageSize(totalItemCount, pageSize);
            TotalItemCount = totalItemCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }

        public static int CalculateSkipNumber(int pageNumber, int pageSize)
        {
            return pageNumber * pageSize;
        }

        private int CalculatePageSize(int totalItemCount, int pageSize)
        {
            return (int)Math.Ceiling((double)totalItemCount / pageSize);
        }
    }
}
