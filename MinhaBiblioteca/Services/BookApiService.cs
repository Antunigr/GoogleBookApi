using MinhaBiblioteca.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MinhaBiblioteca.Services
{
    public class BookApiService
    {
        public async Task<BookApi>getNameBooks(string BookName)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={BookName}&key=AIzaSyCKyn2BShRjT4lzW7SxdXMcBhlnLdFb3G4");
            var jsonString = await response.Content.ReadAsStringAsync();

            BookApi jsonObject = JsonConvert.DeserializeObject<BookApi>(jsonString);

            return jsonObject;
        }
    }
}
