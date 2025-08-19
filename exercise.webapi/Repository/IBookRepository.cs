using exercise.webapi.DTOs;
using exercise.webapi.Models;

namespace exercise.webapi.Repository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooks();

        public Task<Book> GetBookAsync(int id);
        public Task<Book> UpdateAsync(Book book, int authorId);
    }
}
