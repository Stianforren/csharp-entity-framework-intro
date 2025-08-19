using exercise.webapi.Data;
using exercise.webapi.DTOs;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace exercise.webapi.Repository
{
    public class BookRepository: IBookRepository
    {
        DataContext _db;
        
        public BookRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _db.Books.Include(b => b.Author).ToListAsync();
        }

        public async Task<Book> GetBookAsync(int bookId)
        {
            var response = await _db.Books.FindAsync(bookId);
            if (response == null) { return null; }
            response.Author = await getAuthorById(response.AuthorId);
            //BookGet book = new BookGet(response);
            return response;
        }

        private async Task<Author> getAuthorById(int authorId)
        {
            return await _db.Authors.FindAsync(authorId);
        }

        public async Task<Book> UpdateAsync(Book entity, int authorId)
        {
            entity.AuthorId = authorId;
            await _db.SaveChangesAsync();
            entity.Author = await getAuthorById(authorId);
            return entity;
        }
    }
}
