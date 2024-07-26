using Microsoft.EntityFrameworkCore;

namespace FanApp.Common.Models.Database.HasDataExtensions
{
    public static class HasDataExtensions
    {
        public static void ApplyHasData(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyUserHasData();
        }
    }
}
