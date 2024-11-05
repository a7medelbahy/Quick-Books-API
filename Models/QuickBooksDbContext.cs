using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Quick_Books.Models
{
    public class QuickBooksDbContext: IdentityDbContext<ApplicationUser>
    {
        public QuickBooksDbContext(DbContextOptions<QuickBooksDbContext> options): base(options) { 
            
        }

        public DbSet<Book> Books { get; set;}
    }
}
