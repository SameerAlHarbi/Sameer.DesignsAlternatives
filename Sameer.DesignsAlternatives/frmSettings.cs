using Sameer.DesignsAlternatives.BusinessLogic;
using Sameer.DesignsAlternatives.DataAccess;
using System;
using System.Windows.Forms;

namespace Sameer.DesignsAlternatives
{
    public partial class frmSettings : Form
    {
        private readonly DesignAlternativesOptionsManager dbMgr;
        public frmSettings()
        {
            InitializeComponent();
            dbMgr = new DesignAlternativesOptionsManager(new DesignAlternativesContext());
        }

        private async void frmSettings_Load(object sender, EventArgs e)
        {
            categoryBindingSource.DataSource = await dbMgr.GetAllCategories();
        }

        private async void btnResetDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete all data and start again ?",
               "Design Alternatives Factory Reset", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                new frmSplash(true).ShowDialog();
            categoryBindingSource.DataSource = await dbMgr.GetAllCategories();
            categoryBindingSource.ResetBindings(false);
            MessageBox.Show("Reset Default Successfull", "Design Alternatives", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                await dbMgr.Save();
                MessageBox.Show("Save Successfull", "Design Alternatives", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Design Alternatives", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                return;
            }
            Cursor = Cursors.Default;
        }


    }
}
