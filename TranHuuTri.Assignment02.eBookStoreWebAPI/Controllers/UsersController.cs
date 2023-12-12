using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;
using TranHuuTri.Assignment02.Services;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable<UserVM> Get([FromQuery] UserParameters userParameters)
        {
            var listUsers = _userService.GetAllUsers(userParameters);
            var listResponse = new List<UserVM>();

            foreach (var user in listUsers)
            {
                var userVM = _mapper.Map<UserVM>(user);

                if (user.Pub != null)
                {
                    userVM.PubName = user.Pub.PublisherName;
                    userVM.RoleName = user.Role.RoleDesc;
                }
                listResponse.Add(userVM);
            }
            return listResponse.AsQueryable();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userVM = _mapper.Map<UserVM>(user);
            userVM.PubName = user.Pub?.PublisherName;
            userVM.RoleName = user.Role?.RoleDesc;
            return Ok(userVM);
        }

        [HttpPost]
        public IActionResult AddUser(UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            _userService.CreateUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserRequest userRequest)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            var user = _mapper.Map<User>(userRequest);
            user.Id = id;
            _userService.UpdateUser(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}
