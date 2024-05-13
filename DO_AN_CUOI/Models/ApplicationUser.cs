using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DO_AN_CUOI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? SDT { get; set; }
    }
}
