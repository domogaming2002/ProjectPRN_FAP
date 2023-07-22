
using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.DataAccess.Models;

namespace DemoNorthwindWithEF.Bussiness.Mapping
{
    

    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Semester, SemesterDTO>().ReverseMap();
            CreateMap<Class, ClassDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
        }

    }
}
