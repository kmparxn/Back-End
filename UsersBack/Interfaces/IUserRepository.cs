using UsersBack.Helpers;
using UsersBack.Models;
using UsersBack.Wrappers;

namespace UsersBack.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll(PaginationFilter paginationFilter);
        Task<User> GetByIdAsync(long id);
        bool Add(User club);
        bool Update(User club);
        bool Delete(User club);
        bool Save();
    }
}
