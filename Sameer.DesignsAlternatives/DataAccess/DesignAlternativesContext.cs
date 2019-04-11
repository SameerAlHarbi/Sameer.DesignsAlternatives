using Sameer.DesignsAlternatives.Models;
using System.Data.Entity;

namespace Sameer.DesignsAlternatives.DataAccess
{
    public class DesignAlternativesContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<DesignOption> DesignOptions { get; set; }

        public DbSet<DesignAlternative> DesignAlternatives { get; set; }
    }
}
