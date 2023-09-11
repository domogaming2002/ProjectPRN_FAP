using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Teacher.ClassPage
{
    [Authorize(Roles = "2")]
    public class UpdateScoreModel : PageModel
    {
        ISubjectGradeRepository _subjectGradeRepository;
        IClassSubjectRepository _classSubjectRepository;
        ITranscriptRepository _transcriptRepository;
        IDetailScoreRepository _detailScoreRepository;
        IClassGradeRepository _classGradeRepository;

        public List<ClassSubjectDTO> classSubjectDTOs { get; set; }
        public ClassSubjectDTO classSubjectDTO { get; set; }
        public List<StudentClassSubjectDTO> studentClassSubjectDTOs { get; set; }
        public List<StudentDTO> studentDTOs { get; set; }

        public List<SubjectGradeDTO> subjectGradeDTOs { get; set; }

        [BindProperty]
        public ClassGradeDTO classGradeDTO { get; set; }
        public int GradeId { get; set; }


        public UpdateScoreModel(ISubjectGradeRepository subjectGradeRepository, IClassSubjectRepository classSubjectRepository, IClassGradeRepository classGradeRepository, IDetailScoreRepository detailScoreRepository)
        {
            _subjectGradeRepository = subjectGradeRepository;
            _classGradeRepository = classGradeRepository;
            _classSubjectRepository = classSubjectRepository;
            _detailScoreRepository = detailScoreRepository;
        }

        public void OnGet(int classSubjectId, int subjectId, int gradeId)
        {
            if (gradeId != 0)
            {
                classGradeDTO = _classGradeRepository.GetData(classSubjectId, gradeId);
                GradeId = gradeId;
            }
            GetData(classSubjectId, subjectId);
        }

        private void GetData(int classSubjectId, int subjectId)
        {
            subjectGradeDTOs = _subjectGradeRepository.GetBySubjectId(subjectId);
            classSubjectDTO = _classSubjectRepository.GetById(classSubjectId);
        }


        public void OnPost(int classSubjectId, int subjectId, int gradeId)
        {
            GetData(classSubjectId, subjectId);
            GradeId = gradeId;
            foreach (DetailScoreDTO mark in classGradeDTO.DetailScores)
            {
                _detailScoreRepository.Update(mark);
            }
            classGradeDTO = _classGradeRepository.GetData(classSubjectId, gradeId);
        }

    }
}
