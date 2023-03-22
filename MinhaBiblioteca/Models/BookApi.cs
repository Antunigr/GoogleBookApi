using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MinhaBiblioteca.Models
{
    public class BookApi
    {
        [JsonProperty("title")]
        public string titulo { get; set; }

        [JsonProperty("authors")]
        public string autor { get; set; }
    }
}
