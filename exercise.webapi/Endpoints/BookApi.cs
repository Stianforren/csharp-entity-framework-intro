using exercise.webapi.DTOs;
using exercise.webapi.Models;
using exercise.webapi.Repository;
using static System.Reflection.Metadata.BlobBuilder;

namespace exercise.webapi.Endpoints
{
    public static class BookApi
    {
        public static void ConfigureBooksApi(this WebApplication app)
        {
            app.MapGet("/books", GetBooks);
            app.MapGet("/book{id}", GetBookById);
            app.MapPut("/book{id}", UpdateBook);
        }

        private static async Task<IResult> GetBooks(IBookRepository bookRepository)
        {
            List<Object> response = new List<Object>();
            var books = await bookRepository.GetAllBooks();
            foreach (var book in books)
            {
                BookGet bookDisplay = new BookGet(book);
                response.Add(bookDisplay);
            }

            return TypedResults.Ok(response);
        }

        private static async Task<IResult> GetBookById(IBookRepository repository, int bookId)
        {
            var response = await repository.GetBookAsync(bookId);
            if (response == null) { return TypedResults.NotFound(); }
            BookGet book = new BookGet(response);
            return TypedResults.Ok(book);
        }

        private static async Task<IResult> UpdateBook(IBookRepository repository, int bookId, int authorId)
        {
            var entity = await repository.GetBookAsync(bookId);
            var response = await repository.UpdateAsync(entity, authorId);
            BookGet book = new BookGet(response);
            return TypedResults.Ok(book);
        }
    }
}
