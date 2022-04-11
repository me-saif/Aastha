using System.ComponentModel.DataAnnotations;

namespace Aastha.Data.ViewModels
{
    public class StudentLoginViewModel
    {
        public string Mobile_No { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}