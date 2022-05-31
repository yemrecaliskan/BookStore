using AutoMapper;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStoreWebAPI.Application.AuthorOperations.Queries.GetAuthorsQuery;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;

namespace BookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController( IMapper mapper, BookStoreDbContext context )
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorDetail( int id )
        {
            GetAuthorDetailQuery query = new(_context, _mapper);
            query.AuthorId = id;

            GetAuthorDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);

            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor( [FromBody] CreateAuthorModel newAuthor )
        {
            CreateAuthorCommand command = new(_context, _mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor( int id, [FromBody] UpdateAuthorCommandModel updatedAuthor )
        {
            UpdateAuthorCommand command = new(_context);
            command.Model = updatedAuthor;
            command.AuthorId = id;
            UpdateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor( int id )
        {
            DeleteAuthorCommand command = new(_context, _mapper);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}