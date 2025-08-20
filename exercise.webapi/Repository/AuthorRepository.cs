using exercise.webapi.Data;
using exercise.webapi.DTOs;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace exercise.webapi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        DataContext _db;

        public AuthorRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AuthorGetWithBooks>> GetAllAuthors()
        {
            List<AuthorGetWithBooks> authors = new List<AuthorGetWithBooks>(); 
            foreach (var auth in await _db.Authors.Include(a => a.Books).ToListAsync())
            {
                List<BookTitle> bookTitles = GetBooks(auth.Books);
                AuthorGetWithBooks author = new AuthorGetWithBooks() { FirstName=auth.FirstName,
                                                                       LastName=auth.LastName,
                                                                        Email=auth.Email,
                                                                        Books=bookTitles};
                authors.Add(author);
            }
            return authors;
        }

        public async Task<Author> GetAuthorById(int authorId)
        {
            var response = await _db.Authors.Where(a => a.Id == authorId).Include(a => a.Books).FirstOrDefaultAsync();
            return response;
        }

        public List<BookTitle> GetBooks(ICollection<Book> authors)
        {
            List<BookTitle> bookTitles = new List<BookTitle>();
            foreach (var book in authors)
            {
                bookTitles.Add(new BookTitle { Title = book.Title });
            }
            return bookTitles;
        }
    }
}
