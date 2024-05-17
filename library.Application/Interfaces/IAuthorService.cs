using library.Application.Core;
using library.Domain;
using library.Models;

namespace library.Application;

public interface IAuthorService
{
    public Task<ApiResponse<LoginAuthorResponse>> Login(LoginAuthorRequest request);
    public Task<ApiResponse<RegisterAuthorResponse>> Register(RegisterAuthorRequest request);
    public Task<ApiResponse<List<AuthorDto>>> Get (GetAuthorRequest request); 
}
