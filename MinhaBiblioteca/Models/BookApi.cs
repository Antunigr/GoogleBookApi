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

        [JsonProperty("publishedDate")]
        public string dataPublicacao { get; set; }

        [JsonProperty("imageLinks")]
        public string linkImg { get;set; }

        [JsonProperty("description")]
        public string descricao { get; set; }

        [JsonProperty("id")]
        public string idBook { get; set; }

        [JsonProperty("publisher")]
        public string editora { get;set; }

        [JsonProperty("publishedDate")]
        public string dataEdicao { get; set; }

        [JsonProperty("categories")]
        public string categoria { get; set; }

        [JsonProperty("pageCount")]
        public int paginas { get; set; }


    }
}
