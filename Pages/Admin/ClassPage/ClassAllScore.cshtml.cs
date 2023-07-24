using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Pages.Admin.ClassPage
{
    public class ClassAllScoreModel : PageModel
    {

        ISubjectGradeRepository _subjectGradeRepository;
        IClassSubjectRepository _classSubjectRepository;
        ITranscriptRepository _transcriptRepository;
        IDetailScoreRepository _detailScoreRepository;
        IClassGradeRepository _classGradeRepository;
        IClassTranscriptRepository _classTranscriptRepository;

        public List<ClassSubjectDTO> classSubjectDTOs { get; set; }
        public ClassSubjectDTO classSubjectDTO { get; set; }
        public List<StudentClassSubjectDTO> studentClassSubjectDTOs { get; set; }
        public List<StudentDTO> studentDTOs { get; set; }

        public List<SubjectGradeDTO> subjectGradeDTOs { get; set; }
        public List<TranscriptDTO> transcriptDTOs { get; set; }

        public List<ClassTranscriptDTO> classTranscriptDTOs { get; set; }
        public ClassGradeDTO classGradeDTO { get; set; }
        public int GradeId { get; set; }


        public ClassAllScoreModel(ISubjectGradeRepository subjectGradeRepository, IClassSubjectRepository classSubjectRepository, IClassGradeRepository classGradeRepository, IDetailScoreRepository detailScoreRepository, ITranscriptRepository transcriptRepository, IClassTranscriptRepository classTranscriptRepository)
        {
            _subjectGradeRepository = subjectGradeRepository;
            _classGradeRepository = classGradeRepository;
            _classSubjectRepository = classSubjectRepository;
            _detailScoreRepository = detailScoreRepository;
            _transcriptRepository = transcriptRepository;
            _classTranscriptRepository = classTranscriptRepository;
        }

        public void OnGet(int classSubjectId, int subjectId)
        {
            GetData(classSubjectId, subjectId);
        }

        public void GetData(int classSubjectId, int subjectId)
        {
            classTranscriptDTOs = _classTranscriptRepository.GetList(classSubjectId);
            subjectGradeDTOs = _subjectGradeRepository.GetBySubjectId(subjectId);
            classSubjectDTO = _classSubjectRepository.GetById(classSubjectId);
        }
    }
}
