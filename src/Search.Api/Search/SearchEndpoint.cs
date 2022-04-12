using FastEndpoints;

namespace Search.Api.Search
{
    public class SearchEndpoint : Endpoint<SearchRequest, SearchResponse>
    {
        public SearchEndpoint()
        {
            
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/api/search");
            AllowAnonymous();
        }

        public override Task HandleAsync(SearchRequest req, CancellationToken ct)
        {
            var response = new SearchResponse();

            return SendAsync(response);
        }
    }
}
