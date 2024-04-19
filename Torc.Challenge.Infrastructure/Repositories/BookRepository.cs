using FruitStore.Domain.Enums;
using Torc.Challenge.Domain.DTOs.Book;
using Torc.Challenge.Domain.Entities;
using Torc.Challenge.Domain.Utility;
using Torc.Challenge.Infrastructure.DBConfiguration;
using Torc.Challenge.Infrastructure.Interfaces.Repositories.Domain;
using Torc.Challenge.Infrastructure.Repositories.Standard;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Torc.Challenge.Infrastructure.Repositories
{
    public class BookRepository : DomainRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext dbContext) : base(dbContext) { }

        public Pagination<BookDto> GetAll(int page, int rowsPerPage)
        {
            IQueryable<Book> query = _dbSet.OrderBy(x => x.Title);

            var totalItemCount = query.Count();
            var skipNumber = Pagination<BookDto>.CalculateSkipNumber(page, rowsPerPage);
            var books = query.Skip(skipNumber).Take(rowsPerPage).Select(book => (BookDto)book).ToList();

            return new Pagination<BookDto>
            (
                items: books,
                totalItemCount: totalItemCount,
                pageSize: rowsPerPage,
                currentPage: page
            );
        }

        public Pagination<BookDto> GetByFilter(SearchBookEnum option, string value, int page, int rowsPerPage)
        {
            IQueryable<Book> query = _dbSet.OrderBy(x => x.Title);
            switch (option)
            {
                case SearchBookEnum.Title:
                    query = query.Where(book => book.Title == value);
                    break;
                case SearchBookEnum.FirstName:
                    query = query.Where(book => book.FirstName == value);
                    break;
                case SearchBookEnum.LastName:
                    query = query.Where(book => book.LastName == value);
                    break;
                case SearchBookEnum.Isbn:
                    query = query.Where(book => book.Isbn == value);
                    break;
                case SearchBookEnum.Category:
                    query = query.Where(book => book.Category == value);
                    break;
            }

            var totalItemCount = query.Count();
            var skipNumber = Pagination<BookDto>.CalculateSkipNumber(page, rowsPerPage);
            var books = query.Skip(skipNumber).Take(rowsPerPage).Select(book => (BookDto)book).ToList();

            return new Pagination<BookDto>
            (
                items: books,
                totalItemCount: totalItemCount,
                pageSize: rowsPerPage,
                currentPage: page
            );
        }
    }
}
