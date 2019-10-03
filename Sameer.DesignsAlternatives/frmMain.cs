using Sameer.DesignsAlternatives.BusinessLogic;
using Sameer.DesignsAlternatives.DataAccess;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Sameer.DesignsAlternatives
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                new frmSplash().ShowDialog();
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            new frmSettings().ShowDialog();
            Cursor = Cursors.Default;
        }

        private void btnDesignsAlternatives_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            new frmDesignAlternativesOptions().ShowDialog();
            Cursor = Cursors.Default;
        }

        private async void btnBestSubCriteria_Click(object sender, EventArgs e)
        {
            new frnSubCriteriaHints(await new DesignAlternativesOptionsManager(new DesignAlternativesContext()).GetAllDesignOptions()).ShowDialog();
        }

        private void btnUserManual_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"{Directory.GetCurrentDirectory()}\\AD-DSS.pdf");

        }
    }
}
