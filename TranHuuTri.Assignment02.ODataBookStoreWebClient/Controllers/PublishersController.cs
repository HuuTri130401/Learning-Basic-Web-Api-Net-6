using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Publisher;

namespace TranHuuTri.Assignment02.ODataBookStoreWebClient.Controllers
{
    public class PublishersController : Controller
    {
        private readonly HttpClient client = null;
        private string PublisherApiUrl = "";
        private string PublisherApiUrlNotUseOdata = "";

        public PublishersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PublisherApiUrl = "https://localhost:7237/odata/Publishers";
            PublisherApiUrlNotUseOdata = "https://localhost:7237/api/Publishers";
        }

        public async Task<IActionResult> Index(string searchTerm, int pageNumber, int pageSize)
            {
            HttpResponseMessage response;
            //= await client.GetAsync(PublisherApiUrl);
            if (pageSize == 0)
            {
                pageSize = 5;
            }
            if (string.IsNullOrEmpty(searchTerm))
            {
                response = await client.GetAsync(PublisherApiUrl + $"?PageNumber={pageNumber}&PageSize={pageSize}");
            }
            else
            {
                response = await client.GetAsync(PublisherApiUrl + $"?SearchTerm={searchTerm}&PageNumber={pageNumber}&PageSize={pageSize}");
            }

            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);
            var list = temp.value;

            IEnumerable<PublisherVM> items = ((JArray)list).Select(x => new PublisherVM
            {
                Id = (int)x["Id"],
                PublisherName = (string)x["PublisherName"],
                City = (string)x["City"],
                State = (int)x["State"],
                Country = (string)x["Country"],
            }).ToList();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublisherRequest pub)
        {
            if (ModelState.IsValid)
            {
                string pubJson = JsonConvert.SerializeObject(pub);
                var content = new StringContent(pubJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(PublisherApiUrlNotUseOdata + "/AddPublisher", content);

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
            return View(pub);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                PublisherRequest pub = new PublisherRequest();
                HttpResponseMessage response = client.GetAsync(PublisherApiUrlNotUseOdata + "/GetPublisherById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    pub = JsonConvert.DeserializeObject<PublisherRequest>(data);
                }
                return View(pub);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(PublisherRequest publisherRequest, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(publisherRequest);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(PublisherApiUrlNotUseOdata + "/UpdatePublisher/" + id, content).Result;
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
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                PublisherVM pub = new PublisherVM();
                HttpResponseMessage response = client.GetAsync(PublisherApiUrlNotUseOdata + "/GetPublisherById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    pub = JsonConvert.DeserializeObject<PublisherVM>(data);
                }
                return View(pub);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(PublisherVM publisherVM, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(publisherVM);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(PublisherApiUrlNotUseOdata + "/DeletePublisher/" + id, content).Result;
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
    }
}
