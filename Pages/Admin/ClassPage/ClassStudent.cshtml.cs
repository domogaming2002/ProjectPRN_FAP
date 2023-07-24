using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.Bussiness.Repository;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Pages.Admin.ClassPage
{
    public class ClassStudentModel : PageModel
    {

        IClassSubjectRepository _classSubjectRepository;
        IStudentClassSubjectRepository _studentClassSubjectRepository;
        IStudentRepository _studentRepository;
        ITranscriptRepository _transcriptRepository;
        ISubjectGradeRepository _subjectGradeRepository;
        IDetailScoreRepository _detailScoreRepository;

        public List<ClassSubjectDTO> classSubjectDTOs { get; set; }
        public ClassSubjectDTO classSubjectDTO { get; set; }
        public List<StudentClassSubjectDTO> studentClassSubjectDTOs { get; set; }
        public List<StudentDTO> studentDTOs { get; set; }


        public ClassStudentModel(IClassSubjectRepository classSubjectRepository, IStudentClassSubjectRepository studentClassSubjectRepository, IStudentRepository studentRepository, ITranscriptRepository transcriptRepository, ISubjectGradeRepository subjectGradeRepository, IDetailScoreRepository detailScoreRepository)
        {
            _classSubjectRepository = classSubjectRepository;
            _studentClassSubjectRepository = studentClassSubjectRepository;
            _studentRepository = studentRepository;
            _transcriptRepository = transcriptRepository;
            _subjectGradeRepository = subjectGradeRepository;
            _detailScoreRepository = detailScoreRepository;
        }

        public void OnGet(int classSubjectId)
        {
            GetData(classSubjectId);
        }

        private IActionResult GetData(int classSubjectId)
        {
            classSubjectDTO = _classSubjectRepository.GetById(classSubjectId);
            if (classSubjectDTO == null)
            {
                return RedirectToPage("/Admin/ClassPage/ClassSubject");
            }
            studentClassSubjectDTOs = _studentClassSubjectRepository.GetListByClassSubjectId(classSubjectId);
            studentDTOs = _studentRepository.GetList();
            return Page();
        }

        public void OnPostAddStudentToClass(int classSubjectId, int studentId, int subjectId)
        {
            StudentClassSubjectDTO s = new StudentClassSubjectDTO()
            {
                ClasSubjectId = classSubjectId,
                StudentId = studentId
            };
            if (_studentClassSubjectRepository.Create(s))
            {
                TranscriptDTO t = new TranscriptDTO()
                {
                    SubjectId = subjectId,
                    ClassSubjectId = classSubjectId,
                    StudentId = studentId,
                    TotalScore = 0,
                };
                _transcriptRepository.Create(t);
                int transcriptId = _transcriptRepository.GetLastInsertTranscriptId();
                List<SubjectGradeDTO> subject = _subjectGradeRepository.GetBySubjectId(subjectId);
                foreach (SubjectGradeDTO sg in subject)
                {
                    DetailScoreDTO detailScoreDTO = new DetailScoreDTO()
                    {
                        TranscriptId = transcriptId,
                        GradeId = sg.GradeId,
                        Score = 0,
                    };
                    _detailScoreRepository.Create(detailScoreDTO);
                }
                
            }
            GetData(classSubjectId);

        }
    }
}
