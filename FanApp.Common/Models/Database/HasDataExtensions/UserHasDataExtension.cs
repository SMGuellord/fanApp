using Microsoft.EntityFrameworkCore;

namespace FanApp.Common.Models.Database.HasDataExtensions
{
    public static class UserHasDataExtension
    {
        public static ModelBuilder ApplyUserHasData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Fistname = "Guellord",
                        Lastname = "Muhiya",
                        DOB = DateTime.Now,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Fistname = "Leah",
                        Lastname = "Muhiya",
                        DOB = DateTime.Now,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                    },
                    new User
                    {
                        Id = Guid.NewGuid(),
                        Fistname = "Gleah",
                        Lastname = "Muhiya",
                        DOB = DateTime.Now,
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                    }
                );
            return modelBuilder;
        }
    }
}
