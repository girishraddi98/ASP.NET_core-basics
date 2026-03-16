using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Dtos;
using NewProject.Dtos.StudentDto;
using NewProject.Models;
using NewProject.Service.UserService;
using NewProject.ValidateExceptions;
using Org.BouncyCastle.Asn1.Cmp;

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IStudentService _user;
        private readonly AppDbContext _context;

       private readonly IMapper _mapper;
        private readonly IStuAuth _auth;
        private readonly ILogger logger;
        private readonly IUserService userService;

        public UserController(IStudentService user, AppDbContext context, IMapper mapper,
            IStuAuth auth, ILogger<UserController> logger1, IUserService userService)
        {
            this._user = user;
            _context = context;
            _mapper = mapper;
            this._auth = auth;
            this.logger = logger1;
            this.userService = userService;
        }
        [HttpGet("Enlisted members")]
        [Authorize(Roles = "Instructor, Student")]
        public async Task<ActionResult<IEnumerable<UserListDto>>> GetUserList()
        {
            var emp = await userService.userListsAsync();
            return Ok(emp);
        }

        [HttpPost("login")]
       
        public async Task<IActionResult> Login(StudentLoginDto loginDto)
        {
            logger.LogInformation($"Login attempt for {loginDto.Name}", loginDto.Name);
            var token = await _auth.stuLogin(new StudentLoginDto { Name = loginDto.Name, Password = loginDto.Password });
            if (token == null)
            {
                logger.LogError($"Invalid Creadentials {loginDto.Name}", loginDto);
                return Unauthorized();
            }
            logger.LogInformation($"Login Successful. Welcome {loginDto.Name}", loginDto?.Name);
            return Ok(token);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Instructor,Student")]
        public async Task<IActionResult> CreateUserAsync(CreateStuDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }


            var newD = await _user.AddStuAsync(user);
            if (newD != null) { 
                return CreatedAtAction(nameof(getUserId), new {email=newD.Email}, newD);
            }
             throw new ArgumentException(nameof(user));
            
        }
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Instructor")]

        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateStuDto dto)
        {
            if(id == null)
            {
                return BadRequest();
            }
            

            var newD = await _user.UpdateUserAsync(id, dto);
            if (newD == null) { return BadRequest(); }

            return Ok(newD);
        }
        [HttpGet]
        [Authorize(Roles = "Instructor, Student")]
        public async Task <ActionResult<IEnumerable<StudentDto>>> getUsers()
        {
            var emp = await _user.GetAllUsersAsync();
            return Ok(emp);
        }
        [HttpGet("{Email}")]
        [Authorize(Roles = "Instructor")]
        public async Task<ActionResult<Student>> getUserId(string Email)
        {
            if(Email == null)
            {
                return BadRequest();
            }
            
            var emp = await _user.GetUserByMailAsync(Email);
            if (emp == null) {
                return NotFound();}
            return Ok(emp);
        }
        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Instructor")]
        public async Task<IActionResult> delUser([FromRoute]Guid id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var newD = await _user.DeleteUserAsync(id);
            if (newD == null) { 
                return NotFound();
            }
            return Ok(newD);
        }
        
    }
    #region

    #endregion
}
