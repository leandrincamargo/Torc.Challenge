using FruitStore.Domain.Enums;
using Torc.Challenge.Application.Interfaces.Services;
using Torc.Challenge.Application.Services.Standard;
using Torc.Challenge.Domain.DTOs.Book;
using Torc.Challenge.Domain.Entities;
using Torc.Challenge.Domain.Utility;
using Torc.Challenge.Infrastructure.Interfaces.Repositories.Domain;

namespace Torc.Challenge.Application.Services
{
    public class BookService : ServiceBase<Book>, IBookService
    {
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Pagination<BookDto> Get()
        {
            return _repository.GetAll();
        }

        public Pagination<BookDto> GetByFilter(SearchBookEnum option, string value)
        {
            return _repository.GetByFilter(option, value);
        }

        public void Add(NewBookDto dto)
        {
            var newBook = (Book)dto;
            base.Add(newBook);
        }

        public void Update(int bookId, EditBookDto dto)
        {
            var book = base.GetById(bookId);
            book.FirstName = dto.FirstName;
            book.LastName = dto.LastName;
            book.TotalCopies = dto.TotalCopies;
            book.CopiesInUse = dto.CopiesInUse;

            base.Update(book);
        }
    }
}
