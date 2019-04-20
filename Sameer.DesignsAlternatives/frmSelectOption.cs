using Sameer.DesignsAlternatives.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sameer.DesignsAlternatives
{
    public partial class frmSelectOption : Form
    {
        private readonly SubCategory _subcategory;
        public DesignOption SelectedOption { get; set; }
        public frmSelectOption(SubCategory subcategory,DesignOption currentOption = null)
        {
            InitializeComponent();
            _subcategory = subcategory;
            SelectedOption = currentOption;
        }

        private void frmSelectOption_Load(object sender, EventArgs e)
        {
            Text = $"{_subcategory.Category.Name} - {_subcategory.Name} Options";
            var optionsList = _subcategory.designOptions.OrderBy(c => c.Code).ToList();
            designOptionBindingSource.DataSource = optionsList;

            if(SelectedOption != null)
            {
                designOptionBindingSource.Position = optionsList.IndexOf(SelectedOption);
            }
        }

        private void designOptionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if(designOptionBindingSource.Current == null)
            {
                pictureBox1.Image = null;
                return;
            }

            string path = System.IO.Path.GetDirectoryName(
                    new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            path = System.IO.Path.Combine(path, "Images");

            pictureBox1.Image = Image.FromFile(path + $@"\{(designOptionBindingSource.Current as DesignOption).Code}.tif");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (designOptionBindingSource.Current == null)
            {
                return;
            }
            SelectedOption = designOptionBindingSource.Current as DesignOption;
            this.DialogResult = DialogResult.OK;
        }
    }
}
