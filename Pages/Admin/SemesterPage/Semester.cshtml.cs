using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
namespace ProjectPRN_FAP.Pages.Admin
{
    [Authorize(Roles = "1")]
    public class SemesterModel : PageModel
    {

        ISemesterRepository _semesterRepository;

        public List<SemesterDTO> semesterDTOs { get; set; }
        public SemesterModel(ISemesterRepository semesterRepository)
        {
            _semesterRepository = semesterRepository;
        }


        private void GetData()
        {
            semesterDTOs = _semesterRepository.GetList();
        }

        public void OnGet()
        {
            GetData();
        }

        public void OnPost(String semesterName,  DateTime semesterStartDate, DateTime semesterEndDate)
        {
            SemesterDTO semester = new SemesterDTO()
            {
                SemesterName = semesterName,
                StartDate = semesterStartDate,
                EndDate = semesterEndDate,
            };
            _semesterRepository.Create(semester);
            GetData();
        }

        public void OnPostUpdate(String semesterName, DateTime semesterStartDate, DateTime semesterEndDate, int semesterId)
        {
            SemesterDTO semester = _semesterRepository.GetById(semesterId);
            semester.SemesterName = semesterName;
            semester.StartDate = semesterStartDate;
            semester.EndDate = semesterEndDate;
            _semesterRepository.Update(semester);
            GetData();
           
        }

        public void OnPostDelete(int semesterId)
        {
            SemesterDTO semester = _semesterRepository.GetById(semesterId);
            _semesterRepository.Delete(semester);
            GetData();

        }
    }
}
