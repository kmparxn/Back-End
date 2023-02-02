using UsersBack.Models;

namespace UsersBack.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByIdAsync(long id);
        bool Add(User club);
        bool Update(User club);
        bool Delete(User club);
        bool Save();
    }
}
