using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sameer.DesignsAlternatives.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage ="Category name is required !")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<SubCategory> SubCategories { get; set; }

        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
    }
}