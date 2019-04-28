using Sameer.DesignsAlternatives.Models;
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
    public partial class frnSubCriteriaHints : Form
    {
        private List<DesignOption> _allDesignOptions;
        private DesignAlternative _designAlternative;
        public frnSubCriteriaHints(List<DesignOption> allDesignOptions)
        {
            InitializeComponent();
            _allDesignOptions = allDesignOptions;
            _designAlternative = new DesignAlternative();
        }

        private void frnSubCriteriaHints_Load(object sender, EventArgs e)
        {
            designAlternativeBindingSource.DataSource = _designAlternative;
            designAlternativeBindingSource.ResetBindings(false);
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (locked)
            {
                return;
            }
            locked = true;
            bool allChecked = true;
            foreach (var chk in groupBox8.Controls.OfType<CheckBox>())
            {
                if(!chk.Checked && chk != chkAll)
                {
                    allChecked = false;
                    break;
                }
            }
            chkAll.Checked = allChecked;
            locked = false;
            showBestOptions();
        }

        private void showBestOptions()
        {
            //check if all unchecked
            if (!groupBox8.Controls.OfType<CheckBox>().Except(new List<CheckBox> { chkAll }).Any(chk => chk.Checked))
            {
                _designAlternative = new DesignAlternative();
                designAlternativeBindingSource.DataSource = _designAlternative;
                designAlternativeBindingSource.ResetBindings(false);
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            var groupedOptions = _allDesignOptions.GroupBy(o => o.SubCategoryId);
            var bestOptionsList = groupedOptions.Select(g => g.OrderByDescending(d =>
              (chkAccessibility.Checked ? d.Accessibility * 0.102m : 0) +
              (chkRelation.Checked ? d.Relation * 0.106m : 0) +
              (chkSize.Checked ? d.Size * 0.116m : 0) +
              (chkCost.Checked ? d.Cost * 0.140m : 0) +
              (chkTime.Checked ? d.Time * 0.131m : 0) +
              (chkEnergy.Checked ? d.Energy * 0.143m : 0) +
              (chkMaintenance.Checked ? d.Maintenance * 0.127m : 0) +
              (chkAesthetics.Checked ? d.Aesthetics * 0.135m : 0)
            ).FirstOrDefault()).ToList();

            _designAlternative.RelatedToWind = bestOptionsList.First(o => o.SubCategory.Name == "Related To Wind");
            _designAlternative.RelatedToView = bestOptionsList.First(o => o.SubCategory.Name == "Related To View");

            _designAlternative.BuildingForm = bestOptionsList.First(d => d.SubCategory.Name == "Building Form");
            _designAlternative.FacadeMaterial = bestOptionsList.First(d => d.SubCategory.Name == "Facade Material");
            _designAlternative.GlazingPercentage = bestOptionsList.First(d => d.SubCategory.Name == "Glazing Percentage (G/W Ratio)");

            _designAlternative.PlanEfficiency = bestOptionsList.First(d => d.SubCategory.Name == "Plan Efficiency (W/F Ratio)");
            _designAlternative.ShapeComplexity = bestOptionsList.First(d => d.SubCategory.Name == "Shape Complexity");

            _designAlternative.NumberOfStorey = bestOptionsList.First(d => d.SubCategory.Name == "Number of Storey");
            _designAlternative.AverageStoreyHeight = bestOptionsList.First(d => d.SubCategory.Name == "Average Storey Height");

            _designAlternative.GlazingShape = bestOptionsList.First(d => d.SubCategory.Name == "Glazing Shape");
            _designAlternative.GlazingEfficiency = bestOptionsList.First(d => d.SubCategory.Name == "Glazing Efficiency");
            _designAlternative.SunBreakersGeometry = bestOptionsList.First(d => d.SubCategory.Name == "Sun-Breakers Geometry");

            _designAlternative.SpanDimension = bestOptionsList.First(d => d.SubCategory.Name == "Span Dimension");
            _designAlternative.CirculationArea = bestOptionsList.First(d => d.SubCategory.Name == "Circulation Area (C/F Ratio)");

            designAlternativeBindingSource.ResetBindings(false);
            System.Media.SystemSounds.Beep.Play();
        }

        bool locked = false;
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (locked)
            {
                return;
            }
            locked = true;
            foreach (var chk in groupBox8.Controls.OfType<CheckBox>())
            {
                chk.Checked = chkAll.Checked;
            }
            locked = false;
            showBestOptions();
        }

    }
}
