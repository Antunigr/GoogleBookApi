using MinhaBiblioteca.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MinhaBiblioteca.Services
{
    public class BookApiService
    {
        public async Task<List<BookApi>>GetBookName(string? BookName)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={BookName}&key=AIzaSyCKyn2BShRjT4lzW7SxdXMcBhlnLdFb3G4");
            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<RootObject>(jsonString);
            var books = new List<BookApi>();

            foreach (var item in jsonObject.items)
            {
                var book = new BookApi
                {
                    autor = item.volumeInfo.authors != null ? item.volumeInfo.authors[0] : null,
                    titulo = item.volumeInfo.title
                };
                books.Add(book);
            }

            return books;
        }
    }

    public class RootObject
    {
        public List<Item> items { get; set; }
    }

    public class Item
    {
        public VolumeInfo volumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string title { get; set; }
        public List<string> authors { get; set; }
    }

}
