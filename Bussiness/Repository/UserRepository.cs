using AutoMapper;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.Bussiness.IRepository;
using ProjectPRN_FAP.DataAccess.Data;
using ProjectPRN_FAP.DataAccess.Manager;
using ProjectPRN_FAP.DataAccess.Models;
using ProjectPRN_FAP.Models;

namespace ProjectPRN_FAP.Bussiness.Repository
{
    public class UserRepository : IUserRepository
    {
        UserManager manager;
        DataContext _context;
        IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            manager = new UserManager(_context);
        }
        public bool CreateUser(UserDTO userDTO)
        {

            if (GetUserById(userDTO.UserId) == null)
            {
                return manager.CreateUser(_mapper.Map<User>(userDTO));
            }
            else
            {
                return false;
            }
        }

        public bool DelelteUser(UserDTO userDTO)
        {
            if (GetUserById(userDTO.UserId) != null)
            {
                manager.DelelteUser(_mapper.Map<User>(userDTO));
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetLastInsertUserId()
        {
            return manager.GetLastInsertUserId();
        }

        public List<UserDTO>? GetListUser()
        {
            return _mapper.Map<List<UserDTO>>(manager.GetListUser());
        }

        public UserDTO? GetUserById(int userId)
        {
            return _mapper.Map<UserDTO>(manager.GetUserById(userId));
        }

        public bool UpdateUser(UserDTO userDTO)
        {
            if (GetUserById(userDTO.UserId) != null)
            {
                manager.UpdateUser(_mapper.Map<User>(userDTO));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
