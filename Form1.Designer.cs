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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTime24h = new System.Windows.Forms.Label();
            this.lblTime12h = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime24h_Sec = new System.Windows.Forms.Label();
            this.lblTime12h_Sec = new System.Windows.Forms.Label();
            this.lblTime12h_ap = new System.Windows.Forms.Label();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            this.ttpLockedUnlockedTimes = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lbxLockTimes = new System.Windows.Forms.ListBox();
            this.lbxUnlockTimes = new System.Windows.Forms.ListBox();
            lblLockTimes = new System.Windows.Forms.Label();
            lblUnlockTimes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLockTimes
            // 
            lblLockTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lblLockTimes.AutoSize = true;
            lblLockTimes.BackColor = System.Drawing.Color.Transparent;
            lblLockTimes.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            lblLockTimes.ForeColor = System.Drawing.SystemColors.ControlDark;
            lblLockTimes.Location = new System.Drawing.Point(112, 2);
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
            lblUnlockTimes.Location = new System.Drawing.Point(2, 2);
            lblUnlockTimes.Margin = new System.Windows.Forms.Padding(2);
            lblUnlockTimes.Name = "lblUnlockTimes";
            lblUnlockTimes.Size = new System.Drawing.Size(75, 13);
            lblUnlockTimes.TabIndex = 4;
            lblUnlockTimes.Text = "Unlock Times";
            lblUnlockTimes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTime24h
            // 
            this.lblTime24h.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime24h.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime24h.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.lblTime24h.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTime24h.Location = new System.Drawing.Point(0, 0);
            this.lblTime24h.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime24h.Name = "lblTime24h";
            this.lblTime24h.Size = new System.Drawing.Size(111, 50);
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
            this.lblTime12h.Location = new System.Drawing.Point(1, 45);
            this.lblTime12h.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h.Name = "lblTime12h";
            this.lblTime12h.Size = new System.Drawing.Size(74, 31);
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
            this.lblDate.Location = new System.Drawing.Point(5, 97);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(154, 29);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "01/01/0000";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // lblTime24h_Sec
            // 
            this.lblTime24h_Sec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime24h_Sec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime24h_Sec.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTime24h_Sec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTime24h_Sec.Location = new System.Drawing.Point(111, 8);
            this.lblTime24h_Sec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime24h_Sec.Name = "lblTime24h_Sec";
            this.lblTime24h_Sec.Size = new System.Drawing.Size(48, 40);
            this.lblTime24h_Sec.TabIndex = 0;
            this.lblTime24h_Sec.Text = ":00";
            this.lblTime24h_Sec.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTime12h_Sec
            // 
            this.lblTime12h_Sec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime12h_Sec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime12h_Sec.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTime12h_Sec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblTime12h_Sec.Location = new System.Drawing.Point(69, 50);
            this.lblTime12h_Sec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h_Sec.Name = "lblTime12h_Sec";
            this.lblTime12h_Sec.Size = new System.Drawing.Size(36, 26);
            this.lblTime12h_Sec.TabIndex = 1;
            this.lblTime12h_Sec.Text = ":00";
            this.lblTime12h_Sec.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTime12h_ap
            // 
            this.lblTime12h_ap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime12h_ap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTime12h_ap.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTime12h_ap.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTime12h_ap.Location = new System.Drawing.Point(111, 45);
            this.lblTime12h_ap.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h_ap.Name = "lblTime12h_ap";
            this.lblTime12h_ap.Size = new System.Drawing.Size(48, 31);
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
            this.lblDayOfWeek.Location = new System.Drawing.Point(1, 76);
            this.lblDayOfWeek.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(158, 22);
            this.lblDayOfWeek.TabIndex = 3;
            this.lblDayOfWeek.Text = "Wednesday";
            this.lblDayOfWeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ttpLockedUnlockedTimes
            // 
            this.ttpLockedUnlockedTimes.AutoPopDelay = 10000;
            this.ttpLockedUnlockedTimes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ttpLockedUnlockedTimes.ForeColor = System.Drawing.SystemColors.Info;
            this.ttpLockedUnlockedTimes.InitialDelay = 150;
            this.ttpLockedUnlockedTimes.ReshowDelay = 100;
            this.ttpLockedUnlockedTimes.ShowAlways = true;
            this.ttpLockedUnlockedTimes.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpLockedUnlockedTimes.ToolTipTitle = "Computer Lock/Unlock Times:";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(1, 1);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lblTime24h);
            this.splitContainer.Panel1.Controls.Add(this.lblDayOfWeek);
            this.splitContainer.Panel1.Controls.Add(this.lblTime24h_Sec);
            this.splitContainer.Panel1.Controls.Add(this.lblTime12h_ap);
            this.splitContainer.Panel1.Controls.Add(this.lblTime12h);
            this.splitContainer.Panel1.Controls.Add(this.lblTime12h_Sec);
            this.splitContainer.Panel1.Controls.Add(this.lblDate);
            this.splitContainer.Panel1MinSize = 175;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.lbxLockTimes);
            this.splitContainer.Panel2.Controls.Add(this.lbxUnlockTimes);
            this.splitContainer.Panel2.Controls.Add(lblUnlockTimes);
            this.splitContainer.Panel2.Controls.Add(lblLockTimes);
            this.splitContainer.Panel2MinSize = 175;
            this.splitContainer.Size = new System.Drawing.Size(351, 128);
            this.splitContainer.SplitterDistance = 175;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 4;
            // 
            // lbxLockTimes
            // 
            this.lbxLockTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxLockTimes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbxLockTimes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxLockTimes.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lbxLockTimes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbxLockTimes.FormattingEnabled = true;
            this.lbxLockTimes.Location = new System.Drawing.Point(97, 20);
            this.lbxLockTimes.Name = "lbxLockTimes";
            this.lbxLockTimes.Size = new System.Drawing.Size(75, 104);
            this.lbxLockTimes.TabIndex = 5;
            // 
            // lbxUnlockTimes
            // 
            this.lbxUnlockTimes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxUnlockTimes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbxUnlockTimes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxUnlockTimes.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lbxUnlockTimes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbxUnlockTimes.FormattingEnabled = true;
            this.lbxUnlockTimes.Location = new System.Drawing.Point(5, 20);
            this.lbxUnlockTimes.Name = "lbxUnlockTimes";
            this.lbxUnlockTimes.Size = new System.Drawing.Size(75, 104);
            this.lbxUnlockTimes.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(352, 127);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(193, 166);
            this.Name = "Form1";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
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
        private System.Windows.Forms.ToolTip ttpLockedUnlockedTimes;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox lbxLockTimes;
        private System.Windows.Forms.ListBox lbxUnlockTimes;
    }
}

