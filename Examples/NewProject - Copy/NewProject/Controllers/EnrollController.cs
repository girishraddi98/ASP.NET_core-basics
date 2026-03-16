using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewProject.Dtos;
using NewProject.Models;
using NewProject.Service.UserService;

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        
        private readonly IEnrollmentService service;

        public IMapper Mapper { get; }
        public EnrollController(IEnrollmentService enrollmentService, IMapper mapper)
        {
            this.service = enrollmentService;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Instructor,Student")]
        public async Task<ActionResult<IEnumerable<EnrollmentDto>>> GetAllEnrollments()
        {
            var enrollments = await service.GetAllAsync();
            return Ok(enrollments);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Instructor,Student")]
        public async Task<ActionResult<EnrollmentDto>> GetEnrollAsync(int id)
        {
            if (id <= 0)
                return BadRequest();
            var enroll = await service.GetByIdAsync(id);

            if (enroll == null)
                return NotFound();

            return Ok(enroll);
        }

        [HttpPost]
        [Authorize(Policy ="InstructorOnly")]
        public async Task<ActionResult<EnrollmentDto>> AddEnrollAsync(
            [FromBody] CreateEnDto enroll)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newEnroll = await service.AddOrderAsync(enroll);

            return CreatedAtAction(
                nameof(GetEnrollAsync),
                new { id = newEnroll.EnrollmentId },
                newEnroll);
        }

        [HttpPut("{id:int}")]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<ActionResult<EnrollmentDto>> UpdateEnrollAsync(
            [FromRoute] int id,
            [FromBody] UpEnDto enroll)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await service.UpdateOrderAsync(id, enroll);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<IActionResult> DeleteEnrollAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var deleted = await service.DeleteEnrollAsync(id);

            if (deleted == null)
                return NotFound();

            return NoContent(); 
        }
    }
}
