﻿using System.Collections.Generic;

namespace Sameer.DesignsAlternatives.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<DesignOption> designOptions { get; set; }

        public SubCategory()
        {
            designOptions = new List<DesignOption>();
        }
    }
}