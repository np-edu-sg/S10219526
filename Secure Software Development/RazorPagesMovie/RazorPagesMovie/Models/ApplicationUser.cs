using System;
using Microsoft.AspNetCore.Identity;

namespace RazorPagesMovie.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
    }
}