namespace Search.Api.Search
{
    public class SearchResponse
    {
        public IEnumerable<Device> Devices { get; set; }

        public int TotalDeviceCount { get; set; }

        public int PageNumber { get; set; }
    }
}
