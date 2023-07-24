using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;

namespace ProjectPRN_FAP.Pages.Admin.UserPage
{
    [Authorize(Roles = "1")]
    public class TeacherModel : PageModel
    {
        ITeacherRepository _teacherRepository;
        IUserRepository _userRepository;


        public List<TeacherDTO> teacherDTOs { get; set; }
        public TeacherModel(IUserRepository userRepository, ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
        }


        private void GetData()
        {
            teacherDTOs = _teacherRepository.GetList();
        }

        public void OnGet()
        {
            GetData();
        }

        public void OnPostCreateTeacher(String teacherEmail, String teacherCode, String teacherName, String teacherGender, String teacherPhone, 
            String teacherPassword, DateTime teacherDob, String teacherCampus)
        {
            UserDTO userDTO = new UserDTO()
            {
                Email = teacherEmail,
                Name = teacherName,
                Gender = teacherGender == "true" ? true : false,
                Phone = teacherPhone,
                Password = teacherPassword,
                DateOfBirth = teacherDob,
                Campus = teacherCampus,
                RoleId = 2
            };
            if (_userRepository.CreateUser(userDTO))
            {
                int userId = _userRepository.GetLastInsertUserId();
                TeacherDTO teacherDTO = new TeacherDTO()
                {
                    TeacherCode = teacherCode,
                    UserId = userId
                };
                _teacherRepository.Create(teacherDTO);
                GetData();
                return;
            }
            GetData();


        }

        public void OnPostUpdate(String teacherEmail, String teacherCode, String teacherName, String teacherGender, String teacherPhone, String teacherPassword, 
            DateTime teacherDob, String teacherCampus, int userId, int teacherId)
        {
            UserDTO userDTO = _userRepository.GetUserById(userId);
            userDTO.Name = teacherName;
            userDTO.Gender = teacherGender == "true" ? true : false;
            userDTO.Phone = teacherPhone;
            userDTO.Password = teacherPassword;
            userDTO.DateOfBirth = teacherDob;
            userDTO.Campus = teacherCampus;
            _userRepository.UpdateUser(userDTO);
            TeacherDTO teacherDTO = _teacherRepository.GetById(teacherId);
            teacherDTO.TeacherCode = teacherCode;
            _teacherRepository.Update(teacherDTO);
            GetData();


        }
    }
}
