using Sameer.DesignsAlternatives.BusinessLogic;
using Sameer.DesignsAlternatives.DataAccess;
using Sameer.DesignsAlternatives.Models;
using Sameer.DesignsAlternatives.Properties;
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

        private List<DesignOption> allDesignOptions;

        public frmDesignAlternativesOptions()
        {
            InitializeComponent();
            designAlternativesManager = new DesignAlternativesManager(new DesignAlternativesContext());
            designAlternativesOptionsManager = new DesignAlternativesOptionsManager(new DesignAlternativesContext());
        }

        private async void frmDesignAlternativesOptions_Load(object sender, EventArgs e)
        {
            allDesignOptions = await designAlternativesOptionsManager.GetAllDesignOptions();

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

            var allDesignAlternatives = await designAlternativesManager.GetAllDesignAlternatives();

            designAlternativeBindingSource.DataSource = allDesignAlternatives;
            designAlternativeBindingSource.ResetBindings(false);

            nudAlternativesNumber.Value = allDesignAlternatives.Count;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (designAlternativeBindingSource.Current == null)
            {
                return;
            }

            try
            {
                await designAlternativesManager.Save();

                designAlternativeBindingSource.DataSource = await designAlternativesManager.GetAllDesignAlternatives();
                designAlternativeBindingSource.ResetBindings(false);

                MessageBox.Show("Save Successfull", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to reset design alternatives data ?", Settings.Default.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                var results = await designAlternativesManager.AddNewDesigns((int)nudAlternativesNumber.Value);

                if(results > 0)
                    MessageBox.Show("Don", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No Change", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                var allDesignAlternatives = await designAlternativesManager.GetAllDesignAlternatives();

                designAlternativeBindingSource.DataSource = allDesignAlternatives;
                designAlternativeBindingSource.ResetBindings(false);
                nudAlternativesNumber.Value = allDesignAlternatives.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectOption_Click(object sender, EventArgs e)
        {
            var senderButton = sender as Button;
            var subCategoryName = senderButton.Tag.ToString();
            var senderGroupBox = senderButton.Parent as GroupBox;
            BindingSource senderBindingSource = senderGroupBox.Controls.OfType<ComboBox>()
                .FirstOrDefault(c => c.Tag.ToString().Trim().ToLower() == subCategoryName.Trim().ToLower())?.DataSource as BindingSource;

            if (senderBindingSource != null)
            {
                frmSelectOption optionsForm = new frmSelectOption(allDesignOptions.Select(c => c.SubCategory)
                        .FirstOrDefault(c => c.Name.Trim().ToLower() == subCategoryName.Trim().ToLower()),senderBindingSource.Current as DesignOption);

                if (optionsForm.ShowDialog() == DialogResult.OK)
                {
                    senderBindingSource.Position = (senderBindingSource.DataSource as List<DesignOption>).IndexOf(optionsForm.SelectedOption);
                    senderBindingSource.ResetBindings(false);
                }
            }
        }
    }
}
