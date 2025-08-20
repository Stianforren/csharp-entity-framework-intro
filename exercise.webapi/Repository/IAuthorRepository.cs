using exercise.webapi.DTOs;
using exercise.webapi.Models;

namespace exercise.webapi.Repository
{
    public interface IAuthorRepository
    {
        public Task<Author> GetAuthorById(int authorId);
        public Task<IEnumerable<AuthorGetWithBooks>> GetAllAuthors();
        public List<BookTitle> GetBooks(ICollection<Book> authors);
    }
}
