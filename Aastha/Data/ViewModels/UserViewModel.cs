using System.Collections.Generic;

namespace Aastha.Data.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<RoleViewModel> UserInRoles {get; set;}
    }
}