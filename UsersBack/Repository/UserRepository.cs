using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UsersBack.Data;
using UsersBack.Helpers;
using UsersBack.Interfaces;
using UsersBack.Models;

namespace UsersBack.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public async Task<IEnumerable<User>> GetAll(PaginationFilter paginationFilter)
        {
            return await _context.Users.Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
                .Take(paginationFilter.PageSize).ToListAsync();
        }

        public async Task<User> GetByIdAsync(long id)
        {
            return _context.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _context.Update(user);
            return Save();
        }
    }


}
