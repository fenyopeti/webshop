using System.ComponentModel.DataAnnotations;

namespace Webshop.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(Resources.Auth))]
        [Required(ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = nameof(Resources.ModelValidation.NameRequired))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = nameof(Resources.ModelValidation.PasswordRequired))]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = nameof(Resources.ModelValidation.PasswordMinLength))]
        [Display(Name = "Password", ResourceType = typeof(Resources.Auth))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = nameof(Resources.ModelValidation.EmailRequired))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.ModelValidation), ErrorMessageResourceName = nameof(Resources.ModelValidation.EmailFormat))]
        [Display(Name = "Email", ResourceType = typeof(Resources.Auth))]
        public string Email { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Resources.Auth))]
        public string Phone { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources.Auth))]
        public string Address { get; set; }
    }
}