using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User;

namespace TranHuuTri.Assignment02.ODataBookStoreWebClient.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient client = null;
        private string UserOdataApiUrl = "";
        private string UserApiUrl = "";

        public UsersController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserOdataApiUrl = "https://localhost:7237/odata/Users";
            UserApiUrl = "https://localhost:7237/api/Users";
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
                response = await client.GetAsync(UserOdataApiUrl + $"?PageNumber={pageNumber}&PageSize={pageSize}");
            }
            else
            {
                response = await client.GetAsync(UserOdataApiUrl + $"?SearchTerm={searchTerm}&PageNumber={pageNumber}&PageSize={pageSize}");
            }

            //HttpResponseMessage response = await client.GetAsync(UserOdataApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            dynamic temp = JObject.Parse(strData);
            var list = temp.value;
            IEnumerable<UserVM> items = ((JArray)list).Select(x => new UserVM
            {
                Id = (int)x["Id"],
                Email = (string)x["Email"],
                LastName = (string)x["LastName"],
                FirstName = (string)x["FirstName"],
                Status = (int)x["Status"],
                PubId = (int)x["PubId"],
                PubName = (string)x["PubName"],
                RoleId = (int)x["RoleId"],
                RoleName = (string)x["RoleName"],
            }).ToList();
            return View(items);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest user)
        {
            if (ModelState.IsValid)
            {
                string userJson = JsonConvert.SerializeObject(user);
                var content = new StringContent(userJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(UserApiUrl + "/AddUser", content);

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
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                UserRequest user = new UserRequest();
                HttpResponseMessage response = client.GetAsync(UserApiUrl + "/GetUserById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<UserRequest>(data);
                }
                return View(user);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(UserRequest userRequest, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(userRequest);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(UserApiUrl + "/UpdateUser/" + id, content).Result;
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
                UserVM book = new UserVM();
                HttpResponseMessage response = client.GetAsync(UserApiUrl + "/GetUserById/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<UserVM>(data);
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
        public IActionResult DeleteConfirmed(UserVM userVM, int id)
        {
            try
            {
                string data = JsonConvert.SerializeObject(userVM);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(UserApiUrl + "/DeleteUser/" + id, content).Result;
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
