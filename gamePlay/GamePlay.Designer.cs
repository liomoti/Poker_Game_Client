namespace Project
{
    partial class frmGamePlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGamePlay));
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnRaise = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnFold = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.tbOpponent = new System.Windows.Forms.TextBox();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            this.pbTableCard2 = new System.Windows.Forms.PictureBox();
            this.pbTableCard3 = new System.Windows.Forms.PictureBox();
            this.pbTableCard5 = new System.Windows.Forms.PictureBox();
            this.pbTableCard4 = new System.Windows.Forms.PictureBox();
            this.tbPot = new System.Windows.Forms.TextBox();
            this.pbTableCard1 = new System.Windows.Forms.PictureBox();
            this.pbPlayerCard1 = new System.Windows.Forms.PictureBox();
            this.pbPlayerCard2 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbPotTotalScore = new System.Windows.Forms.TextBox();
            this.tbScore = new System.Windows.Forms.TextBox();
            this.tbPoints = new System.Windows.Forms.TextBox();
            this.tbRaise = new System.Windows.Forms.TrackBar();
            this.tbBetUpdate = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblOppName = new System.Windows.Forms.Label();
            this.lbl_state = new System.Windows.Forms.Label();
            this.timerStartGame1 = new System.Windows.Forms.Timer(this.components);
            this.timerFlop2 = new System.Windows.Forms.Timer(this.components);
            this.tbOppPot = new System.Windows.Forms.TextBox();
            this.timerTurn3 = new System.Windows.Forms.Timer(this.components);
            this.timerRiver4 = new System.Windows.Forms.Timer(this.components);
            this.timerEndGame5 = new System.Windows.Forms.Timer(this.components);
            this.lbl_hand = new System.Windows.Forms.Label();
            this.pbOppCard1 = new System.Windows.Forms.PictureBox();
            this.pbOppCard2 = new System.Windows.Forms.PictureBox();
            this.closeTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRaise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOppCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOppCard2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheck.BackgroundImage")));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheck.Location = new System.Drawing.Point(35, 393);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 40);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Visible = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnRaise
            // 
            this.btnRaise.BackColor = System.Drawing.Color.Transparent;
            this.btnRaise.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRaise.BackgroundImage")));
            this.btnRaise.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRaise.Location = new System.Drawing.Point(159, 393);
            this.btnRaise.Name = "btnRaise";
            this.btnRaise.Size = new System.Drawing.Size(100, 40);
            this.btnRaise.TabIndex = 0;
            this.btnRaise.UseVisualStyleBackColor = false;
            this.btnRaise.Visible = false;
            this.btnRaise.Click += new System.EventHandler(this.btnRaise_Click);
            // 
            // btnCall
            // 
            this.btnCall.BackColor = System.Drawing.Color.Transparent;
            this.btnCall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCall.BackgroundImage")));
            this.btnCall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCall.Location = new System.Drawing.Point(476, 393);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(100, 40);
            this.btnCall.TabIndex = 0;
            this.btnCall.UseVisualStyleBackColor = false;
            this.btnCall.Visible = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnFold
            // 
            this.btnFold.BackColor = System.Drawing.Color.Transparent;
            this.btnFold.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFold.BackgroundImage")));
            this.btnFold.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFold.Location = new System.Drawing.Point(601, 393);
            this.btnFold.Name = "btnFold";
            this.btnFold.Size = new System.Drawing.Size(100, 40);
            this.btnFold.TabIndex = 0;
            this.btnFold.UseVisualStyleBackColor = false;
            this.btnFold.Visible = false;
            this.btnFold.Click += new System.EventHandler(this.btnFold_Click);
            // 
            // tbOpponent
            // 
            this.tbOpponent.Location = new System.Drawing.Point(107, 9);
            this.tbOpponent.Name = "tbOpponent";
            this.tbOpponent.ReadOnly = true;
            this.tbOpponent.Size = new System.Drawing.Size(100, 20);
            this.tbOpponent.TabIndex = 1;
            this.tbOpponent.Text = "Opponent";
            // 
            // tbPlayer
            // 
            this.tbPlayer.Location = new System.Drawing.Point(326, 413);
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.ReadOnly = true;
            this.tbPlayer.Size = new System.Drawing.Size(100, 20);
            this.tbPlayer.TabIndex = 1;
            this.tbPlayer.Text = "Player";
            // 
            // pbTableCard2
            // 
            this.pbTableCard2.Image = global::gamePlay.Properties.Resources._Back;
            this.pbTableCard2.Location = new System.Drawing.Point(249, 135);
            this.pbTableCard2.Name = "pbTableCard2";
            this.pbTableCard2.Size = new System.Drawing.Size(77, 94);
            this.pbTableCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTableCard2.TabIndex = 2;
            this.pbTableCard2.TabStop = false;
            // 
            // pbTableCard3
            // 
            this.pbTableCard3.Image = global::gamePlay.Properties.Resources._Back;
            this.pbTableCard3.Location = new System.Drawing.Point(339, 135);
            this.pbTableCard3.Name = "pbTableCard3";
            this.pbTableCard3.Size = new System.Drawing.Size(77, 94);
            this.pbTableCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTableCard3.TabIndex = 2;
            this.pbTableCard3.TabStop = false;
            // 
            // pbTableCard5
            // 
            this.pbTableCard5.Image = ((System.Drawing.Image)(resources.GetObject("pbTableCard5.Image")));
            this.pbTableCard5.Location = new System.Drawing.Point(519, 135);
            this.pbTableCard5.Name = "pbTableCard5";
            this.pbTableCard5.Size = new System.Drawing.Size(77, 94);
            this.pbTableCard5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTableCard5.TabIndex = 2;
            this.pbTableCard5.TabStop = false;
            // 
            // pbTableCard4
            // 
            this.pbTableCard4.Image = global::gamePlay.Properties.Resources._Back;
            this.pbTableCard4.Location = new System.Drawing.Point(429, 135);
            this.pbTableCard4.Name = "pbTableCard4";
            this.pbTableCard4.Size = new System.Drawing.Size(77, 94);
            this.pbTableCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTableCard4.TabIndex = 2;
            this.pbTableCard4.TabStop = false;
            // 
            // tbPot
            // 
            this.tbPot.Location = new System.Drawing.Point(343, 86);
            this.tbPot.Name = "tbPot";
            this.tbPot.ReadOnly = true;
            this.tbPot.Size = new System.Drawing.Size(24, 20);
            this.tbPot.TabIndex = 1;
            this.tbPot.Text = "Pot";
            // 
            // pbTableCard1
            // 
            this.pbTableCard1.Image = global::gamePlay.Properties.Resources._Back;
            this.pbTableCard1.Location = new System.Drawing.Point(159, 135);
            this.pbTableCard1.Name = "pbTableCard1";
            this.pbTableCard1.Size = new System.Drawing.Size(77, 94);
            this.pbTableCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTableCard1.TabIndex = 2;
            this.pbTableCard1.TabStop = false;
            // 
            // pbPlayerCard1
            // 
            this.pbPlayerCard1.Image = global::gamePlay.Properties.Resources._Back;
            this.pbPlayerCard1.Location = new System.Drawing.Point(301, 309);
            this.pbPlayerCard1.Name = "pbPlayerCard1";
            this.pbPlayerCard1.Size = new System.Drawing.Size(68, 83);
            this.pbPlayerCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayerCard1.TabIndex = 2;
            this.pbPlayerCard1.TabStop = false;
            // 
            // pbPlayerCard2
            // 
            this.pbPlayerCard2.Image = global::gamePlay.Properties.Resources._Back;
            this.pbPlayerCard2.Location = new System.Drawing.Point(386, 309);
            this.pbPlayerCard2.Name = "pbPlayerCard2";
            this.pbPlayerCard2.Size = new System.Drawing.Size(68, 83);
            this.pbPlayerCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayerCard2.TabIndex = 2;
            this.pbPlayerCard2.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Location = new System.Drawing.Point(601, 345);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 40);
            this.btnStart.TabIndex = 3;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbPotTotalScore
            // 
            this.tbPotTotalScore.Location = new System.Drawing.Point(373, 86);
            this.tbPotTotalScore.Name = "tbPotTotalScore";
            this.tbPotTotalScore.ReadOnly = true;
            this.tbPotTotalScore.Size = new System.Drawing.Size(36, 20);
            this.tbPotTotalScore.TabIndex = 1;
            this.tbPotTotalScore.Text = "0";
            // 
            // tbScore
            // 
            this.tbScore.Location = new System.Drawing.Point(476, 309);
            this.tbScore.Name = "tbScore";
            this.tbScore.ReadOnly = true;
            this.tbScore.Size = new System.Drawing.Size(30, 20);
            this.tbScore.TabIndex = 1;
            this.tbScore.Text = "1000";
            // 
            // tbPoints
            // 
            this.tbPoints.Location = new System.Drawing.Point(512, 309);
            this.tbPoints.Name = "tbPoints";
            this.tbPoints.ReadOnly = true;
            this.tbPoints.Size = new System.Drawing.Size(37, 20);
            this.tbPoints.TabIndex = 1;
            this.tbPoints.Text = "Points";
            // 
            // tbRaise
            // 
            this.tbRaise.BackColor = System.Drawing.Color.Black;
            this.tbRaise.Location = new System.Drawing.Point(103, 321);
            this.tbRaise.Maximum = 1000;
            this.tbRaise.Minimum = 1;
            this.tbRaise.Name = "tbRaise";
            this.tbRaise.Size = new System.Drawing.Size(104, 45);
            this.tbRaise.TabIndex = 4;
            this.tbRaise.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbRaise.Value = 1;
            this.tbRaise.Visible = false;
            this.tbRaise.Scroll += new System.EventHandler(this.tbRaise_Scroll);
            // 
            // tbBetUpdate
            // 
            this.tbBetUpdate.Location = new System.Drawing.Point(213, 321);
            this.tbBetUpdate.Name = "tbBetUpdate";
            this.tbBetUpdate.ReadOnly = true;
            this.tbBetUpdate.Size = new System.Drawing.Size(36, 20);
            this.tbBetUpdate.TabIndex = 1;
            this.tbBetUpdate.Text = "0";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.Location = new System.Drawing.Point(52, 309);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(45, 40);
            this.btnOk.TabIndex = 0;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblOppName
            // 
            this.lblOppName.AutoSize = true;
            this.lblOppName.BackColor = System.Drawing.Color.Transparent;
            this.lblOppName.ForeColor = System.Drawing.Color.Snow;
            this.lblOppName.Location = new System.Drawing.Point(10, 12);
            this.lblOppName.Name = "lblOppName";
            this.lblOppName.Size = new System.Drawing.Size(94, 13);
            this.lblOppName.TabIndex = 6;
            this.lblOppName.Text = "Opponnent Name:";
            // 
            // lbl_state
            // 
            this.lbl_state.BackColor = System.Drawing.Color.Transparent;
            this.lbl_state.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_state.ForeColor = System.Drawing.Color.Snow;
            this.lbl_state.Location = new System.Drawing.Point(136, 252);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(476, 37);
            this.lbl_state.TabIndex = 7;
            this.lbl_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerStartGame1
            // 
            this.timerStartGame1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerFlop2
            // 
            this.timerFlop2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tbOppPot
            // 
            this.tbOppPot.Location = new System.Drawing.Point(213, 9);
            this.tbOppPot.Name = "tbOppPot";
            this.tbOppPot.ReadOnly = true;
            this.tbOppPot.Size = new System.Drawing.Size(39, 20);
            this.tbOppPot.TabIndex = 8;
            this.tbOppPot.Text = "1000";
            // 
            // timerTurn3
            // 
            this.timerTurn3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timerRiver4
            // 
            this.timerRiver4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timerEndGame5
            // 
            this.timerEndGame5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // lbl_hand
            // 
            this.lbl_hand.AutoSize = true;
            this.lbl_hand.BackColor = System.Drawing.Color.Transparent;
            this.lbl_hand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_hand.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_hand.Location = new System.Drawing.Point(471, 338);
            this.lbl_hand.Name = "lbl_hand";
            this.lbl_hand.Size = new System.Drawing.Size(0, 25);
            this.lbl_hand.TabIndex = 9;
            // 
            // pbOppCard1
            // 
            this.pbOppCard1.Image = global::gamePlay.Properties.Resources._Back;
            this.pbOppCard1.Location = new System.Drawing.Point(3, 35);
            this.pbOppCard1.Name = "pbOppCard1";
            this.pbOppCard1.Size = new System.Drawing.Size(63, 71);
            this.pbOppCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOppCard1.TabIndex = 10;
            this.pbOppCard1.TabStop = false;
            // 
            // pbOppCard2
            // 
            this.pbOppCard2.Image = ((System.Drawing.Image)(resources.GetObject("pbOppCard2.Image")));
            this.pbOppCard2.Location = new System.Drawing.Point(72, 35);
            this.pbOppCard2.Name = "pbOppCard2";
            this.pbOppCard2.Size = new System.Drawing.Size(63, 71);
            this.pbOppCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOppCard2.TabIndex = 11;
            this.pbOppCard2.TabStop = false;
            // 
            // closeTimer
            // 
            this.closeTimer.Enabled = true;
            this.closeTimer.Tick += new System.EventHandler(this.closeTimer_Tick);
            // 
            // frmGamePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(731, 434);
            this.Controls.Add(this.pbOppCard1);
            this.Controls.Add(this.pbOppCard2);
            this.Controls.Add(this.lbl_hand);
            this.Controls.Add(this.tbOppPot);
            this.Controls.Add(this.lbl_state);
            this.Controls.Add(this.lblOppName);
            this.Controls.Add(this.tbRaise);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pbTableCard4);
            this.Controls.Add(this.pbTableCard5);
            this.Controls.Add(this.pbTableCard3);
            this.Controls.Add(this.pbTableCard2);
            this.Controls.Add(this.pbPlayerCard2);
            this.Controls.Add(this.pbPlayerCard1);
            this.Controls.Add(this.pbTableCard1);
            this.Controls.Add(this.tbPlayer);
            this.Controls.Add(this.tbPotTotalScore);
            this.Controls.Add(this.tbPoints);
            this.Controls.Add(this.tbBetUpdate);
            this.Controls.Add(this.tbScore);
            this.Controls.Add(this.tbPot);
            this.Controls.Add(this.tbOpponent);
            this.Controls.Add(this.btnFold);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.btnRaise);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(747, 472);
            this.MinimumSize = new System.Drawing.Size(747, 472);
            this.Name = "frmGamePlay";
            this.Text = "Poker Online Game";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGamePlay_FormClosed);
            this.Load += new System.EventHandler(this.frmGamePlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTableCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerCard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRaise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOppCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOppCard2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnRaise;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnFold;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TextBox tbOpponent;
        private System.Windows.Forms.TextBox tbPlayer;
        private System.Windows.Forms.PictureBox pbTableCard2;
        private System.Windows.Forms.PictureBox pbTableCard3;
        private System.Windows.Forms.PictureBox pbTableCard5;
        private System.Windows.Forms.PictureBox pbTableCard4;
        private System.Windows.Forms.TextBox tbPot;
        private System.Windows.Forms.PictureBox pbTableCard1;
        public System.Windows.Forms.PictureBox pbPlayerCard1;
        public System.Windows.Forms.PictureBox pbPlayerCard2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbPotTotalScore;
        private System.Windows.Forms.TextBox tbScore;
        private System.Windows.Forms.TextBox tbPoints;
        private System.Windows.Forms.TrackBar tbRaise;
        private System.Windows.Forms.TextBox tbBetUpdate;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblOppName;
        private System.Windows.Forms.Label lbl_state;
        private System.Windows.Forms.Timer timerStartGame1;
        private System.Windows.Forms.Timer timerFlop2;
        private System.Windows.Forms.TextBox tbOppPot;
        private System.Windows.Forms.Timer timerTurn3;
        private System.Windows.Forms.Timer timerRiver4;
        private System.Windows.Forms.Timer timerEndGame5;
        private System.Windows.Forms.Label lbl_hand;
        private System.Windows.Forms.PictureBox pbOppCard1;
        private System.Windows.Forms.PictureBox pbOppCard2;
        private System.Windows.Forms.Timer closeTimer;
    }
}

