using Sameer.DesignsAlternatives.BusinessLogic;
using Sameer.DesignsAlternatives.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sameer.DesignsAlternatives
{
    public partial class frmDesignAlternativesOptions : Form
    {
        private readonly DesignAlternativesManager designAlternativesManager;
        private readonly DesignAlternativesOptionsManager designAlternativesOptionsManager;

        public frmDesignAlternativesOptions()
        {
            InitializeComponent();
            designAlternativesManager = new DesignAlternativesManager(new DesignAlternativesContext());
            designAlternativesOptionsManager = new DesignAlternativesOptionsManager(new DesignAlternativesContext());
        }

        private async void frmDesignAlternativesOptions_Load(object sender, EventArgs e)
        {
            designAlternativeBindingSource.DataSource = await designAlternativesManager.GetAllDesignAlternatives();

            var allDesignOptions = await designAlternativesOptionsManager.GetAllDesignOptions();

            relatedToWindBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Related To Wind").ToList();
            relatedToViewBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Related To View").ToList();

            buildingFormBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Building Form").ToList();
            facadeMaterialBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Facade Material").ToList();
            glazingPercentageBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Glazing Percentage (G/W Ratio)").ToList();

            planEfficiencyBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Plan Efficiency (W/F Ratio)").ToList();
            shapeComplexityBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Shape Complexity").ToList();

            numberOfStoreyBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Number of Storey").ToList();
            averageStoreyHeightBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Average Storey Height").ToList();

            glazingShapeBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Glazing Shape").ToList();
            glazingEfficiencyBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Glazing Efficiency").ToList();
            sunBreakersGeometryBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Sun-Breakers Geometry").ToList();

            spanDimensionBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Span Dimension").ToList();
            circulationAreaBindingSource.DataSource = allDesignOptions.Where(d => d.SubCategory.Name == "Circulation Area (C/F Ratio)").ToList();
        }
    }
}
