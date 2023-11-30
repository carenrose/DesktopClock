namespace Clock
{
    partial class Form1
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
            System.Windows.Forms.Label lblLockTimes;
            System.Windows.Forms.Label lblUnlockTimes;
            System.Windows.Forms.Label lblVerticalLine;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTime24h = new System.Windows.Forms.Label();
            this.lblTime12h = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime24h_Sec = new System.Windows.Forms.Label();
            this.lblTime12h_Sec = new System.Windows.Forms.Label();
            this.lblTime12h_ap = new System.Windows.Forms.Label();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            this.lbxLockTimes = new System.Windows.Forms.ListBox();
            this.lbxUnlockTimes = new System.Windows.Forms.ListBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLockTimes = new System.Windows.Forms.Panel();
            this.ttpClickDateInfo = new System.Windows.Forms.ToolTip(this.components);
            this.lbxDuration = new System.Windows.Forms.ListBox();
            lblLockTimes = new System.Windows.Forms.Label();
            lblUnlockTimes = new System.Windows.Forms.Label();
            lblVerticalLine = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlLockTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLockTimes
            // 
            lblLockTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lblLockTimes.AutoSize = true;
            lblLockTimes.BackColor = System.Drawing.Color.Transparent;
            lblLockTimes.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            lblLockTimes.ForeColor = System.Drawing.SystemColors.ControlDark;
            lblLockTimes.Location = new System.Drawing.Point(139, 4);
            lblLockTimes.Margin = new System.Windows.Forms.Padding(2);
            lblLockTimes.Name = "lblLockTimes";
            lblLockTimes.Size = new System.Drawing.Size(63, 13);
            lblLockTimes.TabIndex = 4;
            lblLockTimes.Text = "Lock Times";
            lblLockTimes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUnlockTimes
            // 
            lblUnlockTimes.AutoSize = true;
            lblUnlockTimes.BackColor = System.Drawing.Color.Transparent;
            lblUnlockTimes.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            lblUnlockTimes.ForeColor = System.Drawing.SystemColors.ControlDark;
            lblUnlockTimes.Location = new System.Drawing.Point(3, 4);
            lblUnlockTimes.Margin = new System.Windows.Forms.Padding(2);
            lblUnlockTimes.Name = "lblUnlockTimes";
            lblUnlockTimes.Size = new System.Drawing.Size(75, 13);
            lblUnlockTimes.TabIndex = 4;
            lblUnlockTimes.Text = "Unlock Times";
            lblUnlockTimes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblVerticalLine
            // 
            lblVerticalLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            lblVerticalLine.Location = new System.Drawing.Point(0, 0);
            lblVerticalLine.Name = "lblVerticalLine";
            lblVerticalLine.Size = new System.Drawing.Size(1, 128);
            lblVerticalLine.TabIndex = 7;
            // 
            // lblTime24h
            // 
            this.lblTime24h.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime24h.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime24h.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.lblTime24h.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTime24h.Location = new System.Drawing.Point(9, 0);
            this.lblTime24h.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime24h.Name = "lblTime24h";
            this.lblTime24h.Size = new System.Drawing.Size(106, 50);
            this.lblTime24h.TabIndex = 0;
            this.lblTime24h.Text = "00:00";
            this.lblTime24h.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTime12h
            // 
            this.lblTime12h.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime12h.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime12h.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTime12h.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTime12h.Location = new System.Drawing.Point(9, 45);
            this.lblTime12h.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h.Name = "lblTime12h";
            this.lblTime12h.Size = new System.Drawing.Size(72, 31);
            this.lblTime12h.TabIndex = 0;
            this.lblTime12h.Text = "0:00";
            this.lblTime12h.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblDate.Location = new System.Drawing.Point(0, 97);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(185, 29);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "01/01/0000";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ttpClickDateInfo.SetToolTip(this.lblDate, "Click to show/hide lock times");
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // lblTime24h_Sec
            // 
            this.lblTime24h_Sec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime24h_Sec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime24h_Sec.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTime24h_Sec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTime24h_Sec.Location = new System.Drawing.Point(121, 8);
            this.lblTime24h_Sec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime24h_Sec.Name = "lblTime24h_Sec";
            this.lblTime24h_Sec.Size = new System.Drawing.Size(47, 40);
            this.lblTime24h_Sec.TabIndex = 0;
            this.lblTime24h_Sec.Text = ":00";
            this.lblTime24h_Sec.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTime12h_Sec
            // 
            this.lblTime12h_Sec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime12h_Sec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime12h_Sec.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTime12h_Sec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTime12h_Sec.Location = new System.Drawing.Point(85, 50);
            this.lblTime12h_Sec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h_Sec.Name = "lblTime12h_Sec";
            this.lblTime12h_Sec.Size = new System.Drawing.Size(30, 26);
            this.lblTime12h_Sec.TabIndex = 1;
            this.lblTime12h_Sec.Text = ":00";
            this.lblTime12h_Sec.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTime12h_ap
            // 
            this.lblTime12h_ap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime12h_ap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime12h_ap.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTime12h_ap.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTime12h_ap.Location = new System.Drawing.Point(114, 45);
            this.lblTime12h_ap.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h_ap.Name = "lblTime12h_ap";
            this.lblTime12h_ap.Size = new System.Drawing.Size(52, 31);
            this.lblTime12h_ap.TabIndex = 2;
            this.lblTime12h_ap.Text = "pm";
            this.lblTime12h_ap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDayOfWeek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblDayOfWeek.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDayOfWeek.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblDayOfWeek.Location = new System.Drawing.Point(0, 76);
            this.lblDayOfWeek.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(185, 22);
            this.lblDayOfWeek.TabIndex = 3;
            this.lblDayOfWeek.Text = "Wednesday";
            this.lblDayOfWeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbxLockTimes
            // 
            this.lbxLockTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxLockTimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbxLockTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxLockTimes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbxLockTimes.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lbxLockTimes.ForeColor = System.Drawing.Color.LightGray;
            this.lbxLockTimes.FormattingEnabled = true;
            this.lbxLockTimes.Location = new System.Drawing.Point(133, 22);
            this.lbxLockTimes.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
            this.lbxLockTimes.Name = "lbxLockTimes";
            this.lbxLockTimes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxLockTimes.Size = new System.Drawing.Size(67, 106);
            this.lbxLockTimes.TabIndex = 5;
            this.lbxLockTimes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            // 
            // lbxUnlockTimes
            // 
            this.lbxUnlockTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxUnlockTimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbxUnlockTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxUnlockTimes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbxUnlockTimes.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lbxUnlockTimes.ForeColor = System.Drawing.Color.LightGray;
            this.lbxUnlockTimes.FormattingEnabled = true;
            this.lbxUnlockTimes.Location = new System.Drawing.Point(6, 22);
            this.lbxUnlockTimes.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.lbxUnlockTimes.Name = "lbxUnlockTimes";
            this.lbxUnlockTimes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxUnlockTimes.Size = new System.Drawing.Size(65, 106);
            this.lbxUnlockTimes.TabIndex = 5;
            this.lbxUnlockTimes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMain.Controls.Add(this.lblTime24h);
            this.pnlMain.Controls.Add(this.lblDayOfWeek);
            this.pnlMain.Controls.Add(this.lblDate);
            this.pnlMain.Controls.Add(this.lblTime24h_Sec);
            this.pnlMain.Controls.Add(this.lblTime12h_Sec);
            this.pnlMain.Controls.Add(this.lblTime12h_ap);
            this.pnlMain.Controls.Add(this.lblTime12h);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(185, 128);
            this.pnlMain.TabIndex = 5;
            // 
            // pnlLockTimes
            // 
            this.pnlLockTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLockTimes.Controls.Add(lblVerticalLine);
            this.pnlLockTimes.Controls.Add(this.lbxLockTimes);
            this.pnlLockTimes.Controls.Add(this.lbxDuration);
            this.pnlLockTimes.Controls.Add(this.lbxUnlockTimes);
            this.pnlLockTimes.Controls.Add(lblLockTimes);
            this.pnlLockTimes.Controls.Add(lblUnlockTimes);
            this.pnlLockTimes.Location = new System.Drawing.Point(185, 0);
            this.pnlLockTimes.Name = "pnlLockTimes";
            this.pnlLockTimes.Size = new System.Drawing.Size(200, 128);
            this.pnlLockTimes.TabIndex = 6;
            this.pnlLockTimes.Visible = false;
            // 
            // ttpClickDateInfo
            // 
            this.ttpClickDateInfo.AutoPopDelay = 10000;
            this.ttpClickDateInfo.InitialDelay = 150;
            this.ttpClickDateInfo.ReshowDelay = 100;
            // 
            // lbxDuration
            // 
            this.lbxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lbxDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxDuration.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbxDuration.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.lbxDuration.ForeColor = System.Drawing.Color.LightGray;
            this.lbxDuration.FormattingEnabled = true;
            this.lbxDuration.Location = new System.Drawing.Point(75, 22);
            this.lbxDuration.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lbxDuration.Name = "lbxDuration";
            this.lbxDuration.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxDuration.Size = new System.Drawing.Size(54, 106);
            this.lbxDuration.TabIndex = 5;
            this.lbxDuration.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(387, 127);
            this.Controls.Add(this.pnlLockTimes);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(185, 166);
            this.Name = "Form1";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlLockTimes.ResumeLayout(false);
            this.pnlLockTimes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTime24h;
        private System.Windows.Forms.Label lblTime12h;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime24h_Sec;
        private System.Windows.Forms.Label lblTime12h_Sec;
        private System.Windows.Forms.Label lblTime12h_ap;
        private System.Windows.Forms.Label lblDayOfWeek;
        private System.Windows.Forms.ListBox lbxLockTimes;
        private System.Windows.Forms.ListBox lbxUnlockTimes;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLockTimes;
        private System.Windows.Forms.ToolTip ttpClickDateInfo;
        private System.Windows.Forms.ListBox lbxDuration;
    }
}

