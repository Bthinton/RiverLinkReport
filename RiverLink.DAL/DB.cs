using RiverLink.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverLink.DAL
{
    public class DB : DbContext
    {
        public DB() : base("RLinkDBConnection")
        {          
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Transponder> Transponders { get; set; }
        public DbSet<VehicleClass> VehicleClasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

