using FruitStore.Domain.Enums;
using Torc.Challenge.Application.Interfaces.Services.Standard;
using Torc.Challenge.Domain.DTOs.Book;
using Torc.Challenge.Domain.Entities;
using Torc.Challenge.Domain.Utility;

namespace Torc.Challenge.Application.Interfaces.Services
{
    public interface IBookService : IServiceBase<Book>
    {
        Pagination<BookDto> Get();
        Pagination<BookDto> GetByFilter(SearchBookEnum option, string value);
        void Add(NewBookDto dto);
        void Update(int bookId, EditBookDto dto);
    }
}
