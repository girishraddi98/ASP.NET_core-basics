//using NewProject.Dtos;
using NewProject.Dtos;
using NewProject.Dtos.StudentDto;
using NewProject.Models;
namespace NewProject.Service.UserService
{
    public interface IStudentService
    {
        Task<StudentDto> AddStuAsync(CreateStuDto user);
        Task<StudentDto> UpdateUserAsync(Guid id, UpdateStuDto user);
        Task<StudentDto> DeleteUserAsync(Guid id);
        Task<IEnumerable<StudentDto>> GetAllUsersAsync();
        Task<StudentDto> GetUserByMailAsync(string mail);
    }
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorDto>> GetAllProductsAsync();
        Task<InstructorDto> GetProductByIdAsync(string name);
        Task<InstructorDto> AddProductAsync(AddInstructDto product);
        Task<InstructorDto> UpdateProductAsync(Guid id, UpgradeInstructDto product);
        Task<InstructorDto?> DeleteProductAsync(Guid id);
    }
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> GetByIdAsync(int id);
        Task<CourseDto> AddOrderAsync(CreateCourseDto course);
        Task<CourseDto> UpdateOrderAsync(int id, UpdateCourseDto order);
        Task<CourseDto> DeleteOrderAsync(int id);

    }
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> AddOrderAsync(CreateEnDto course);
        Task<EnrollmentDto> DeleteEnrollAsync(int id);
        Task<IEnumerable<EnrollmentDto>> GetAllAsync();
        Task<EnrollmentDto> GetByIdAsync(int id);
        Task<EnrollmentDto> UpdateOrderAsync(int id, UpEnDto order);
    }
    public interface IInstructAuth
    {

        Task<InstructTokenDto> LoginInstructorAsync(LoginInstructDto dto);
    }
    public interface IStuAuth
    {
        Task<StudentTokenDto> stuLogin(StudentLoginDto student);
    }
    public interface IUserService
    {
        Task<IEnumerable<UserListDto>> userListsAsync();
    }

}
