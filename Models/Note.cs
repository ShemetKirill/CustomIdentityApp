using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentityApp.Models
{
    public class Note
    {
        public string NoteId { get; set; }

        public string NameNote { get; set; }

        public string Notes { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
