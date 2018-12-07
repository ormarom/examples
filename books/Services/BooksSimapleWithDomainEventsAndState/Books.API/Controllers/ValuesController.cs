using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Application.Commands;
using Books.Domain.AggregatedModel.AggragatedAutor;
using Books.Domain.AggregatedModel.AggragatedPublisher;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IMediator _mediator;
        IAuthorRepository _authorRepository;
        IPublisherRepository _publisherRepository;
        public ValuesController(IMediator mediator, IAuthorRepository authorRepository, IPublisherRepository publisherRepository) {
            _mediator = mediator;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        [HttpGet("Start")]
        public async Task<ActionResult<bool>> Start()
        {
            var command = new AddNewAuthorCommand("Moshe", new List<Book>() { new Book("book1", "publisherAAA"), new Book("book2", "publisherBBB"), new Book("book5", "") });
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpGet("Start2")]
        public async Task<ActionResult<bool>> Start2()
        {
            var command = new AddNewAuthorCommand("Moshe2", new List<Book>() { new Book("book3", "publisherBBB"), new Book("book4", "publisherBBB") });
            var result = await _mediator.Send(command);
            return result;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var authors = await _authorRepository.GetAsync();
            var publishers = await _publisherRepository.GetAsync();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
