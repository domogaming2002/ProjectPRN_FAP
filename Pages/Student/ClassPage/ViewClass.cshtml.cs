using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.Bussiness.Repository;
using System.Security.Claims;

namespace ProjectPRN_FAP.Pages.Student.ClassPage
{
    [Authorize(Roles = "3")]
    public class ViewClassModel : PageModel
    {

        ITranscriptRepository _transcriptRepository;
        IStudentRepository _studentRepository;
        IClassTranscriptRepository _classTranscriptRepository;
        ISubjectGradeRepository _subjectGradeRepository;
        public List<TranscriptDTO> transcriptDTOs { get; set; }
        public List<SubjectGradeDTO> subjectGradeDTOs { get; set; }
        public StudentDTO studentDTO { get; set; }
        public ClassTranscriptDTO classTranscriptDTO { get; set; }
        public int TranscriptId { get; set; }
        public ViewClassModel(ITranscriptRepository transcriptRepository, IStudentRepository studentRepository, IClassTranscriptRepository classTranscriptRepository, ISubjectGradeRepository subjectGradeRepository )
        {
            _transcriptRepository = transcriptRepository;  
            _studentRepository = studentRepository;
            _classTranscriptRepository = classTranscriptRepository;
            _subjectGradeRepository = subjectGradeRepository;
        }
        public void OnGet(int transcriptId, int subjectId)
        {
            if(transcriptId != 0)
            {
                classTranscriptDTO = _classTranscriptRepository.GetOneStudentTranscript(transcriptId);
                subjectGradeDTOs = _subjectGradeRepository.GetBySubjectId(subjectId);
                TranscriptId = transcriptId;
            }
            GetData();
        }

        public void GetData()
        {
            String userId = HttpContext.User.FindFirstValue(ClaimTypes.Sid);
            studentDTO = _studentRepository.GetByUserId(Int32.Parse(userId));
            transcriptDTOs = _transcriptRepository.GetByStudentId(studentDTO.StudentId);
        }
    }
}
