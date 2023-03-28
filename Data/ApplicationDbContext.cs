using System;
using System.Collections.Generic;
using System.Text;
using ASP_DOT_NET_APP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_DOT_NET_APP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Rozklad_Jazdy> Timetable { get; set; }

        public DbSet<bok> reservatonn { get; set; }
    }
}
