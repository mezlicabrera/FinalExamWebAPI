using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FinalExamWebAPI.Models;


namespace FinalExamWebAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Participant> Participants { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
