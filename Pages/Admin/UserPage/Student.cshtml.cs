using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Admin.UserPage
{
    public class StudentModel : PageModel
    {

        IStudentRepository _studentRepository;
        IUserRepository _userRepository;


        public List<StudentDTO> studentDTOs { get; set; }
        public StudentModel(IStudentRepository studentRepository, IUserRepository userRepository)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
        }


        private void GetData()
        {
            studentDTOs = _studentRepository.GetList();
        }

        public void OnGet()
        {
            GetData();
        }

        public void OnPostCreateStudent(String studentEmail, String studentCode, String studentName, String studentGender, String studentPhone, String studentPassword, DateTime studentDob, String studentCampus)
        {
            UserDTO userDTO = new UserDTO()
            {
                Email = studentEmail,
                Name = studentName,
                Gender = studentGender == "true" ? true : false,
                Phone = studentPhone,
                Password = studentPassword,
                DateOfBirth = studentDob,
                Campus = studentCampus,
                RoleId = 1
            };
            _userRepository.CreateUser(userDTO);


        }
    }
}
