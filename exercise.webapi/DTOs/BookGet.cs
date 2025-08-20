using exercise.webapi.Models;

namespace exercise.webapi.DTOs
{
    public class BookGet
    {
        public string Title { get; set; }
        public AuthorGet author { get; set; }

        public BookGet(Book book)
        {
            Title = book.Title;
            author = new AuthorGet(book.Author);
        }
    }
}
