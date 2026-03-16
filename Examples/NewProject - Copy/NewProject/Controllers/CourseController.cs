using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Dtos;
using NewProject.Models;
using NewProject.Service.UserService;

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService course;
        private readonly AppDbContext _context;

        public CourseController(ICourseService course, AppDbContext context)
        {
            this.course = course;
            this._context = context;
        }
        [HttpPost]
        [Authorize(Policy ="InstructorOnly")]
        public async Task<IActionResult> CreateUserAsync(CreateCourseDto user)
        {
           var newD = await course.AddOrderAsync(user);
            if (newD != null)
            {
                return CreatedAtAction(nameof(getUserId), new { id = newD.CourseId },  user);
            }
            return BadRequest();


        }
        [HttpPut("{id:int}")]
        [Authorize(Policy = "InstructorOnly")]

        public async Task<IActionResult> UpdateUser([FromRoute] int id, 
            [FromBody] UpdateCourseDto dto)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var newD = await course.UpdateOrderAsync(id, dto);
            if (newD == null) { return BadRequest(); }

            return Ok(newD);
        }
        [HttpGet]
        [Authorize(Roles = "Instructor,Student")]
        public async Task<ActionResult<IEnumerable<CourseDto>>> getUsers()
        {
            var emp = await course.GetAllAsync();
            if(emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Instructor,Student")]
        public async Task<ActionResult<CourseDto>> getUserId([FromRoute] int id)
        {
            if (id <=0)
            {
                return BadRequest();
            }
            var emp = await course.GetByIdAsync(id);
            return Ok(emp);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<IActionResult> delUser([FromRoute] int id)
        {

            if (id <=0)
            {
                return BadRequest();
            }
            var newD = await course.DeleteOrderAsync(id);
            if (newD == null)
            {
                return NotFound();
            }
            return Ok(newD);
        }
    }
}
