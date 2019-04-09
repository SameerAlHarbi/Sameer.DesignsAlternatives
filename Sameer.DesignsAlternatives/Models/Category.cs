using System.Collections.Generic;

namespace Sameer.DesignsAlternatives.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
    }
}