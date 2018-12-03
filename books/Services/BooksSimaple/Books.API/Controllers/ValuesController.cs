using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Application.Commands;
using Books.Domain.AggregatedModel.AggragatedAutor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IMediator _mediator;
        IAuthorRepository _repository;
        public ValuesController(IMediator mediator, IAuthorRepository repository) {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet("Start")]
        public async Task<ActionResult<bool>> Start()
        {
            var command = new AddNewAuthorCommand("Moshe", new List<Book>() { new Book("book1"), new Book("book2") });
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpGet("Start2")]
        public async Task<ActionResult<bool>> Start2()
        {
            var command = new AddNewAuthorCommand("Moshe2", new List<Book>() { new Book("book3"), new Book("book4") });
            var result = await _mediator.Send(command);
            return result;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var val = await _repository.GetAsync();

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
