using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.Bussiness.Repository;
using ProjectPRN_FAP.DataAccess.Models;
using System.Data;

namespace ProjectPRN_FAP.Pages.Admin.ClassPage
{
    [Authorize(Roles = "1")]
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
        public List<StudentDTO> studentNotInClassDTOs { get; set; }


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

        private void GetData(int classSubjectId)
        {
            classSubjectDTO = _classSubjectRepository.GetById(classSubjectId);
            studentClassSubjectDTOs = _studentClassSubjectRepository.GetListByClassSubjectId(classSubjectId);
            studentDTOs = _studentRepository.GetList();
            for (int i = studentDTOs.Count - 1; i >= 0; i--)
            {
                StudentDTO s = studentDTOs[i];
                foreach (StudentClassSubjectDTO sc in studentClassSubjectDTOs)
                {
                    if (sc.StudentId == s.StudentId)
                    {
                        studentDTOs.RemoveAt(i);
                        break;
                    }
                }
            }
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

        public void OnPostDeleteStudentFromClass(int studentClassSubjectId, int studentId, int classSubjectId, int subjectId)
        {
            StudentClassSubjectDTO s = new StudentClassSubjectDTO()
            {
                StudentClassSubjectId = studentClassSubjectId,
            };

            _studentClassSubjectRepository.Delelte(s);
            TranscriptDTO t = _transcriptRepository.GetByAllId(classSubjectId, studentId, subjectId);
            _transcriptRepository.Delelte(t);
            List<DetailScoreDTO> d = _detailScoreRepository.GetByTranscriptId(t.TranscriptId);
            foreach(DetailScoreDTO dTO in d)
            {
                _detailScoreRepository.Delelte(dTO);
            }
            GetData(classSubjectId);


        }
    }
}
