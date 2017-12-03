using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project
{
    public partial class frmStart : Form
    {
        public Player userName;
        public frmAchivment achiv;


        public frmStart()
        {    
            InitializeComponent();
                
        }

        private void Start_Load(object sender, EventArgs e)
        {
            userName = new Player("Default Player", 0);
        }

        private void btnSettingClick(object sender, EventArgs e)
        {         
                frmSettings pressedSetting = new frmSettings(userName);
                pressedSetting.Owner = this;
                pressedSetting.Show();
                btnSettings.Enabled = false;   
        }

        private void btnAchivmentsClick(object sender, EventArgs e)
        {
                achiv = new frmAchivment();
                achiv.Owner = this;
                achiv.Show();
                btnAchivments.Enabled = false;
        }

        private void btnConnectClick(object sender, EventArgs e)
        {
            achiv = new frmAchivment();
            frmCommunicator playCommu = new frmCommunicator(userName,achiv);
            playCommu.Owner = this;
            playCommu.Show();
            btnConnect.Enabled = false;
        }

        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
                this.Close();
        }
    }
}
