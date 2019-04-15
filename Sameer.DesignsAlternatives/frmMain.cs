using Sameer.DesignsAlternatives.BusinessLogic;
using Sameer.DesignsAlternatives.DataAccess;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sameer.DesignsAlternatives
{
    public partial class frmMain : Form
    {
        private readonly DesignAlternativesOptionsManager designAlternativesOptionsManager;
        private readonly DesignAlternativesManager designAlternativesManager;

        public frmMain()
        {
            InitializeComponent();
            designAlternativesOptionsManager = new DesignAlternativesOptionsManager(new DesignAlternativesContext());
            designAlternativesManager = new DesignAlternativesManager(new DesignAlternativesContext());
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            var allOptions = await designAlternativesOptionsManager.GetAllDesignOptions();
            if (allOptions == null || allOptions.Count() < 1)
            {
                await designAlternativesOptionsManager.ResetData();
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            new frmSplash().ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }


    }
}
