using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using library.Application;
using library.Application.Core;
using library.Domain;
using library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace library.Infrastructure;

public class AuthorService : IAuthorService
{
    private ApplicationDbContext _context {get;set;}
    public AuthorService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ApiResponse<LoginAuthorResponse>> Login(LoginAuthorRequest request)
    {
        Author author = await _context.Authors.Where(a => a.Email == request.Email).FirstOrDefaultAsync();
        HMACSHA256 hMACSHA256 = new HMACSHA256(author.Salt);
        byte[] bytes = Encoding.UTF8.GetBytes(request.Password);
        byte[] HashedBytes = hMACSHA256.ComputeHash(bytes);
        bool isOk = HashedBytes.SequenceEqual(author.Password);
        if (isOk) {
            LoginAuthorResponse res = new LoginAuthorResponse();
            res.Token = CreateToken(author);
            return  ApiResponse<LoginAuthorResponse>.Success(res);
        }
        else {
            return ApiResponse<LoginAuthorResponse>.UnAuth();
        }
    }


    public async Task<ApiResponse<RegisterAuthorResponse>> Register(RegisterAuthorRequest request)
    {
        Author author = new Author { FullName = request.FullName, Email = request.Email };
        byte[] bytes = Encoding.UTF8.GetBytes(request.Password);
        string guid = Guid.NewGuid().ToString();
        byte[] salt = SHA256.HashData(Encoding.UTF8.GetBytes(guid));
        HMACSHA256 hMACSHA256 = new(salt);
        byte[] hashedPassword = hMACSHA256.ComputeHash(bytes);
        author.Salt = salt;
        author.Password = hashedPassword;
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
        RegisterAuthorResponse res = new() { };
        return ApiResponse<RegisterAuthorResponse>.Success(res);
    }

    public static string CreateToken (Author author) {
      
        ClaimsPrincipal principal = new ();
        ClaimsIdentity identity = new ();
        JwtSecurityTokenHandler handler = new();
        JwtSecurityToken token = new JwtSecurityToken();
        identity.AddClaim(new Claim("Id", author.Id.ToString()));
        identity.AddClaim(new Claim("FullName", author.FullName));
        SecurityTokenDescriptor descriptor = new ();
        descriptor.Issuer = "Elvin";
        descriptor.Audience = "Library";
        descriptor.Subject = identity;
        descriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KhK9vhpATrzgD7mIuRXXQtr1UOkDHZGvtpSpPErkO2txog4KIfQExFtBuVbpC7L")), SecurityAlgorithms.HmacSha256);
       var securityToken =  handler.CreateToken(descriptor);
       string result = handler.WriteToken(securityToken);
       return result;
    }

    public  async Task<ApiResponse<List<GetAuthorResponse>>> Get(GetAuthorRequest request)
    {
      var result = await _context.Authors.Where(a => request.Id != null ? a.Id == request.Id : true)
      .Select(c => new GetAuthorResponse { Id = c.Id, Books = c.Books.ToList(), Email = c.Email, FullName = c.FullName, BookCount = c.Books.Count() })
       .OrderByDescending(x => x.Books.Count()).ToListAsync();
       ;
       return ApiResponse<List<GetAuthorResponse>>.Success(result);
    }
}
