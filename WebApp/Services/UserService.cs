using WebApp.Data;
using WebApp.DTOs;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, AppDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            //return _context.Users.ToList();
            return _userRepository.GetAll();
        }

        public User CreateUser(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            //_context.Users.Add(user);
            //_context.SaveChanges();

            //return user;

            return _userRepository.Create(user);
        }

        public User UpdateUser(int id, UpdateUserDto dto)
        {
            //var user = _context.Users.Find(id);
            var user = _userRepository.GetById(id);

            if (user == null) return null;

            user.Name = dto.Name;
            user.Email = dto.Email;

            //_context.SaveChanges();

            //return user;
            return _userRepository.Update(user);
        }

        public bool DeleteUser(int id)
        {
            //var user = _context.Users.Find(id);
            //var user = _userRepository.GetById(id);

            //if (user == null) return false;

            //_context.Users.Remove(user);
            //_context.SaveChanges();

            //return true;
            return _userRepository.Delete(id);
        }

        public User UpdateUser(UpdateUserDto dto)
        {
            throw new NotImplementedException();
        }
        //public User UserService(UserService user)
        //{
        //    throw new NotImplementedException();
        //}
    }
}