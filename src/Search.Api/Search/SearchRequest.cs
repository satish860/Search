namespace Search.Api.Search
{
    public class SearchRequest
    {
        public string q { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
