namespace Search.Api.Search
{
    public class Device
    {
        public string Id { get; set; }
        public string DisplayModel { get; set; }
        public string FriendlyName { get; set; }
        public string Name { get; set; }
        public int? CorpLiable { get; set; }
        public string OSVersion { get; set; }
        public int? DeviceType { get; set; }
    }
}