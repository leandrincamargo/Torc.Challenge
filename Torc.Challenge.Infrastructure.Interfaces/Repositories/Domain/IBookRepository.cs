using FruitStore.Domain.Enums;
using Torc.Challenge.Domain.DTOs.Book;
using Torc.Challenge.Domain.Entities;
using Torc.Challenge.Domain.Utility;
using Torc.Challenge.Infrastructure.Interfaces.Repositories.Domain.Standard;

namespace Torc.Challenge.Infrastructure.Interfaces.Repositories.Domain
{
    public interface IBookRepository : IDomainRepository<Book>
    {
        Pagination<BookDto> GetAll(int page, int rowsPerPage);
        Pagination<BookDto> GetByFilter(SearchBookEnum option, string value, int page, int rowsPerPage);
    }
}
