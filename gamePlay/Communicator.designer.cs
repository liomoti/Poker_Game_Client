namespace Project
{
    partial class frmCommunicator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommunicator));
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblConnectionScreen = new System.Windows.Forms.Label();
            this.lbl_opp_ip = new System.Windows.Forms.Label();
            this.tbOppIp = new System.Windows.Forms.TextBox();
            this.lblStatusConnection = new System.Windows.Forms.Label();
            this.lblStatusConnectionText = new System.Windows.Forms.Label();
            this.timerWaitForRdy = new System.Windows.Forms.Timer(this.components);
            this.lbl_myip = new System.Windows.Forms.Label();
            this.lblMyIp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.Teal;
            this.btnStartGame.Enabled = false;
            this.btnStartGame.Font = new System.Drawing.Font("Showcard Gothic", 32F, System.Drawing.FontStyle.Bold);
            this.btnStartGame.ForeColor = System.Drawing.Color.White;
            this.btnStartGame.Location = new System.Drawing.Point(305, 330);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(174, 120);
            this.btnStartGame.TabIndex = 0;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.DarkGreen;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(353, 114);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(99, 40);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblConnectionScreen
            // 
            this.lblConnectionScreen.AutoSize = true;
            this.lblConnectionScreen.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectionScreen.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionScreen.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblConnectionScreen.Location = new System.Drawing.Point(177, 9);
            this.lblConnectionScreen.Name = "lblConnectionScreen";
            this.lblConnectionScreen.Size = new System.Drawing.Size(319, 36);
            this.lblConnectionScreen.TabIndex = 2;
            this.lblConnectionScreen.Text = "Connect to Server";
            // 
            // lbl_opp_ip
            // 
            this.lbl_opp_ip.AutoSize = true;
            this.lbl_opp_ip.BackColor = System.Drawing.Color.Transparent;
            this.lbl_opp_ip.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_opp_ip.Location = new System.Drawing.Point(249, 79);
            this.lbl_opp_ip.Name = "lbl_opp_ip";
            this.lbl_opp_ip.Size = new System.Drawing.Size(117, 20);
            this.lbl_opp_ip.TabIndex = 3;
            this.lbl_opp_ip.Text = "Server IP Adress:";
            // 
            // tbOppIp
            // 
            this.tbOppIp.Location = new System.Drawing.Point(364, 79);
            this.tbOppIp.MaxLength = 15;
            this.tbOppIp.Name = "tbOppIp";
            this.tbOppIp.Size = new System.Drawing.Size(115, 20);
            this.tbOppIp.TabIndex = 7;
            // 
            // lblStatusConnection
            // 
            this.lblStatusConnection.AutoSize = true;
            this.lblStatusConnection.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusConnection.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusConnection.ForeColor = System.Drawing.Color.Black;
            this.lblStatusConnection.Location = new System.Drawing.Point(338, 167);
            this.lblStatusConnection.Name = "lblStatusConnection";
            this.lblStatusConnection.Size = new System.Drawing.Size(127, 20);
            this.lblStatusConnection.TabIndex = 5;
            this.lblStatusConnection.Text = "Connection Status:";
            // 
            // lblStatusConnectionText
            // 
            this.lblStatusConnectionText.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusConnectionText.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStatusConnectionText.ForeColor = System.Drawing.Color.Red;
            this.lblStatusConnectionText.Location = new System.Drawing.Point(338, 197);
            this.lblStatusConnectionText.Name = "lblStatusConnectionText";
            this.lblStatusConnectionText.Size = new System.Drawing.Size(121, 130);
            this.lblStatusConnectionText.TabIndex = 6;
            this.lblStatusConnectionText.Text = "Offline";
            // 
            // timerWaitForRdy
            // 
            this.timerWaitForRdy.Interval = 2000;
            this.timerWaitForRdy.Tick += new System.EventHandler(this.timerWaitForRdy_Tick);
            // 
            // lbl_myip
            // 
            this.lbl_myip.AutoSize = true;
            this.lbl_myip.BackColor = System.Drawing.Color.Transparent;
            this.lbl_myip.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_myip.Location = new System.Drawing.Point(249, 55);
            this.lbl_myip.Name = "lbl_myip";
            this.lbl_myip.Size = new System.Drawing.Size(95, 20);
            this.lbl_myip.TabIndex = 0;
            this.lbl_myip.Text = "My IP Adress:";
            // 
            // lblMyIp
            // 
            this.lblMyIp.AutoSize = true;
            this.lblMyIp.BackColor = System.Drawing.Color.Transparent;
            this.lblMyIp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMyIp.Location = new System.Drawing.Point(371, 55);
            this.lblMyIp.Name = "lblMyIp";
            this.lblMyIp.Size = new System.Drawing.Size(0, 19);
            this.lblMyIp.TabIndex = 12;
            // 
            // frmCommunicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(491, 462);
            this.Controls.Add(this.lblMyIp);
            this.Controls.Add(this.lbl_opp_ip);
            this.Controls.Add(this.tbOppIp);
            this.Controls.Add(this.lbl_myip);
            this.Controls.Add(this.lblStatusConnectionText);
            this.Controls.Add(this.lblStatusConnection);
            this.Controls.Add(this.lblConnectionScreen);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnStartGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(507, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(507, 500);
            this.Name = "frmCommunicator";
            this.Text = "Poker Online Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Communicator_FormClosed);
            this.Load += new System.EventHandler(this.frmCommunicator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblConnectionScreen;
        private System.Windows.Forms.Label lbl_opp_ip;
        private System.Windows.Forms.Label lblStatusConnection;
        private System.Windows.Forms.Label lblStatusConnectionText;
        private System.Windows.Forms.TextBox tbOppIp;
        private System.Windows.Forms.Timer timerWaitForRdy;
        private System.Windows.Forms.Label lbl_myip;
        private System.Windows.Forms.Label lblMyIp;
    }
}

