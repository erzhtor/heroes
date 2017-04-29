namespace Heroes.DataAccessLayer.Migrations
{
    using Heroes.DataAccessLayer.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //Seed Countries
            var kyrgyzstan = new Country { ID = 1, Name = "Kyrgyzstan", CreatedAt = DateTime.Now };
            var russia = new Country { ID = 2, Name = "Russia", CreatedAt = DateTime.Now };
            var usa = new Country { ID = 3, Name = "USA", CreatedAt = DateTime.Now };
            var filari = new Country { ID = 4, Name = "Filari", CreatedAt = DateTime.Now };
            context.Countries.AddOrUpdate(x => x.ID,
                kyrgyzstan, russia, usa, filari
            );

            // Seed Powers
            var fast = new Power { Name = "Very Fast", CreatedAt = DateTime.Now };
            var strong = new Power { Name = "Strong", CreatedAt = DateTime.Now };
            var smart = new Power { Name = "Really Smart", CreatedAt = DateTime.Now };
            var canFly = new Power { Name = "Can Fly", CreatedAt = DateTime.Now };
            var canTeleport = new Power { Name = "Can Teleport", CreatedAt = DateTime.Now };
            var lazy = new Power { Name = "Incredibly Lazy", CreatedAt = DateTime.Now };
            var unknown = new Power { Name = "Unknown", CreatedAt = DateTime.Now };
            context.Powers.AddOrUpdate(x => x.Name,
                fast, strong, smart, canFly, canTeleport, lazy, unknown
            );

            //Seed Heroes
            context.Heroes.AddOrUpdate(x => x.NickName,
                new Hero
                {
                    Country = kyrgyzstan,
                    CreatedAt = DateTime.Now,
                    DateOfBirth = new DateTime(1955, 1, 1),
                    NickName = "Kozhomkul",
                    IsMale = true,
                    Powers =
                        {
                            strong
                        }
                },
                new Hero
                {
                    Country = russia,
                    CreatedAt = DateTime.Now,
                    DateOfBirth = new DateTime(1945, 1, 1),
                    NickName = "Skorohod",
                    IsMale = true,
                    Powers =
                        {
                            fast
                        }
                },
                new Hero
                {
                    Country = usa,
                    CreatedAt = DateTime.Now,
                    DateOfBirth = new DateTime(1955, 1, 1),
                    NickName = "Supergirl",
                    IsMale = false,
                    Powers =
                        {
                            strong, canFly, fast
                        }
                }
            );
        }
    }
}
