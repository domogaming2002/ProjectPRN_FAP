using Microsoft.EntityFrameworkCore;
using PRN221_Project_RazorPage.DataAccess.Data;
using PRN221_Project_WPF.DataAccess.Models;

namespace PRN221_Project_RazorPage.DataAccess.Manager
{
    public class UserManager
    {

        DataContext _context;
        public UserManager(DataContext context)
        { _context = context; }

        public List<User>? GetListUser()
        {
            return _context.Users.Include(u => u.Students).Include(u => u.Teachers).ToList();
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public Boolean CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean DelelteUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
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
                _context.Users.Update(user);
                _context.SaveChanges();
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
