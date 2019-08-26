using Microsoft.EntityFrameworkCore;
 
    namespace chefs_dishes.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users {get;set;}
        public DbSet<Post> Posts {get;set;}
        public DbSet<Post> Votes {get;set;}

    }
}
