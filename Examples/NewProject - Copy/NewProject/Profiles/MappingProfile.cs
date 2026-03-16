using AutoMapper;
using NewProject.Dtos;
using NewProject.Dtos.StudentDto;
using NewProject.Models;

namespace NewProject.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateStuDto, Student>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap().ForMember(dest => dest.StudentId,
               opt => opt.MapFrom(src => src.StudentId));
            CreateMap<UpdateStuDto, Student>().ReverseMap();


            CreateMap<Instructor, InstructorDto>().ReverseMap().ForMember(dest => dest.InstructorId,
               opt => opt.MapFrom(src => src.InstructorId));
            CreateMap<UpgradeInstructDto, InstructorDto>().ReverseMap();
            CreateMap<AddInstructDto, Instructor>().ReverseMap();
            CreateMap<UpgradeInstructDto,Instructor>().ReverseMap();


            CreateMap<UpdateCourseDto, CourseDto>().ReverseMap();
            CreateMap<CreateCourseDto, Course>().ReverseMap();
            CreateMap < UpdateCourseDto, Course>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();

            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<CreateEnDto, Enrollment>();
            CreateMap<UpEnDto, Enrollment>();

        }
    }
}
