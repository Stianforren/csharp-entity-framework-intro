using exercise.webapi.Models;

namespace exercise.webapi.DTOs
{
    public class AuthorGet
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AuthorGet(Author author)
        {
            FirstName = author.FirstName;
            LastName = author.LastName;
            Email = author.Email;
        }
    }
}
