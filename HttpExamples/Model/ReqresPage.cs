using Newtonsoft.Json;

namespace HttpExamples.Model
{
    public class ReqresPage
    {
        public int Pages { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public ReqresUser[] Data { get; set; }
    }
}
