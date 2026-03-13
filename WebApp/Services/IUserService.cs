using WebApp.DTOs;
using WebApp.Models;
namespace WebApp.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User CreateUser(CreateUserDto dto);
        User UpdateUser(int id , UpdateUserDto dto);
        bool DeleteUser(int id);
    }
}
