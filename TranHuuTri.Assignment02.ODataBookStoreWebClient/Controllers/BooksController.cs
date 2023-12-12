using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Publisher;
using TranHuuTri.Assignment02.Repositories.Entities;

namespace TranHuuTri.Assignment02.ODataBookStoreWebClient.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient client;
        private string BookOdataApiUrl = "";
        private string BookApiUrl = "";
        private string PublisherApiUrl = "";

        public BooksController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            BookOdataApiUrl = "https://localhost:7237/odata/Books";
            BookApiUrl = "https://localhost:7237/api/Books";
            PublisherApiUrl = "https://localhost:7237/odata/Publishers";
        }

        public async Task<IActionResult> Index(string searchTerm, int pageNumber, int pageSize)
        {
            HttpResponseMessage response;
            if (pageSize == 0)
            {
                pageSize = 5;
            }
            if (string.IsNullOrEmpty(searchTerm))
            {
                response = await client.GetAsync(BookOdataApiUrl + $"?PageNumber={pageNumber}&PageSize={pageSize}");
            }
            else
            {
                response = await client.GetAsync(BookOdataApiUrl + $"?SearchTerm={searchTerm }&PageNumber={pageNumber}&PageSize={pageSize}");
            }

            //response = await client.GetAsync(BookOdataApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);
            var list = temp.value;

            IEnumerable<BookVM> items = ((JArray)list).Select(x => new BookVM
            {
                Id = (int)x["Id"],
                Title = (string)x["Title"],
                Type = (string)x["Type"],
                PubId = (int)x["PubId"],
                Price = (decimal)x["Price"],
                Advance = (string)x["Advance"],
                Royalty = (string)x["Royalty"],
                Notes = (string)x["Notes"],
                PublishedDate = (DateTime)x["PublishedDate"],
                Status = (int)x["Status"],
                PublisherName = (string)x["PublisherName"],
            }).ToList();
                ViewData["PageNumber"] = pageNumber;
                ViewData["PageSize"] = pageSize;
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookRequest book)
        {
            if (ModelState.IsValid)
            {
                string bookJson = JsonConvert.SerializeObject(book);
                var content = new StringContent(bookJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(BookApiUrl + "/AddBook", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Create Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Create Error!";
                    return View();
                }
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                BookRequest book = new BookRequest();
                HttpResponseMessage response = client.GetAsync(BookApiUrl + "/GetBookById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<BookRequest>(data);
                }
                return View(book);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(BookRequest bookRequest, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(bookRequest);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(BookApiUrl + "/UpdateBook/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Update Successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }   
            return View();
        }

        [HttpGet]
        public IActionResult DeleteConfired(int id)
        {
            try
            {
                BookVM book = new BookVM();
                HttpResponseMessage response = client.GetAsync(BookApiUrl + "/GetBookById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<BookVM>(data);
                }
                return View(book);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteConfired(BookVM bookVM, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(bookVM);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(BookApiUrl + "/DeleteBook/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "InActive Successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        //private async Task LoadDropDownList()
        //{
        //    HttpResponseMessage responsePublisher = await client.GetAsync(PublisherApiUrl);
        //    string strData = await responsePublisher.Content.ReadAsStringAsync();
        //    dynamic tempPublisher = JObject.Parse(strData);
        //    var listPublisher = tempPublisher.value;
        //    List<PublisherVM> itemsPublisher = ((JArray)tempPublisher.value).Select(
        //        x => new PublisherVM
        //        {
        //            Id = (int)x["Id"],
        //            PublisherName = (string)x["PublisherName"],
        //            City = (string)x["City"],
        //            State = (int)x["State"],
        //            Country = (string)x["Country"],
        //        }).ToList();
        //    ViewBag.Publishers = itemsPublisher;
        //}
    }
}
