using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewProject.Context;
using NewProject.Dtos;
using NewProject.Dtos.StudentDto;
using NewProject.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NewProject.Service.UserService
{
   
    public class StuAuth: IStuAuth
    {
        private readonly IConfiguration configuration;
        private readonly AppDbContext context;

        public StuAuth(IConfiguration configuration, AppDbContext dbContext)
        {
            this.configuration = configuration;
            this.context = dbContext;
        }
        public async Task<StudentTokenDto> stuLogin(StudentLoginDto student)
        {
            var stu = await context.Students.FirstOrDefaultAsync(x => x.Name == student.Name);
            if (stu == null)
                throw new Exception("Student not found");

            var hasher = new PasswordHasher<Student>();
            var result = hasher.VerifyHashedPassword(stu, stu.PasswordHash, student.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid password");

            var token = new StudentTokenDto
            {
                Token = createStuToken(stu)
            };
            stu.Token = token.Token;
            await context.SaveChangesAsync();
            return token;
        }

        

        private string createStuToken(Student student)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, student.Name),
                new Claim(ClaimTypes.Role, "Student")

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(configuration["AppSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                configuration["AppSettings:Issuer"],
                configuration["AppSettings:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
