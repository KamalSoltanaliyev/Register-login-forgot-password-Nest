using System.ComponentModel.DataAnnotations;

namespace nest_backend.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
