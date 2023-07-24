using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Teacher.ClassPage
{
    public class ViewScoreModel : PageModel
    {

        ISubjectGradeRepository _subjectGradeRepository;
        IClassSubjectRepository _classSubjectRepository;
        IClassTranscriptRepository _classTranscriptRepository;

        public ClassSubjectDTO classSubjectDTO { get; set; }
        public List<SubjectGradeDTO> subjectGradeDTOs { get; set; }
        public List<ClassTranscriptDTO> classTranscriptDTOs { get; set; }
        public int GradeId { get; set; }


        public ViewScoreModel(ISubjectGradeRepository subjectGradeRepository, IClassSubjectRepository classSubjectRepository, IClassGradeRepository classGradeRepository, IDetailScoreRepository detailScoreRepository, ITranscriptRepository transcriptRepository, IClassTranscriptRepository classTranscriptRepository)
        {
            _subjectGradeRepository = subjectGradeRepository;
            _classSubjectRepository = classSubjectRepository;
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
