using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Author;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;
using TranHuuTri.Assignment02.Services;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult Get([FromQuery] AuthorParameters authorParameters)
        {
            var listAuthors = _authorService.GetAllAuthors(authorParameters);
            var listResponse = _mapper.Map<List<AuthorVM>>(listAuthors);

            return Ok(listResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            var authorVM = _mapper.Map<AuthorVM>(author);
            return Ok(authorVM);
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorRequest authorRequest)
        {
            var author = _mapper.Map<Author>(authorRequest);
            _authorService.CreateAuthor(author);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatAuthor(int id, AuthorRequest authorRequest)
        {
            var existingAuthor = _authorService.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            var author = _mapper.Map<Author>(authorRequest);
            author.Id = id;
            _authorService.UpdateAuthor(author);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var existingAuthor = _authorService.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }
            _authorService.DeleteAuthor(id);
            return Ok();
        }
    }
}
