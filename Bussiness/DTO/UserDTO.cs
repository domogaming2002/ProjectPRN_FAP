using ProjectPRN_FAP.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectPRN_FAP.Bussiness.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public String Name { get; set; }

        public String Email { get; set; }

        public Boolean Gender { get; set; }

        public String Phone { get; set; }

        public String Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String Campus { get; set; }

        public int RoleId { get; set; }
        public bool IsDelete { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
