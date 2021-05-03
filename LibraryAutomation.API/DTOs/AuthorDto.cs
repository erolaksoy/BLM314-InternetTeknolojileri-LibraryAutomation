using LibraryAutomation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.DTOs
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
