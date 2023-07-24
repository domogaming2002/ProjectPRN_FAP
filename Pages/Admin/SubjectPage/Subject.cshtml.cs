using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Admin.SubjectPage
{
    [Authorize(Roles = "1")]
    public class SubjectModel : PageModel
    {
        ISubjectRepository _subjectRepository;

        public List<SubjectDTO> subjectDTOs { get; set; }
        public SubjectModel(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }


        private void GetData()
        {
            subjectDTOs = _subjectRepository.GetList();
        }

        public void OnGet()
        {
            GetData();
        }

        public void OnPost(String subjectSubName, String subjectNameName)
        {
            SubjectDTO subjectDTO = new SubjectDTO()
            {
                SubjectSubName = subjectSubName,
                SubjectName = subjectNameName,
            };
            _subjectRepository.Create(subjectDTO);
            GetData();
        }

        public void OnPostUpdate(String updateSubjectSubName, String updateSubjectName, int updateSubjectId)
        {
            SubjectDTO subjectDTO = _subjectRepository.GetById(updateSubjectId);
            subjectDTO.SubjectSubName = updateSubjectSubName;
            subjectDTO.SubjectName = updateSubjectName;
            _subjectRepository.Update(subjectDTO);
            GetData();

        }

        public void OnPostDelete(int subjectId)
        {
            SubjectDTO subjectDTO = _subjectRepository.GetById(subjectId);
            _subjectRepository.Delete(subjectDTO);
            GetData();

        }
    }
}
