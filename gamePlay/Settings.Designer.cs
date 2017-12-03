namespace Project
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnChangeName = new System.Windows.Forms.Button();
            this.tbNameTxtBox = new System.Windows.Forms.RichTextBox();
            this.lbl_name_saved = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChangeName
            // 
            this.btnChangeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeName.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnChangeName.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeName.Location = new System.Drawing.Point(184, 322);
            this.btnChangeName.MaximumSize = new System.Drawing.Size(265, 81);
            this.btnChangeName.MinimumSize = new System.Drawing.Size(265, 81);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(265, 81);
            this.btnChangeName.TabIndex = 1;
            this.btnChangeName.Text = "Change Name";
            this.btnChangeName.UseVisualStyleBackColor = false;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // tbNameTxtBox
            // 
            this.tbNameTxtBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbNameTxtBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tbNameTxtBox.Font = new System.Drawing.Font("Tempus Sans ITC", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNameTxtBox.ForeColor = System.Drawing.Color.White;
            this.tbNameTxtBox.Location = new System.Drawing.Point(184, 253);
            this.tbNameTxtBox.MaxLength = 15;
            this.tbNameTxtBox.Name = "tbNameTxtBox";
            this.tbNameTxtBox.ShortcutsEnabled = false;
            this.tbNameTxtBox.Size = new System.Drawing.Size(265, 53);
            this.tbNameTxtBox.TabIndex = 2;
            this.tbNameTxtBox.Text = "";
            this.tbNameTxtBox.TextChanged += new System.EventHandler(this.changeNameTxtBox_TextChanged);
            this.tbNameTxtBox.Enter += new System.EventHandler(this.changeNameTxtBox_Enter);
            this.tbNameTxtBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.changeNameTxtBox_KeyDown);
            this.tbNameTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.changeNameTxtBox_KeyPress);
            // 
            // lbl_name_saved
            // 
            this.lbl_name_saved.AutoSize = true;
            this.lbl_name_saved.Location = new System.Drawing.Point(302, 214);
            this.lbl_name_saved.Name = "lbl_name_saved";
            this.lbl_name_saved.Size = new System.Drawing.Size(0, 13);
            this.lbl_name_saved.TabIndex = 3;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(626, 416);
            this.Controls.Add(this.lbl_name_saved);
            this.Controls.Add(this.tbNameTxtBox);
            this.Controls.Add(this.btnChangeName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(642, 454);
            this.MinimumSize = new System.Drawing.Size(642, 454);
            this.Name = "frmSettings";
            this.Text = "Poker Online Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSettings_FormClosed);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSettings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.RichTextBox tbNameTxtBox;
        private System.Windows.Forms.Label lbl_name_saved;
    }
}