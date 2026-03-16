using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewProject.Context;
using NewProject.Dtos;
using NewProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NewProject.Service.UserService
{
    
    public class InstructAuth : IInstructAuth
    {
        private readonly AppDbContext Context;
        private readonly IMapper _mapper;

        public InstructAuth(IConfiguration configuration, AppDbContext dbContext, IMapper mapper)
        {
            Config = configuration;
            this.Context = dbContext;
            this._mapper = mapper;
        }

        public IConfiguration Config { get; }

        public async Task<InstructTokenDto> LoginInstructorAsync(LoginInstructDto dto)
        {
            var instructor = await Context.Instructors
                .FirstOrDefaultAsync(x => x.Email == dto.Email);

            if (instructor == null)
                throw new Exception();

            var hasher = new PasswordHasher<Instructor>();
            Console.WriteLine(instructor.PasswordHash);

            var result = hasher.VerifyHashedPassword(
                instructor,
                instructor.PasswordHash,
                dto.Password  
            );

            if(result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException();

            var token = new InstructTokenDto
            {
                Token = createToken(instructor)
            };

            instructor.Token = token.Token;
            await
                Context.SaveChangesAsync();

            return token;
        }

        private string createToken(Instructor instructor)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, instructor.Email),
                new Claim(ClaimTypes.Role, "Instructor")
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(Config["AppSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                Config["AppSettings:Issuer"],
                Config["AppSettings:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
