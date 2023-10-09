using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace Pos8Company.Web.Models
{
    public partial class Positive8WebSiteContext : DbContext
    {

      public virtual DbSet<OffersContact> OffersContact { get; set; }
        public virtual DbSet<BusinessContact> BusinessContact { get; set; }

        public Positive8WebSiteContext(DbContextOptions<Positive8WebSiteContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BusinessContact>(entity =>
            {
                entity.Property(e => e.BusinessContactID);
                entity.Property(e => e.Title);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.OrganisationEmail);
                entity.Property(e => e.TelephoneNumber);
                entity.Property(e => e.MobileNumber);
                entity.Property(e => e.IncludeInMailingLIst);
                entity.Property(e => e.Message);


            });

            modelBuilder.Entity<OffersContact>(entity =>
            {
                entity.Property(e => e.OffersContactID);
                entity.Property(e => e.Title);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.OrganisationEmail);
                entity.Property(e => e.TelephoneNumber);
                entity.Property(e => e.MobileNumber);
                entity.Property(e => e.IncludeInMailingLIst);
                entity.Property(e => e.Message);
            });

         }
    }
}
