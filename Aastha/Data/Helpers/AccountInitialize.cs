using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Aastha.Data.Helpers
{
     public class AccountInitialize:IAccountInitialize
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountInitialize(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedData()
        {
            
            var adminRole = new IdentityRole("Admin");
            var userRole = new IdentityRole("User");

            if (!_roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>(){adminRole,userRole};
                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).GetAwaiter().GetResult();
                }
            }


            if (_userManager.Users.Any()) return;
            

            var adminUser = new IdentityUser()
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };
            var normalUser = new IdentityUser()
            {
                UserName = "user",
                Email = "user@gmail.com"
            };

            _userManager.CreateAsync(adminUser, "admin@123").GetAwaiter().GetResult();
            _userManager.CreateAsync(normalUser, "user@123").GetAwaiter().GetResult();

            _userManager.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(normalUser, userRole.Name).GetAwaiter().GetResult();
        }
    }

    public interface IAccountInitialize
    {
        void SeedData();
    }
}