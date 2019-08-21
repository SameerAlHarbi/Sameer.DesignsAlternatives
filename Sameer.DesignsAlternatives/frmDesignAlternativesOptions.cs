using Sameer.DesignsAlternatives.BusinessLogic;
using Sameer.DesignsAlternatives.DataAccess;
using Sameer.DesignsAlternatives.Models;
using Sameer.DesignsAlternatives.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sameer.DesignsAlternatives
{
    public partial class frmDesignAlternativesOptions : Form
    {
        private readonly DesignAlternativesManager designAlternativesManager;
        private readonly DesignAlternativesOptionsManager designAlternativesOptionsManager;
        private DesignsResult designResult;

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

            await refreshData();
        }

        private async Task refreshData()
        {
            var allDesignAlternatives = await designAlternativesManager.GetAllDesignAlternatives();

            designResult = new DesignsResult(allDesignAlternatives);
            designAlternativeBindingSource.DataSource = allDesignAlternatives;
            designAlternativeBindingSource.ResetBindings(false);

            //nudAlternativesNumber.Value = allDesignAlternatives.Count;
            rdSpaceFunctionality.Checked = false;
            rdSpaceFunctionality.Checked = true;

            foreach (var c in tabPage2.Controls.OfType<Chart>())
            {
                c.DataBind();
            }
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

                MessageBox.Show("Save Successfull", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                await refreshData();
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
                var allDesignAlternatives = await designAlternativesManager.GetAllDesignAlternatives();
                if (allDesignAlternatives.Count >= 10)
                {
                    MessageBox.Show("Max allowed design alternatives is 10 ?", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Are you sure to you want to add new design alternatives ?", Settings.Default.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                //var results = await designAlternativesManager.AddNewDesigns((int)nudAlternativesNumber.Value);

                var results = await designAlternativesManager.AddNewDesigns(1);


                if (results > 0)
                    MessageBox.Show("Don", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No Change", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                await refreshData();
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
            var senderComboBox = senderGroupBox.Controls.OfType<ComboBox>()
                .FirstOrDefault(c => c.Tag.ToString().Trim().ToLower() == subCategoryName.Trim().ToLower());
            BindingSource senderBindingSource = senderComboBox?.DataSource as BindingSource;

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

        private void rdSpaceFunctionality_CheckedChanged(object sender, EventArgs e)
        {
            var rd = sender as RadioButton;
            if (!rd.Checked)
            {
                return;
            }

            var subCriterias = new List<SubCriteria>()
            {
                new SubCriteria
                {
                    Name="Accessibility",
                    BestDesignName = designResult.BestAccessibilityDesignName,
                    BestDesignRelativeIndex = designResult.BestAccessibilityDesignPercentageText,
                    Criteria = "Space"
                },
                new SubCriteria
                {
                    Name="Relation",
                    BestDesignName = designResult.BestRelationDesignName,
                    BestDesignRelativeIndex = designResult.BestRelationDesignPercentageText,
                    Criteria = "Space"
                },
                new SubCriteria
                {
                    Name="Size",
                    BestDesignName = designResult.BestSizeDesignName,
                    BestDesignRelativeIndex = designResult.BestSizeDesignPercentageText,
                    Criteria = "Space"
                },
                new SubCriteria
                {
                    Name="Cost",
                    BestDesignName = designResult.BestCosteDesignName,
                    BestDesignRelativeIndex = designResult.BestCosteDesignPercentageText,
                    Criteria = "Construction"
                },
                new SubCriteria
                {
                    Name="Time",
                    BestDesignName = designResult.BestTimeDesignName,
                    BestDesignRelativeIndex = designResult.BestTimeDesignPercentageText,
                    Criteria = "Construction"
                },
                new SubCriteria
                {
                    Name="Energy",
                    BestDesignName = designResult.BestEnergyDesignName,
                    BestDesignRelativeIndex = designResult.BestEnergyDesignPercentageText,
                    Criteria = "Operation"
                },
                new SubCriteria
                {
                    Name="Maintenance",
                    BestDesignName = designResult.BestMaintenanceDesignName,
                    BestDesignRelativeIndex = designResult.BestMaintenanceDesignPercentageText,
                    Criteria = "Operation"
                },
            };

            string selectedCriteria = "";

            if (rd == rdSpaceFunctionality)
            {
                lblBestCriteria.Text = designResult.BestSpaceFunctionalityDesignName;
                lblBestCriteriaPercentage.Text = designResult.BestSpaceFunctionalityDesignPercentageText;

                selectedCriteria = "Space";

                chartResults.Series.First().YValueMembers = "SpaceFunctionalityPercentage";
                //chartSub1.Series.First().CustomProperties = "PieLabelStyle = Inside,Exploded = True";
            }
            else if (rd == rdConstructionPerformance)
            {
                lblBestCriteria.Text = designResult.BestConstructionPerformanceDesignName;
                lblBestCriteriaPercentage.Text = designResult.BestConstructionPerformanceDesignPercentageText;

                selectedCriteria = "Construction";

                chartResults.Series.First().YValueMembers = "ConstructionPerformancePercentage";
            }
            else if (rd == rdOperationPerformance)
            {
                lblBestCriteria.Text = designResult.BestOperationPerformanceDesignName;
                lblBestCriteriaPercentage.Text = designResult.BestOperationPerformanceDesignPercentageText;

                selectedCriteria = "Operation";

                chartResults.Series.First().YValueMembers = "OperationPerformancePercentage";
            }
            else if (rd == rdAethiticas)
            {
                lblBestCriteria.Text = designResult.BestAestheticsDesignName;
                lblBestCriteriaPercentage.Text = designResult.BestAestheticsDesignPercentageText;

                chartResults.Series.First().YValueMembers = "AestheticsPercentage";
            }

            subCriteriaBindingSource.DataSource = subCriterias.Where(s => s.Criteria == selectedCriteria).ToList();
            subCriteriaBindingSource.ResetBindings(false);

            chartResults.Titles.First().Text = rd.Text;
            
        }

        private void subCriteriaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            chart4.Visible = true;
            if (subCriteriaBindingSource.Current == null)
            {
                
                chart4.Visible = false;
                return;
            }

            var currentSubCriteria = subCriteriaBindingSource.Current as SubCriteria;
            chart4.Titles.First().Text = currentSubCriteria.Name;
            chart4.Series.First().YValueMembers = $"{currentSubCriteria.Name}Percentage";
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {  
            CheckBox chk = sender as CheckBox;

            var groupedOptions = allDesignOptions.GroupBy(o => o.SubCategoryId);
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

            foreach (var groupBox in tabPage1.Controls.OfType<GroupBox>())
            {
                foreach (var comboBox in groupBox.Controls.OfType<ComboBox>())
                {
                    var bindingSource = comboBox.DataSource as BindingSource;
                    var dataSourceList = bindingSource.DataSource as List<DesignOption>;
                    var bestOption = dataSourceList.Intersect(bestOptionsList).FirstOrDefault();
                    bindingSource.Position = dataSourceList.IndexOf(bestOption);
                    bindingSource.ResetBindings(false);
                }
            }
        }

        private void btnHints_Click(object sender, EventArgs e)
        {
            new frnSubCriteriaHints(allDesignOptions).ShowDialog();
        }

        private async void btnDeleteDesign_Click(object sender, EventArgs e)
        {
            if(this.designAlternativeBindingSource.Current == null)
            {
                return;
            }

            if (MessageBox.Show("Are you sure to you want to remove this design alternative?", Settings.Default.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var results = await designAlternativesManager.Delete(this.designAlternativeBindingSource.Current as DesignAlternative);

            if (results > 0)
                MessageBox.Show("Don", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No Change", Settings.Default.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            await refreshData();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
