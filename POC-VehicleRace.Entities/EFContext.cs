using POC_VehicleRace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_VehicleRace.Entities
{
    public class EFContext:DbContext
    {
        public EFContext() : base("RacingDbConnString")
        { }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
