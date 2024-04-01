using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace nest_backend.Models
{
    public class AppUser : IdentityUser
    {
        [Required, MaxLength(256)]
        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
