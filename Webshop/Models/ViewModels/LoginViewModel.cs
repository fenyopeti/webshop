using System.ComponentModel.DataAnnotations;

namespace Webshop.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = nameof(Resources.ModelValidation.EmailRequired))]
        [Display(Name = "Email", ResourceType = typeof(Resources.Auth))]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Auth))]
        [Required(ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = nameof(Resources.ModelValidation.PasswordRequired))]
        public string Password { get; set; }
    }
}