using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.DTOs
{
    public class BookUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        
    }
}
