using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Admin.ClassPage
{
    public class ClassSubjectModel : PageModel
    {
        IClassRepository _classRepository;
        IClassSubjectRepository _classSubjectRepository;
        ITeacherRepository _teacherRepository;
        ISubjectRepository _subjectRepository;
        ISemesterRepository _semesterRepository;

        public List<ClassDTO> classDTOs { get; set; }
        public List<ClassSubjectDTO> classSubjectDTOs { get; set; }
        public List<TeacherDTO> teacherDTOs { get; set; }
        public List<SubjectDTO> subjectDTOs { get; set; }
        public List<SemesterDTO> semesterDTOs { get; set; }


        public ClassSubjectModel(IClassRepository classRepository, IClassSubjectRepository classSubjectRepository, ITeacherRepository teacherRepository, ISubjectRepository subjectRepository, ISemesterRepository semesterRepository)
        {
            _classRepository = classRepository;
            _classSubjectRepository = classSubjectRepository;
            _teacherRepository = teacherRepository;
            _subjectRepository = subjectRepository;
            _semesterRepository = semesterRepository;

        }

        private void GetData()
        {
            classDTOs = _classRepository.GetList();
            classSubjectDTOs = _classSubjectRepository.GetList();
            teacherDTOs = _teacherRepository.GetList();
            subjectDTOs = _subjectRepository.GetList();
            semesterDTOs = _semesterRepository.GetList();   
        }

        public void OnGet()
        {
            GetData();
        }
        
        public void OnPostCreateClassSubject(int classId, int subjectId, int teacherId, int semesterId)
        {
            ClassSubjectDTO classSubjectDTO = new ClassSubjectDTO()
            {
                ClassId = classId,
                SubjectId = subjectId,
                TeacherId = teacherId,
                SemesterId = semesterId
            };
            _classSubjectRepository.Create(classSubjectDTO);
            GetData();
        }
      

       
    }
}
