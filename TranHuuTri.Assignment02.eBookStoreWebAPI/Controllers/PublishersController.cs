using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Book;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.User;
using TranHuuTri.Assignment02.eBookStoreWebAPI.ViewModels.Publisher;
using TranHuuTri.Assignment02.Repositories.Entities;
using TranHuuTri.Assignment02.Services;
using TranHuuTri.Assignment02.Repositories.RequestFeatures;

namespace TranHuuTri.Assignment02.eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;

        public PublishersController(IPublisherService publisherService, IMapper mapper)
        {
            _publisherService = publisherService;
            _mapper = mapper;
        }

        //[EnableQuery]
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var listPublishers = _publisherService.GetAllPublishers();
        //    var listResponse = _mapper.Map<List<PublisherVM>>(listPublishers);
        //    return Ok(listResponse);
        //}

        [EnableQuery]
        [HttpGet]
        public IQueryable<PublisherVM> Get([FromQuery] PublisherParameters publisherParameters)
        {
            var listPublishers = _publisherService.GetAllPublishers(publisherParameters);
            var listResponse = _mapper.Map<List<PublisherVM>>(listPublishers);
            return listResponse.AsQueryable();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if (publisher == null)
            {
                return NotFound();
            }
            var publisherVM = _mapper.Map<PublisherVM>(publisher);
            return Ok(publisherVM);
        }

        [HttpPost]
        public IActionResult AddPublisher(PublisherRequest publisherRequest)
        {
            var publisher = _mapper.Map<Publisher>(publisherRequest);
            _publisherService.CreatePublisher(publisher);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, PublisherRequest publisherRequest)
        {
            var existingPublisher = _publisherService.GetPublisherById(id);
            if (existingPublisher == null)
            {
                return NotFound();
            }
            var publisher = _mapper.Map<Publisher>(publisherRequest);
            publisher.Id = id;
            _publisherService.UpdatePublisher(publisher);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            var existingPublisher = _publisherService.GetPublisherById(id);
            if (existingPublisher == null)
            {
                return NotFound();
            }
            _publisherService.DeletePublisher(id);
            return Ok();
        }
    }
}
