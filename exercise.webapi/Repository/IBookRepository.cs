using exercise.webapi.DTOs;
using exercise.webapi.Models;

namespace exercise.webapi.Repository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllBooks();

        public Task<Book> GetBookAsync(int id);
        public Task<Book> UpdateAsync(Book book, int authorId);
        public Task<Book> DeleteAsync(int bookId);
        public Task<Book> CreateAsync(string title, int authorId);
        public Task<Author> getAuthorById(int authorId);
    }
}
