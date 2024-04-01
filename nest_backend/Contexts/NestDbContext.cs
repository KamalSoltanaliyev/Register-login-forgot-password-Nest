using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nest_backend.Models;

namespace nest_backend.Contexts
{
    public class NestDbContext : IdentityDbContext<AppUser>
    {
        public NestDbContext(DbContextOptions<NestDbContext> options) : base(options) 
        {
        }
    }
}
