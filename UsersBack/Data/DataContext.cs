using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UsersBack.Models;

namespace UsersBack.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        // Tables
        public DbSet<User> Users { get; set; }


    }
}
