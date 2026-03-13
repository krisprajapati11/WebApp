using WebApp.Models;
namespace WebApp.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
          User GetById(int id);

         User Create(User user);

         User Update(User user);

         bool Delete(int id);

    }
}
