namespace Sameer.DesignsAlternatives.Models
{
    public class DesignOption
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }
    }
}