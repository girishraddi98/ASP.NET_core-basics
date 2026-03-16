using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Dtos;

//using NewProject.Dtos;
using NewProject.Models;
using Org.BouncyCastle.Asn1.X509;

namespace NewProject.Service.UserService
{
    public class CourseService:  ICourseService
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;

        public CourseService(AppDbContext context, IMapper mapper) {
            this.context = context;
            this._mapper = mapper;
        }

        public async Task<CourseDto> AddOrderAsync(CreateCourseDto course)
        {
            var NewD = _mapper.Map<Course>(course);
            await context.Course.AddAsync(NewD);

            await context.SaveChangesAsync();
            return _mapper.Map<CourseDto>(NewD);

        }

        public async Task<CourseDto> DeleteOrderAsync(int id)
        {
            var user = await context.Course.FindAsync(id);
            if (user == null) {return null;}
            context.Remove(user);
            await context.SaveChangesAsync();
            return _mapper.Map<CourseDto>(user);
            
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
           var newD = _mapper.Map<IEnumerable<CourseDto>>(await context.Course.Include(e => e.Instructor).ToListAsync());
            return newD;


        }

        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var user = context.Course.Include(e => e.Instructor).FirstOrDefaultAsync(a=>a.CourseId==id);
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<CourseDto>(user);
        }

        public async Task<CourseDto> UpdateOrderAsync(int id, UpdateCourseDto order)
        {
            var user = await context.Course.FindAsync(id);
            if (user == null) { return null; }
            _mapper.Map(order, user);
            context.Course.Update(user);
            await context.SaveChangesAsync();
            return _mapper.Map<CourseDto>(user);

        }
    }
}
