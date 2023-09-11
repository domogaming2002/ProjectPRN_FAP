using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Models;
using System.Data;

namespace ProjectPRN_FAP.Pages.Teacher.ClassPage
{
    [Authorize(Roles = "2")]
    public class ViewScoreModel : PageModel
    {

        ISubjectGradeRepository _subjectGradeRepository;
        IClassSubjectRepository _classSubjectRepository;
        IClassTranscriptRepository _classTranscriptRepository;
        ITranscriptRepository _transcriptRepository;

        public ClassSubjectDTO classSubjectDTO { get; set; }
        public List<SubjectGradeDTO> subjectGradeDTOs { get; set; }
        public List<ClassTranscriptDTO> classTranscriptDTOs { get; set; }
        public int ClassSubjectId { get; set; }
        public int SubjectId { get; set; }


        public ViewScoreModel(ISubjectGradeRepository subjectGradeRepository, IClassSubjectRepository classSubjectRepository, IClassGradeRepository classGradeRepository, IDetailScoreRepository detailScoreRepository, ITranscriptRepository transcriptRepository, IClassTranscriptRepository classTranscriptRepository)
        {
            _subjectGradeRepository = subjectGradeRepository;
            _classSubjectRepository = classSubjectRepository;
            _classTranscriptRepository = classTranscriptRepository;
            _transcriptRepository = transcriptRepository;
        }

        public void OnGet(int classSubjectId, int subjectId)
        {
            GetData(classSubjectId, subjectId);
        }

        public void GetData(int classSubjectId, int subjectId)
        {
            ClassSubjectId = classSubjectId;
            SubjectId = subjectId;
            classTranscriptDTOs = _classTranscriptRepository.GetList(classSubjectId);
            subjectGradeDTOs = _subjectGradeRepository.GetBySubjectId(subjectId);
            classSubjectDTO = _classSubjectRepository.GetById(classSubjectId);
        }

        public void OnPostUpdateFinalScoore(int classSubjectId, int subjectId)
        {
            classTranscriptDTOs = _classTranscriptRepository.GetList(classSubjectId);
            foreach (ClassTranscriptDTO cs in classTranscriptDTOs)
            {
                _transcriptRepository.Update(cs.TranscriptDTO);
            }
            GetData(classSubjectId, subjectId);
           
        }

  
    }
}
