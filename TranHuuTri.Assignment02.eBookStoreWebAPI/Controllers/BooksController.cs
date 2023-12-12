using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;
using TranHuuTri.Assignment02.Services;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable<BookVM> Get([FromQuery] BookParameters bookParameters)
        {
            var listBooks = _bookService.GetAllBooks(bookParameters);
            var listResponse = new List<BookVM>();

            foreach (var book in listBooks)
            {
                var bookVM = _mapper.Map<BookVM>(book);

                if (book.Pub != null)
                {
                    bookVM.PublisherName = book.Pub.PublisherName;
                }
                listResponse.Add(bookVM);
            }
            return listResponse.AsQueryable();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookVM = _mapper.Map<BookVM>(book);
            bookVM.PublisherName = book.Pub?.PublisherName;
            return Ok(bookVM);
        }

        [EnableQuery]
        [HttpGet("Publisher/{publisherId}")]
        public IQueryable<BookVM> GetBooksByPublisherId(int publisherId)
        {
            var listBooks = _bookService.GetBooksByPublisherId(publisherId);
            var listBookVM = new List<BookVM>();

            foreach (var book in listBooks)
            {
                var bookVM = _mapper.Map<BookVM>(book);

                if (book.Pub != null)
                {
                    bookVM.PublisherName = book.Pub.PublisherName;
                }
                listBookVM.Add(bookVM);
            }
            return listBookVM.AsQueryable();
        }

        [HttpPost]
        public IActionResult AddBook(BookRequest bookRequest)
        {
            var book = _mapper.Map<Book>(bookRequest);
            _bookService.CreateBook(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookRequest bookRequest)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            var book = _mapper.Map<Book>(bookRequest);
            book.Id = id;
            _bookService.UpdateBook(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            _bookService.DeleteBook(id);
            return Ok();
        }
    }
}
