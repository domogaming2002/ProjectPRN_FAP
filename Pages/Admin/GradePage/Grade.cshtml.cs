using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Models;
using System.Data;

namespace ProjectPRN_FAP.Pages.Admin.GradePage
{
    [Authorize(Roles = "1")]
    public class GradeModel : PageModel
    {
        IGradeRepository _gradeRepository;

        public List<GradeDTO> gradeDTOs { get; set; }
        public GradeModel(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }


        private void GetData()
        {
            gradeDTOs = _gradeRepository.GetList();
        }

        public void OnGet()
        {
            GetData();
        }

        public void OnPost(String gradeName, int percent)
        {
            if(percent <= 0 || percent > 100)
            {
                TempData["ErrorMessage"] = "Percent must be between 0 and 100.";
            }
            GradeDTO gradeDTO = new GradeDTO()
            {
                GradeName = gradeName,
                Percent = percent,
            };
            _gradeRepository.Create(gradeDTO);
            GetData();
        }

        public void OnPostUpdate(String gradeName, int percent, int gradeId)
        {
            GradeDTO gradeDTO = _gradeRepository.GetById(gradeId);
            gradeDTO.GradeName = gradeName;
            gradeDTO.Percent = percent;
            _gradeRepository.Update(gradeDTO);
            GetData();

        }

        public void OnPostDelete(int gradeId)
        {
            GradeDTO gradeDTO = _gradeRepository.GetById(gradeId);
            _gradeRepository.Delete(gradeDTO);
            GetData();

        }
    }
}
