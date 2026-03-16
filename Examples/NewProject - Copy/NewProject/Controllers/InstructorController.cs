using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Dtos;

//using NewProject.Dtos;
using NewProject.Models;
using NewProject.Service.UserService;
using NewProject.ValidateExceptions;
using System.Threading.Tasks;

namespace NewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _product;
        private readonly IMapper _mapper;
        private readonly AppDbContext context;
        private readonly ILogger<InstructorController> logger;

        public IInstructAuth Auth { get; }

        public InstructorController(IInstructorService product, IMapper mapper,
            AppDbContext dbContext,IInstructAuth auth, ILogger<InstructorController> Logger)
        {
            this._product = product;
            this._mapper = mapper;
            this.context = dbContext;
            Auth = auth;
            this.logger = Logger;
        }
        [HttpPost("Login")]
        
        public async Task<IActionResult> Login(LoginInstructDto loginDto)
        {
            logger.LogInformation($"Login attempt for {loginDto.Email}", loginDto.Email);
            var token = await Auth.LoginInstructorAsync(new LoginInstructDto { Email = loginDto.Email, Password = loginDto.Password });
            if (token == null)
            {
                throw new Exception($"{loginDto.Email} is not recognized or invalid credentials");
            }
            logger.LogInformation($"Login successful for email: {loginDto.Email}", loginDto.Email);
            return Ok(token);
        }
            [HttpPost]
        [ValidateModel]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<IActionResult> AddInstruct(AddInstructDto instructor )
        {
            logger.LogInformation("Adding new instructor with email: {Email}", instructor.Email);
            var result = await _product.AddProductAsync(instructor);
            if(result== null)
            {
                logger.LogWarning("Failed to add instructor with email: {Email}", instructor.Email);
                throw new ArgumentNullException();
            }
            return CreatedAtAction(nameof(getInstructById), new {name=result.Name},result);
            
        }
        [HttpGet]
        [Authorize(Roles = "Instructor,Student")]
        public async Task<ActionResult <IEnumerable<InstructorDto>>> getAllProduct()
        {
            logger.LogInformation("Retrieving all instructors");
            var newD = await _product.GetAllProductsAsync();
            if (newD == null) { 
                throw new Exception($"Invalid {newD}, not present in collection");
            }
            return Ok(newD);
        }
        [HttpGet("{Name}")]
        [Authorize(Roles ="Instructor,Student")]

        public async Task<ActionResult<InstructorDto>> getInstructById(string Name)
        {
            if(Name == null)
            {
                logger.LogWarning("Instructor name is null");
                return BadRequest();
            }
            
            var FewD = await _product.GetProductByIdAsync(Name);

            if (FewD == null) { 
                throw new Exception($"Invalid id {FewD} not present in collection");
            }
            return Ok(_mapper.Map<InstructorDto>(FewD));
        }
        [HttpPut("{id:Guid}")]
        [ValidateModel]
        [Authorize(Policy = "InstructorOnly")]
        public async Task <IActionResult> updateProduct([FromRoute]Guid id,[FromBody] UpgradeInstructDto productDto)
        {
            if(productDto == null)
            {
                logger.LogWarning("Update failed: product data is null");
                return BadRequest();
            }
            var upProduct = await _product.UpdateProductAsync(id, productDto);
            if (upProduct == null) { 
                logger.LogWarning($"Update failed: no instructor found with id {upProduct}", id);
                return NotFound();
            }
            return Ok(_mapper.Map<InstructorDto>(upProduct));

        }
        [HttpDelete("{id:Guid}")]
        [Authorize(Policy = "InstructorOnly")]
        public async Task<IActionResult> Delete(Guid id) { 
            if(id == null)
            {
                return BadRequest();
            }
            var newD=await _product.DeleteProductAsync(id); 
            return Ok(_mapper.Map<InstructorDto>(newD));
        }
    }
}
