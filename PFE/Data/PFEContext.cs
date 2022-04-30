#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PFE.Auth;
using PFE.Models;

namespace PFE.Data
{
    public class PFEContext : IdentityDbContext<ApplicationUser>
    {
        public PFEContext (DbContextOptions<PFEContext> options)
            : base(options)
        {
        }

        /*public DbSet<PFE.Models.Chef> Chefs { get; set; }*/
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }

        public DbSet<PFE.Models.Etudiant> Etudiants { get; set; }
        public DbSet<PFE.Models.Encadrant> Encadrants { get; set; }

        public DbSet<PFE.Models.Admin> Admins { get; set; }
        public DbSet<PFE.Models.Soutenance> Soutenance { get; set; }
        public DbSet<PFE.Models.PFEModel> PFEs { get; set; }
    }
}
 