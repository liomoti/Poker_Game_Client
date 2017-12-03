namespace Project
{
    partial class frmAchivment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAchivment));
            this.lblVictoryHistory = new System.Windows.Forms.Label();
            this.lbl_GreatestHand = new System.Windows.Forms.Label();
            this.tb_strongHand = new System.Windows.Forms.Label();
            this.btnResetS = new System.Windows.Forms.Button();
            this.lbl_winLose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVictoryHistory
            // 
            this.lblVictoryHistory.AutoSize = true;
            this.lblVictoryHistory.BackColor = System.Drawing.Color.Transparent;
            this.lblVictoryHistory.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVictoryHistory.ForeColor = System.Drawing.Color.White;
            this.lblVictoryHistory.Location = new System.Drawing.Point(317, 50);
            this.lblVictoryHistory.Name = "lblVictoryHistory";
            this.lblVictoryHistory.Size = new System.Drawing.Size(270, 33);
            this.lblVictoryHistory.TabIndex = 3;
            this.lblVictoryHistory.Text = "Victory History";
            // 
            // lbl_GreatestHand
            // 
            this.lbl_GreatestHand.AutoSize = true;
            this.lbl_GreatestHand.BackColor = System.Drawing.Color.Transparent;
            this.lbl_GreatestHand.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_GreatestHand.ForeColor = System.Drawing.Color.White;
            this.lbl_GreatestHand.Location = new System.Drawing.Point(3, 50);
            this.lbl_GreatestHand.Name = "lbl_GreatestHand";
            this.lbl_GreatestHand.Size = new System.Drawing.Size(258, 33);
            this.lbl_GreatestHand.TabIndex = 4;
            this.lbl_GreatestHand.Text = "Strongest Hand";
            // 
            // tb_strongHand
            // 
            this.tb_strongHand.BackColor = System.Drawing.Color.Transparent;
            this.tb_strongHand.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.tb_strongHand.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tb_strongHand.Location = new System.Drawing.Point(5, 99);
            this.tb_strongHand.Name = "tb_strongHand";
            this.tb_strongHand.Size = new System.Drawing.Size(246, 287);
            this.tb_strongHand.TabIndex = 7;
            this.tb_strongHand.Text = "strongest hand label";
            // 
            // btnResetS
            // 
            this.btnResetS.BackColor = System.Drawing.Color.Azure;
            this.btnResetS.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnResetS.Location = new System.Drawing.Point(220, 356);
            this.btnResetS.Name = "btnResetS";
            this.btnResetS.Size = new System.Drawing.Size(123, 42);
            this.btnResetS.TabIndex = 8;
            this.btnResetS.Text = "Reset Statics";
            this.btnResetS.UseVisualStyleBackColor = false;
            this.btnResetS.Click += new System.EventHandler(this.btnResetS_Click);
            // 
            // lbl_winLose
            // 
            this.lbl_winLose.BackColor = System.Drawing.Color.Transparent;
            this.lbl_winLose.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_winLose.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_winLose.Location = new System.Drawing.Point(319, 99);
            this.lbl_winLose.Name = "lbl_winLose";
            this.lbl_winLose.Size = new System.Drawing.Size(246, 254);
            this.lbl_winLose.TabIndex = 9;
            this.lbl_winLose.Text = "win/lose history label";
            // 
            // frmAchivment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(599, 412);
            this.Controls.Add(this.lbl_winLose);
            this.Controls.Add(this.btnResetS);
            this.Controls.Add(this.tb_strongHand);
            this.Controls.Add(this.lbl_GreatestHand);
            this.Controls.Add(this.lblVictoryHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(615, 450);
            this.MinimumSize = new System.Drawing.Size(615, 450);
            this.Name = "frmAchivment";
            this.Text = "Poker Online Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAchivment_FormClosing);
            this.Load += new System.EventHandler(this.frmAchivment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAchivment_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVictoryHistory;
        private System.Windows.Forms.Label lbl_GreatestHand;
        private System.Windows.Forms.Label tb_strongHand;
        private System.Windows.Forms.Button btnResetS;
        private System.Windows.Forms.Label lbl_winLose;
    }
}