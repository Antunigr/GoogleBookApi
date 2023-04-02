using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MinhaBiblioteca.Models;
using Newtonsoft.Json;
using System.Net;
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
                    titulo = item.volumeInfo.title,
                    linkImg = item.volumeInfo.imageLinks?.thumbnail ?? "https://savanisbookshop.com/uploads/image/savanisbookshop.jpeg",
                    descricao = item.volumeInfo.description,
                    idBook = item.id

                };
                books.Add(book);
            }

            return books;
        }


        public async Task<List<BookApi>> GetDescriptionBook(string? BookId)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={BookId}&key=AIzaSyCKyn2BShRjT4lzW7SxdXMcBhlnLdFb3G4");
            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<RootObject>(jsonString);
            var books = new List<BookApi>();

            foreach (var item in jsonObject.items)
            {

                if(item.saleInfo.listPrice != null)
                {
                    var book = new BookApi
                    {
                        autor = item.volumeInfo.authors != null ? item.volumeInfo.authors[0] : null,
                        titulo = item.volumeInfo.title,
                        linkImg = item.volumeInfo.imageLinks?.thumbnail ?? "https://savanisbookshop.com/uploads/image/savanisbookshop.jpeg",
                        descricao = item.volumeInfo.description,
                        editora = item.volumeInfo.publisher,
                        dataEdicao = item.volumeInfo.publishedDate,
                        categoria = item.volumeInfo.categories != null ? item.volumeInfo.categories[0] : null,
                        paginas = item.volumeInfo.pageCount,
                        pais = item.saleInfo.country ?? "pais nao encontrada" ,
                        disponivel = item.saleInfo.saleability ?? "nao a venda",
                        Ebook = item.saleInfo.isEbook ?? false,
                        preco = item.saleInfo.listPrice?.amount ?? 0.00,
                        moeda = item.saleInfo.listPrice.currencyCode ?? "BRL" ,
                    };
                    books.Add(book);
                }
                else {
                    var book = new BookApi
                    {
                        autor = item.volumeInfo.authors != null ? item.volumeInfo.authors[0] : null,
                        titulo = item.volumeInfo.title,
                        linkImg = item.volumeInfo.imageLinks?.thumbnail ?? "https://savanisbookshop.com/uploads/image/savanisbookshop.jpeg",
                        descricao = item.volumeInfo.description,
                        editora = item.volumeInfo.publisher,
                        dataEdicao = item.volumeInfo.publishedDate,
                        categoria = item.volumeInfo.categories != null ? item.volumeInfo.categories[0] : null,
                        paginas = item.volumeInfo.pageCount,
                        pais = "pais nao encontrada",
                        disponivel = "nao a venda",
                        Ebook =  false,
                        preco = 0.00,
                        moeda =  "BRL",
                    };
                    books.Add(book);
                }
             
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
        public string id { get;  set; }
        public SaleInfo? saleInfo { get; set; }

    }
    public class VolumeInfo
    {
        public string publishedDate { get; set; }

        public string title { get; set; }
        public List<string> authors { get; set; }

        public ImageLinks? imageLinks { get; set; }

        public string description { get; set; }

        public string publisher { get; set; }

        public List<string> categories { get; set; }

        public int pageCount { get; set; }
      
    }
    public class SaleInfo
    {
        public string? country { get; set; }
        public string? saleability { get; set; }
        public bool? isEbook { get; set; }
        public ListPrice? listPrice { get; set; }
    }

    public class ListPrice
    {
        public double? amount { get; set; }
        public string? currencyCode { get; set; }
    }

    public class ImageLinks
        {
            public string? thumbnail { get; set; }
        }

      
}

    