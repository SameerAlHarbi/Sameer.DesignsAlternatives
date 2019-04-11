using Sameer.DesignsAlternatives.DataAccess;
using Sameer.DesignsAlternatives.Models;
using System;
using System.Threading.Tasks;

using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Sameer.DesignsAlternatives.BusinessLogic
{
    public class DesignAlternativesOptionsManager : IDisposable
    {
        private readonly DesignAlternativesContext designAlternativesContext;
        private List<DesignOption> designOptions;

        public List<DesignOption> AllDesignOption
        {
            get { return designOptions; }
            set { designOptions = value; }
        }


        public DesignAlternativesOptionsManager(DesignAlternativesContext designAlternativesContext)
        {
            this.designAlternativesContext = designAlternativesContext;
        }

        public async Task<List<DesignOption>> GetAllDesignOptions()
        {
            try
            {
                var Categories = await designAlternativesContext.Categories.Include(c => c.SubCategories.Select(s => s.designOptions)).ToListAsync();
                return Categories.SelectMany(c => c.SubCategories.SelectMany(s => s.designOptions)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            designAlternativesContext.Dispose();
        }
    }
}
