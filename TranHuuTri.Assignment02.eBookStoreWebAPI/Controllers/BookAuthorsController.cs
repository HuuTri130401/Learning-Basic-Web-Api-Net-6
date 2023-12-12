using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.BookAuthor;
using TranHuuTri.Assignment02.Services;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private readonly IBookAuthorService _bookAuthorService;
        private readonly IMapper _mapper;

        public BookAuthorsController(IBookAuthorService bookAuthorService, IMapper mapper)
        {
            _bookAuthorService = bookAuthorService;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable<BookAuthorVM> Get()
        {
            var listBookAuths = _bookAuthorService.GetAllBookAuthors();
            var listResponse = _mapper.Map<List<BookAuthorVM>>(listBookAuths);
            return listResponse.AsQueryable();
        }

        [HttpGet("authorId")]
        public IActionResult GetBookAuthorsByAuthorId(int authorId)
        {
            var listBookAuths = _bookAuthorService.GetBookAuthorsByAuthorId(authorId);
            var listResponse = _mapper.Map<List<BookAuthorVM>>(listBookAuths);
            return Ok(listResponse);
        }

        [HttpGet("bookId")]
        public IActionResult GetBookAuthorsByBookId(int bookId)
        {
            var listBookAuths = _bookAuthorService.GetBookAuthorsByBookId(bookId);
            var listResponse = _mapper.Map<List<BookAuthorVM>>(listBookAuths);
            return Ok(listResponse);
        }
    }
}
