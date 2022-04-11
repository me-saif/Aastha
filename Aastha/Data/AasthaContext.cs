using Aastha.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aastha.Data
{
    public class AasthaContext:IdentityDbContext
    {
        public AasthaContext(DbContextOptions<AasthaContext> options):base(options)
        {

        }

        public DbSet<Student> Student_Master { get; set; }
        public DbSet<FeeCollection> FeeCollection_Master { get; set; }
    }
}
