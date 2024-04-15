using FruitStore.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Torc.Challenge.Application.Interfaces.Services;
using Torc.Challenge.Application.Validations;
using Torc.Challenge.Domain.DTOs.Book;
using Torc.Challenge.Domain.Utility;

namespace Torc.Challenge.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pagination<BookDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(SearchBookEnum? field = null, string value = "")
        {
            try
            {
                Pagination<BookDto> books;
                if (field == null || string.IsNullOrWhiteSpace(value))
                    books = _bookService.Get();
                else
                    books = _bookService.GetByFilter(field.Value, value);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] NewBookDto dto)
        {
            try
            {
                var validRes = new NewBookDtoValidation().Validate(dto);
                if (!validRes.IsValid)
                    return BadRequest(validRes.Errors);

                _bookService.Add(dto);
                return Created("", null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int bookId, [FromBody] EditBookDto dto)
        {
            try
            {
                var validRes = new EditBookDtoValidation().Validate(dto);
                if (!validRes.IsValid)
                    return BadRequest(validRes.Errors);
                if (_bookService.GetById(bookId) == null)
                    return BadRequest("Book not found");

                _bookService.Update(bookId, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int bookId)
        {
            try
            {
                if (_bookService.GetById(bookId) == null)
                    return BadRequest("Book not found");

                _bookService.Remove(bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
