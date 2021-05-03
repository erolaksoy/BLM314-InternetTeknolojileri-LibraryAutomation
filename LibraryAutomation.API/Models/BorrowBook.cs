using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.Models
{
    public class BorrowBook
    {
        public int Id { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
