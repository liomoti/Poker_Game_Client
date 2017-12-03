using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project

{
    public partial class frmSettings : Form
    {
        Player player;

        public frmSettings(Player player)
        {
            InitializeComponent();
            this.player = player;
        }

        private void changeNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            tbNameTxtBox.SelectionAlignment = HorizontalAlignment.Center;
   
        }

        private void frmSettings_FormClosed(object sender, FormClosedEventArgs e)
        {       
            (this.Owner as frmStart).btnSettings.Enabled = true;
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {          
            player.name = tbNameTxtBox.Text.ToString();
            lbl_name_saved.Text = "Saved";      
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            
            tbNameTxtBox.Text = player.name.ToString();
        }

        private void changeNameTxtBox_Enter(object sender, EventArgs e)
        {
        }

        private void changeNameTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void changeNameTxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Prevent RichTextBox from creating new line when enter is pressed
                e.Handled = true;
                btnChangeName.PerformClick();
            }
            
        }

        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
