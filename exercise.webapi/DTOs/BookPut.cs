using exercise.webapi.Models;

namespace exercise.webapi.DTOs
{
    public class BookPut
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
