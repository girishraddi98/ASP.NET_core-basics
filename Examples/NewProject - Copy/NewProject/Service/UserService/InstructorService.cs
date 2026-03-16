using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Dtos;
using NewProject.Dtos.StudentDto;



//using NewProject.Dtos;
using NewProject.Models;
using Microsoft.AspNetCore.Identity;

namespace NewProject.Service.UserService
{
    public class InstructorService : IInstructorService
    {
        private readonly AppDbContext context;

        private readonly IMapper _mapper;

        public InstructorService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        
        public  async Task<InstructorDto> AddProductAsync(AddInstructDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Password))
                throw new ArgumentException("Password cannot be empty", nameof(dto.Password));

            
            var instructor = _mapper.Map<Instructor>(dto);
            instructor.InstructorId = Guid.NewGuid();

           
            var hasher = new PasswordHasher<Instructor>();
            instructor.PasswordHash = hasher.HashPassword(instructor, dto.Password);

            
            context.Instructors.Add(instructor);
            await context.SaveChangesAsync();

            
            return _mapper.Map<InstructorDto>(instructor);
        }

        public async Task<InstructorDto?> DeleteProductAsync(Guid id)
        { 
            var Product = await context.Instructors.FirstOrDefaultAsync(x => x.InstructorId == id);
            if (Product == null)
            {
                return null;
            }
            context.Instructors.Remove(Product);
            await context.SaveChangesAsync();
            return (_mapper.Map<InstructorDto>(Product));
           

           
        }

        public async Task<IEnumerable<InstructorDto>> GetAllProductsAsync()
        {
            var user =  _mapper.Map<List<InstructorDto>>(await context.Instructors.ToListAsync());
            return user;
           


        }



        public async Task<InstructorDto> GetProductByIdAsync(string name)
        {
            var Product = await context.Instructors.FirstOrDefaultAsync(x => x.Name == name);
            if (Product == null)
            {
                return null;
            }

            return (_mapper.Map<InstructorDto>(Product));

        }

        public async Task<InstructorDto?> UpdateProductAsync(Guid id, UpgradeInstructDto Product)
        {
            var newD = await context.Instructors.FirstOrDefaultAsync(x=>x.InstructorId==id);
            if(newD== null)
            {
                return null;
            }
            _mapper.Map(Product ,newD);
            
            await context.SaveChangesAsync();
            return _mapper.Map<InstructorDto>(newD); 
        }


    }
}
