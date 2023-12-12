using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;

namespace TranHuuTri.Assignment02.ODataBookStoreWebClient.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly HttpClient client = null;
        private string AuthorApiUrl = "";
        private string AuthorApiNotUsingOdata = "";
        public AuthorsController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            AuthorApiUrl = "https://localhost:7237/odata/Authors";
            AuthorApiNotUsingOdata = "https://localhost:7237/api/Authors";
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
                response = await client.GetAsync(AuthorApiUrl + $"?PageNumber={pageNumber}&PageSize={pageSize}");
            }
            else
            {
                response = await client.GetAsync(AuthorApiUrl + $"?SearchTerm={searchTerm}&PageNumber={pageNumber}&PageSize={pageSize}");
            }
            //= await client.GetAsync(AuthorApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var list = temp.value;
            IEnumerable<AuthorVM> items = ((JArray)list).Select(x => new AuthorVM
            {
                Id = (int)x["Id"],
                LastName = (string)x["LastName"],
                FirstName = (string)x["FirstName"],
                Phone = (int)x["Phone"],
                Address = (string)x["Address"],
                City = (string)x["City"],
                State = (int)x["State"],
                Zip = (int)x["Zip"],
                EmailAddress = (string)x["EmailAddress"],
            }).ToList();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorRequest auth)
        {
            if (ModelState.IsValid)
            {
                string authJson = JsonConvert.SerializeObject(auth);
                var content = new StringContent(authJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(AuthorApiNotUsingOdata + "/AddAuthor", content);

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
            return View(auth);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                AuthorRequest auth = new AuthorRequest();
                HttpResponseMessage response = client.GetAsync(AuthorApiNotUsingOdata + "/GetAuthorById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    auth = JsonConvert.DeserializeObject<AuthorRequest>(data);
                }
                return View(auth);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(AuthorRequest authRequest, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(authRequest);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(AuthorApiNotUsingOdata + "/UpdatAuthor/" + id, content).Result;
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
                AuthorVM auth = new AuthorVM();
                HttpResponseMessage response = client.GetAsync(AuthorApiNotUsingOdata + "/GetAuthorById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    auth = JsonConvert.DeserializeObject<AuthorVM>(data);
                }
                return View(auth);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(AuthorVM authorVM, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(authorVM);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(AuthorApiNotUsingOdata + "/DeleteAuthor/" + id, content).Result;
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
