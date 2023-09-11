using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.Bussiness.Repository;

namespace ProjectPRN_FAP.Pages.Admin.ClassPage
{
    [Authorize(Roles = "1")]
    public class ClassModel : PageModel
    {

        IClassRepository _classRepository;

        public List<ClassDTO> classDTOs { get; set; }
        public ClassModel(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        private void GetData()
        {
            classDTOs = _classRepository.GetList();
        }

        public void OnGet()
        {
            GetData();
        }

        public void OnPost(String className)
        {
            ClassDTO classDTO = new ClassDTO()
            {
                ClassName = className,
            };
            _classRepository.Create(classDTO);
            GetData();
        }

        public void OnPostUpdate(String updateClassName, int updateClassid)
        {
            ClassDTO classDTO = _classRepository.GetById(updateClassid);
            classDTO.ClassName = updateClassName;
            _classRepository.Update(classDTO);
            GetData();

        }

        public void OnPostDelete(int deleteClassId)
        {
            ClassDTO classDTO = _classRepository.GetById(deleteClassId);
            _classRepository.Delete(classDTO);
            GetData();

        }
    }
}
