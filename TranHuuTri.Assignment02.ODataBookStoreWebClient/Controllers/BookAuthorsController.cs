using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.BookAuthor;

namespace TranHuuTri.Assignment02.ODataBookStoreWebClient.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly HttpClient client = null;
        private string BookAuthorApiUrl = "";

        public BookAuthorsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            //BookAuthorApiUrl = "https://localhost:7237/odata/BookAuthors";
            BookAuthorApiUrl = "https://localhost:7237/odata/BookAuthors";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(BookAuthorApiUrl + "?$expand=Book,Author");
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var list = temp.value;
            IEnumerable<BookAuthorVM> items = ((JArray)list).Select(x => new BookAuthorVM
            {
                Id = (int)x["Id"],
                AuthorId = (int)x["AuthorId"],
                BookId = (int)x["BookId"],
                AuthorOrder = (string?)x["AuthorOrder"],
                RoyalityPercentage = (int?)x["RoyalityPercentage"],
                Status = (int)x["Status"],
                Author = new AuthorVM
                {
                    Id = (int)x["Author"]["Id"],
                    LastName = (string)x["Author"]["LastName"],
                    FirstName = (string)x["Author"]["FirstName"],
                    Phone = (int)x["Author"]["Phone"],
                    Address = (string)x["Author"]["Address"],
                    City = (string)x["Author"]["City"],
                    State = (int)x["Author"]["State"],
                    Zip = (int)x["Author"]["Zip"],
                    EmailAddress = (string)x["Author"]["EmailAddress"]
                },

                Book = new BookVM
                {
                    Id = (int)x["Book"]["Id"],
                    Title = (string)x["Book"]["Title"],
                    Type = (string)x["Book"]["Type"],
                    PubId = (int)x["Book"]["PubId"],
                    Price = (decimal)x["Book"]["Price"],
                    Advance = (string)x["Book"]["Advance"],
                    Royalty = (string)x["Book"]["Royalty"],
                    Notes = (string)x["Book"]["Notes"],
                    PublishedDate = (DateTime)x["Book"]["PublishedDate"],
                    Status = (int)x["Book"]["Status"],
                    PublisherName = (string?)x["Book"]["PublisherName"],
                }
            }).ToList();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookByAuthorId(int id)
        {
        ////https://localhost:7237/odata/BookAuthors?$expand=Book&$filter=AuthorId eq 
            HttpResponseMessage response = await client.GetAsync(BookAuthorApiUrl + "?$expand=Book&$filter=AuthorId eq " + id);
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var list = temp.value;
            IEnumerable<BookAuthorVM> items = ((JArray)list).Select(x => new BookAuthorVM
            {
                Id = (int)x["Id"],
                AuthorId = (int)x["AuthorId"],
                BookId = (int)x["BookId"],
                AuthorOrder = (string?)x["AuthorOrder"],
                RoyalityPercentage = (int?)x["RoyalityPercentage"],
                Status = (int)x["Status"],
                Book = new BookVM
                {
                    Id = (int)x["Book"]["Id"],
                    Title = (string)x["Book"]["Title"],
                    Type = (string)x["Book"]["Type"],
                    PubId = (int)x["Book"]["PubId"],
                    Price = (decimal)x["Book"]["Price"],
                    Advance = (string)x["Book"]["Advance"],
                    Royalty = (string)x["Book"]["Royalty"],
                    Notes = (string)x["Book"]["Notes"],
                    PublishedDate = (DateTime)x["Book"]["PublishedDate"],
                    Status = (int)x["Book"]["Status"],
                    PublisherName = (string?)x["Book"]["PublisherName"],
                }
            }).ToList();
            return View(items);
        }
    }
}
