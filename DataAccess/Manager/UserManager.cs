using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.DataAccess.Manager
{
    public class UserManager
    {

        DataContext _context;
        public UserManager(DataContext context)
        { _context = context; }

        public List<User>? GetListUser()
        {
            return _context.Users.Include(u => u.Students).Include(u => u.Teachers).Where(u => u.IsDelete == false).ToList();
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId && u.IsDelete == false);
        }

        public User? GetUserLogin(string userEmail, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Trim() == userEmail.Trim() && u.Password.Trim() == password.Trim() && u.IsDelete == false);
        }

        public Boolean CreateUser(User user)
        {
            if(_context.Users.FirstOrDefault(u => u.Email == user.Email && u.IsDelete == false) == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean DelelteUser(User user)
        {
            try
            {
                User userDelete = GetUserById(user.UserId);
                userDelete.IsDelete = true;
                _context.Users.Remove(userDelete);
                _context.SaveChanges();
                    return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Boolean UpdateUser(User user)
        {
            try
            {
                User userUpdate = GetUserById(user.UserId);
                userUpdate.Name = user.Name;
                userUpdate.Email = user.Email;
                userUpdate.Gender = user.Gender;
                userUpdate.Phone = user.Phone;
                userUpdate.Password = user.Password;
                userUpdate.DateOfBirth = user.DateOfBirth;
                userUpdate.Campus = user.Campus;
                _context.Users.Update(userUpdate);
                _context.SaveChanges();
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int GetLastInsertUserId()
        {
            User? user = _context.Users.OrderBy(o => o.UserId).LastOrDefault();
            return user != null ? user.UserId : 0;
        }


    }
}
