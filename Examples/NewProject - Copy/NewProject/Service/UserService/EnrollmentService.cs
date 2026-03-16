using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewProject.Context;
using NewProject.Dtos;
using NewProject.Models;
using System.Linq;

namespace NewProject.Service.UserService
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly AppDbContext context;
        private readonly IMapper _mapper;

        public EnrollmentService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }
        public async Task<EnrollmentDto> DeleteEnrollAsync(int id)
        {
            var user = await context.Enrollments.FindAsync(id);
            if (user == null) return null;

            context.Enrollments.Remove(user);
            await context.SaveChangesAsync();

            return _mapper.Map<EnrollmentDto>(user);
        }

        public async Task<IEnumerable<EnrollmentDto>> GetAllAsync()
        {
            var users = await context.Enrollments.Include(a=>a.Student).Include(e=>e.Course).ToListAsync();
            return _mapper.Map<List<EnrollmentDto>>(users);
        }

        public async Task<EnrollmentDto> GetByIdAsync(int id)
        {
            var user = await context.Enrollments.Include(a => a.Student)
                .Include(e => e.Course)
                .FirstOrDefaultAsync(x => x.EnrollmentId == id);

            if (user == null) return null;

            return _mapper.Map<EnrollmentDto>(user);
        }

        public async Task<EnrollmentDto> AddOrderAsync(CreateEnDto course)
        {
            var entity = _mapper.Map<Enrollment>(course);

            await context.Enrollments.AddAsync(entity);
            await context.SaveChangesAsync();

            return _mapper.Map<EnrollmentDto>(entity);
        }

        public async Task<EnrollmentDto> UpdateOrderAsync(int id, UpEnDto order)
        {
            var user = await context.Enrollments.FindAsync(id);
            if (user == null) return null;

            _mapper.Map(order, user);

            // No AddAsync here!
            context.Enrollments.Update(user); // optional if tracked

            await context.SaveChangesAsync();

            return _mapper.Map<EnrollmentDto>(user);
        }






    }
}
