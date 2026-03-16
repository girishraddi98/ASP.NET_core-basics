using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Dtos;
using NewProject.Dtos.StudentDto;

//using NewProject.Dtos;
using NewProject.Models;


namespace NewProject.Service.UserService
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public StudentService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<StudentDto> AddStuAsync(CreateStuDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Password cannot be empty", 
                    nameof(user.Password));

            var student = mapper.Map<Student>(user);
            student.StudentId = Guid.NewGuid();
            var hasher = new PasswordHasher<Student>();


            student.PasswordHash = hasher.HashPassword(student, user.Password);
            context.Students.Add(student);
            Console.WriteLine(student.PasswordHash);
            await context.SaveChangesAsync();
            return mapper.Map<StudentDto>(student);

            


            


        }

        public async Task<StudentDto> DeleteUserAsync(Guid id)
        {
            var user = await context.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (user == null)
            {
                return null;
            }

            context.Students.Remove(user);
            await context.SaveChangesAsync();
            return mapper.Map<StudentDto>(user);
        }

        public async Task<IEnumerable<StudentDto>> GetAllUsersAsync()
        {
            var student =mapper.Map<List<StudentDto>>(await context.Students.ToListAsync());
            return student;

        }

        

        public async Task<StudentDto> GetUserByMailAsync(string mail)
        {
            var user = await context.Students.FirstOrDefaultAsync(x => x.Email == mail);
            if (user == null)
            {
                return null;
            }

            return mapper.Map<StudentDto>(user)
                ;

        }

        public async Task<StudentDto> UpdateUserAsync(Guid id, UpdateStuDto user)
        {
            var existingUser = await context.Students
        .FirstOrDefaultAsync(x => x.StudentId == id);

            if (existingUser == null)
                return null;

            
            mapper.Map(user, existingUser);

            await context.SaveChangesAsync();

            return mapper.Map<StudentDto>(existingUser);

        }
    }
    public class UserListService : IUserService
    {
        private readonly AppDbContext app;
        private readonly IMapper mapper;

        public UserListService(AppDbContext appDb, IMapper Mapper)
        {
            this.app = appDb;
            this.mapper = Mapper;
        }
        public async Task<IEnumerable<UserListDto>> userListsAsync()
        {
           var students = await app.Students.Select(s => new UserListDto
            {
                Name = s.Name,
                Email = s.Email,
                Sourse = "Student"
            }).ToListAsync();
            var teachers = await app.Instructors.Select(t => new UserListDto
            {
                Name = t.Name,
                Email = t.Email,
                Sourse = "Instructor"
            }).ToListAsync();
            var userList = students.Concat(teachers).ToList();
            return userList;
        }
    }
}
