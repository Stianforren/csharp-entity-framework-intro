using exercise.webapi.DTOs;
using exercise.webapi.Repository;

namespace exercise.webapi.Endpoints
{
    public static class AuthorAPI
    {
        public static void ConfigureAuthorAPI(this WebApplication app)
        {
            app.MapGet("/author{id}", GetAuthorById);
            app.MapGet("/authors", GetAllAuthors);
        }

        private static async Task<IResult> GetAuthorById(IAuthorRepository repository, int id)
        {
            var results = await repository.GetAuthorById(id);
            return results is null ? TypedResults.NotFound() : TypedResults.Ok(new AuthorGetWithBooks() { FirstName=results.FirstName,
                                                                                                          LastName=results.LastName,
                                                                                                          Email=results.Email,
                                                                                                          Books=repository.GetBooks(results.Books)});
        }
        private static async Task<IResult> GetAllAuthors(IAuthorRepository repository)
        {
            var response = await repository.GetAllAuthors();

            return TypedResults.Ok(response);
        }
    }
}
