using Newtonsoft.Json;
namespace HttpExamples.Model
{
    public class PostUser1
    {

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
