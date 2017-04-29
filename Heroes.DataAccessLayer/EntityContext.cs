using Heroes.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Heroes.DataAccessLayer
{
    public class EntityContext : DbContext
    {
        public EntityContext() : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Hero> Heroes { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Power> Powers { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Hero>()
                .HasMany(x => x.Powers)
                .WithMany(x => x.Heroes)
                .Map(x =>
                {
                    x.MapLeftKey("HeroID");
                    x.MapRightKey("PowerID");
                    x.ToTable("HeroesToPowers");
                });

            builder.Entity<Country>()
                .HasMany(x => x.Heroes)
                .WithRequired(x => x.Country)
                .HasForeignKey(x => x.CountryID);
        }
    }
}
