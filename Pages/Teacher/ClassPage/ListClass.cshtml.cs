using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.Bussiness.Repository;
using System.Security.Claims;

namespace ProjectPRN_FAP.Pages.Teacher.ClassPage
{
    [Authorize(Roles = "2")]
    public class ListClassModel : PageModel
    {

        IClassSubjectRepository _classSubjectRepository;
        ITeacherRepository _teacherRepository;

        public List<ClassDTO> classDTOs { get; set; }
        public List<ClassSubjectDTO> classSubjectDTOs { get; set; }
        public TeacherDTO teacherDTO { get; set; }
        public List<SubjectDTO> subjectDTOs { get; set; }
        public List<SemesterDTO> semesterDTOs { get; set; }


        public ListClassModel(IClassSubjectRepository classSubjectRepository, ITeacherRepository teacherRepository)
        {
            _classSubjectRepository = classSubjectRepository;
            _teacherRepository = teacherRepository;
        }

        public void OnGet()
        {
            GetData();
        }

        private void GetData()
        {
            String userId = HttpContext.User.FindFirstValue(ClaimTypes.Sid);
            teacherDTO = _teacherRepository.GetByUserId(Int32.Parse(userId));
            classSubjectDTOs = _classSubjectRepository.GetListByTeacher(teacherDTO.TeacherId);

        }
    }
}
