using Sameer.DesignsAlternatives.BusinessLogic;
using Sameer.DesignsAlternatives.DataAccess;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sameer.DesignsAlternatives
{
    public partial class frmSplash : Form
    {
        private bool _resetData;
        public frmSplash(bool resetData = false)
        {
            InitializeComponent();
            _resetData = resetData;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (_resetData)
            {
                try
                {
                    using (var mgr = new DesignAlternativesOptionsManager(new DesignAlternativesContext()))
                    {
                        await mgr.ResetData();
                        _resetData = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "AD-DSS",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                } 
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
