using LibraryAutomation.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.Context.ModelMaps
{
    public class BorrowBookMap : IEntityTypeConfiguration<BorrowBook>
    {
        public void Configure(EntityTypeBuilder<BorrowBook> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.User).WithMany(x => x.BorrowBooks).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Book).WithMany(x => x.BorrowBooks).HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
