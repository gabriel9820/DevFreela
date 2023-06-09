namespace DevFreela.Core.Models
{
    public class PaginationResult<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PaginationResult() { }

        public PaginationResult(int currentPage, int totalPages, int pageSize, int totalCount, List<T> data)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalCount = totalCount;
            Data = data;
        }
    }
}
