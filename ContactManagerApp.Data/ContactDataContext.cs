using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApp.Data
{
    public class ContactDataContext : DbContext
    {
        public ContactDataContext(DbContextOptions<ContactDataContext> options) : base(options)
        {

        }

        public ContactDataContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Contacts;User Id=username;password=password;TrustServerCertificate=true;Trusted_Connection=true;");
            }
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
