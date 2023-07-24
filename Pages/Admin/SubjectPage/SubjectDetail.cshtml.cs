using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Models;
using System.Data;

namespace ProjectPRN_FAP.Pages.Admin.SubjectPage
{
    [Authorize(Roles = "1")]
    public class SubjectDetailModel : PageModel
    {
        ISubjectRepository _subjectRepository;
        IGradeRepository _gradeRepository;
        ISubjectGradeRepository _subjectGradeRepository;
        public List<SubjectDTO> subjectDTOs { get; set; }
        public List<GradeDTO> gradeDTOs { get; set; }
        public List<SubjectGradeDTO> subjectGradeDTOs { get; set; }
        public SubjectDTO subject { get; set; }
        public SubjectDetailModel(ISubjectRepository subjectRepository, IGradeRepository gradeRepository, ISubjectGradeRepository subjectGradeRepository)
        {
            _subjectRepository = subjectRepository;
            _gradeRepository = gradeRepository;
            _subjectGradeRepository = subjectGradeRepository;
        }
        public void OnGet(int subjectId)
        {
            GetData(subjectId);
        }

        public IActionResult GetData(int subjectId)
        {

            subject = _subjectRepository.GetById(subjectId);
            if (subject == null)
            {
                return RedirectToPage("/Admin/SubjectPage/Subject");
            }
            gradeDTOs = _gradeRepository.GetList();
            subjectGradeDTOs = _subjectGradeRepository.GetBySubjectId(subjectId);
            return Page();

        }

        public void OnPostAddGradeSubject(int gradeId, int subjectId)
        {
            SubjectGradeDTO subjectGradeDTO = new SubjectGradeDTO();
            subjectGradeDTO.SubjectId = subjectId;
            subjectGradeDTO.GradeId = gradeId;
            _subjectGradeRepository.Create(subjectGradeDTO);
            GetData(subjectId);
        }

    }
}
