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
            var response = await _db.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == bookId);
            return response is null ? null : response;
        }

        public async Task<Author> getAuthorById(int authorId)
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

        public async Task<Book> DeleteAsync(int bookId)
        {
            var response = await GetBookAsync(bookId);
            _db.Books.Remove(response);
            await _db.SaveChangesAsync();
            return response;
        }

        public async Task<Book> CreateAsync(string title, int authorId)
        {
            Book newBook = new Book() { Id = _db.Books.Last().Id + 1,
                                        Title = title,
                                        AuthorId = authorId,
                                        Author = getAuthorById(authorId).Result};
            await _db.AddAsync(newBook);
            await _db.SaveChangesAsync();
            return newBook;


        }
    }
}
