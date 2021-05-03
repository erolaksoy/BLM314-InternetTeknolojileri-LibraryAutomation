using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.DTOs
{
    public class UserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
