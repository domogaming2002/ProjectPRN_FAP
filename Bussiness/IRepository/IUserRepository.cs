using Microsoft.EntityFrameworkCore;
using ProjectPRN_FAP.Bussiness.DTO;
using ProjectPRN_FAP.DataAccess.Models;

namespace ProjectPRN_FAP.Bussiness.IRepository
{
    public interface IUserRepository
    {
        List<UserDTO>? GetListUser();

        UserDTO? GetUserById(int userId);

        Boolean CreateUser(UserDTO userDTO);

        Boolean DelelteUser(UserDTO userDTO);

        Boolean UpdateUser(UserDTO userDTO);

        int GetLastInsertUserId();
    }
}
