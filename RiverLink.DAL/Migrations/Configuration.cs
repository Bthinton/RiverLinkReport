namespace RiverLink.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RiverLink.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<RiverLink.DAL.DB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RiverLink.DAL.DB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.VehicleClassess.AddOrUpdate(x => new { x.Price },
                new Models.VehicleClass { Classification = Classifications.None, PriceType = PriceTypes.None, Price = 0, VehicleDescription = "Unknown" },

                new Models.VehicleClass { Classification = Classifications.Class2, PriceType = PriceTypes.RegisteredPlate, Price = 6.00, VehicleDescription = "Medium Vehicle" },
                new Models.VehicleClass { Classification = Classifications.Class2, PriceType = PriceTypes.Transponder, Price = 5.00, VehicleDescription = "Medium Vehicle" },
                new Models.VehicleClass { Classification = Classifications.Class2, PriceType = PriceTypes.UnregisteredPlate, Price = 7.00, VehicleDescription = "Medium Vehicle" },

                new Models.VehicleClass { Classification = Classifications.Class3, PriceType = PriceTypes.RegisteredPlate, Price = 11.00, VehicleDescription = "Large Vehicle" },
                new Models.VehicleClass { Classification = Classifications.Class3, PriceType = PriceTypes.Transponder, Price = 10.00, VehicleDescription = "Large Vehicle" },
                new Models.VehicleClass { Classification = Classifications.Class3, PriceType = PriceTypes.UnregisteredPlate, Price = 12.00, VehicleDescription = "Large Vehicle" },

                new Models.VehicleClass { Classification = Classifications.Class1, PriceType = PriceTypes.RegisteredPlate, Price = 3.00, VehicleDescription = "Passenger Vehicle" },
                new Models.VehicleClass { Classification = Classifications.Class1, PriceType = PriceTypes.Transponder, Price = 2.00, VehicleDescription = "Passenger Vehicle" },
                new Models.VehicleClass { Classification = Classifications.Class1, PriceType = PriceTypes.UnregisteredPlate, Price = 4.00, VehicleDescription = "Passenger Vehicle" }
            );
        }
    }
}
