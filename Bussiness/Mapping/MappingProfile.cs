
using AutoMapper;
using PRN221_Project_RazorPage.Bussiness.DTO;
using PRN221_Project_RazorPage.DataAccess.Models;

namespace DemoNorthwindWithEF.Bussiness.Mapping
{
    

    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Semester, SemesterDTO>().ReverseMap();
        }

    }
}
