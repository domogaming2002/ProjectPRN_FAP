using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Admin.UserPage
{
    [Authorize(Roles = "1")]
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
                RoleId = 3
            };
            if (_userRepository.CreateUser(userDTO))
            {
                int userId = _userRepository.GetLastInsertUserId();
                StudentDTO studentDTO = new StudentDTO()
                {
                    StudentCode = studentCode,
                    UserId = userId
                };
                _studentRepository.Create(studentDTO);
                GetData();
                return;
            }
            GetData();


        }

        public void OnPostUpdate(String studentEmail, String studentCode, String studentName, String studentGender, String studentPhone, String studentPassword, DateTime studentDob, String studentCampus, int userId, int studentId)
        {
            UserDTO userDTO = _userRepository.GetUserById(userId);
            userDTO.Name = studentName;
            userDTO.Gender = studentGender == "true" ? true : false;
            userDTO.Phone = studentPhone;
            userDTO.Password = studentPassword;
            userDTO.DateOfBirth = studentDob;
            userDTO.Campus = studentCampus;
            _userRepository.UpdateUser(userDTO);
            StudentDTO studentDTO = _studentRepository.GetById(studentId);
            studentDTO.StudentCode = studentCode;
            _studentRepository.Update(studentDTO);
            GetData();


        }

    }
}
