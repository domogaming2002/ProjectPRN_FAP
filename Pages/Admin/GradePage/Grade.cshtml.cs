using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Admin.GradePage
{
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
            if(percent == 0)
            {
                TempData["ErrorMessage"] = "Percent must be between 0 and 100.";
            }
            //SemesterDTO semester = new SemesterDTO()
            //{
            //    SemesterName = semesterName,
            //    StartDate = semesterStartDate,
            //    EndDate = semesterEndDate,
            //};
            //_semesterRepository.Create(semester);
            GetData();
        }

        public void OnPostUpdate(String semesterName, DateTime semesterStartDate, DateTime semesterEndDate, int semesterId)
        {
            //SemesterDTO semester = _semesterRepository.GetById(semesterId);
            //semester.SemesterName = semesterName;
            //semester.StartDate = semesterStartDate;
            //semester.EndDate = semesterEndDate;
            //_semesterRepository.Update(semester);
            //GetData();

        }

        public void OnPostDelete(int semesterId)
        {
            //SemesterDTO semester = _semesterRepository.GetById(semesterId);
            //_semesterRepository.Delete(semester);
            //GetData();

        }
    }
}
