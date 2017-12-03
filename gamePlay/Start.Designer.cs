namespace Project
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAchivments = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.Location = new System.Drawing.Point(3, 448);
            this.btnConnect.MaximumSize = new System.Drawing.Size(200, 200);
            this.btnConnect.MinimumSize = new System.Drawing.Size(200, 200);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 200);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnectClick);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.Location = new System.Drawing.Point(209, 448);
            this.btnSettings.MaximumSize = new System.Drawing.Size(200, 200);
            this.btnSettings.MinimumSize = new System.Drawing.Size(200, 200);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(200, 200);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettingClick);
            // 
            // btnAchivments
            // 
            this.btnAchivments.BackColor = System.Drawing.Color.Brown;
            this.btnAchivments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAchivments.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.btnAchivments.Image = ((System.Drawing.Image)(resources.GetObject("btnAchivments.Image")));
            this.btnAchivments.Location = new System.Drawing.Point(404, 448);
            this.btnAchivments.MaximumSize = new System.Drawing.Size(200, 200);
            this.btnAchivments.MinimumSize = new System.Drawing.Size(200, 200);
            this.btnAchivments.Name = "btnAchivments";
            this.btnAchivments.Size = new System.Drawing.Size(200, 200);
            this.btnAchivments.TabIndex = 2;
            this.btnAchivments.UseVisualStyleBackColor = false;
            this.btnAchivments.Click += new System.EventHandler(this.btnAchivmentsClick);
            // 
            // frmStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(605, 644);
            this.Controls.Add(this.btnAchivments);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(621, 682);
            this.MinimumSize = new System.Drawing.Size(621, 682);
            this.Name = "frmStart";
            this.Text = "Poker Online Game";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.Button btnSettings;
        public System.Windows.Forms.Button btnAchivments;
    }
}