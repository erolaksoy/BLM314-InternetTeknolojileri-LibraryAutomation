﻿using LibraryAutomation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.DTOs
{
    public class BorrowBookDto
    {
        public DateTime ReceivedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}