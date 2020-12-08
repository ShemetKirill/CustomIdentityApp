using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CustomIdentityApp.Models
{
    public class User: IdentityUser  
    {
        public int Year { get; set; }

        public List<Note> Notes { get; set; }
    }
}
