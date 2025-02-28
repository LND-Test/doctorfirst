using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using TodoApi1.Models;

namespace TodoApi1
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }


        // Add DbSets for your models
        public DbSet<User> Users { get; set; }
        public DbSet<AuthModels.VerifyOtpDto> OTPs { get; set; }
    }
}
