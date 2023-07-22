
using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace DemoNorthwindWithEF.Bussiness.Mapping
{
    

    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Semester, SemesterDTO>().ReverseMap();
            CreateMap<Class, ClassDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<Grade, GradeDTO>().ReverseMap();
            CreateMap<SubjectGrade, SubjectGradeDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
        }

    }
}
