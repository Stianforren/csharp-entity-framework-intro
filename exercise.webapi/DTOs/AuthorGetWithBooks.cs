using exercise.webapi.Models;

namespace exercise.webapi.DTOs
{
    public class AuthorGetWithBooks
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<BookTitle> Books { get; set; }
    }
}
