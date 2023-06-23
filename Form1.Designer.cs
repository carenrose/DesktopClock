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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTime24h = new System.Windows.Forms.Label();
            this.lblTime12h = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime24h_Sec = new System.Windows.Forms.Label();
            this.lblTime12h_Sec = new System.Windows.Forms.Label();
            this.lblTime12h_ap = new System.Windows.Forms.Label();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTime24h
            // 
            this.lblTime24h.BackColor = System.Drawing.Color.Transparent;
            this.lblTime24h.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.lblTime24h.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTime24h.Location = new System.Drawing.Point(0, 1);
            this.lblTime24h.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime24h.Name = "lblTime24h";
            this.lblTime24h.Size = new System.Drawing.Size(128, 50);
            this.lblTime24h.TabIndex = 0;
            this.lblTime24h.Text = "00:00";
            this.lblTime24h.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTime12h
            // 
            this.lblTime12h.BackColor = System.Drawing.Color.Transparent;
            this.lblTime12h.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTime12h.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTime12h.Location = new System.Drawing.Point(2, 46);
            this.lblTime12h.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h.Name = "lblTime12h";
            this.lblTime12h.Size = new System.Drawing.Size(90, 31);
            this.lblTime12h.TabIndex = 0;
            this.lblTime12h.Text = "0:00";
            this.lblTime12h.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblDate.Location = new System.Drawing.Point(13, 98);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(163, 29);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "01/01/0000";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTime24h_Sec
            // 
            this.lblTime24h_Sec.BackColor = System.Drawing.Color.Transparent;
            this.lblTime24h_Sec.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblTime24h_Sec.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTime24h_Sec.Location = new System.Drawing.Point(115, -1);
            this.lblTime24h_Sec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime24h_Sec.Name = "lblTime24h_Sec";
            this.lblTime24h_Sec.Size = new System.Drawing.Size(68, 50);
            this.lblTime24h_Sec.TabIndex = 0;
            this.lblTime24h_Sec.Text = ":00";
            this.lblTime24h_Sec.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTime12h_Sec
            // 
            this.lblTime12h_Sec.BackColor = System.Drawing.Color.Transparent;
            this.lblTime12h_Sec.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTime12h_Sec.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTime12h_Sec.Location = new System.Drawing.Point(83, 46);
            this.lblTime12h_Sec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h_Sec.Name = "lblTime12h_Sec";
            this.lblTime12h_Sec.Size = new System.Drawing.Size(39, 31);
            this.lblTime12h_Sec.TabIndex = 1;
            this.lblTime12h_Sec.Text = ":00";
            this.lblTime12h_Sec.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblTime12h_ap
            // 
            this.lblTime12h_ap.BackColor = System.Drawing.Color.Transparent;
            this.lblTime12h_ap.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTime12h_ap.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblTime12h_ap.Location = new System.Drawing.Point(117, 46);
            this.lblTime12h_ap.Margin = new System.Windows.Forms.Padding(0);
            this.lblTime12h_ap.Name = "lblTime12h_ap";
            this.lblTime12h_ap.Size = new System.Drawing.Size(59, 31);
            this.lblTime12h_ap.TabIndex = 2;
            this.lblTime12h_ap.Text = "pm";
            this.lblTime12h_ap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.BackColor = System.Drawing.Color.Transparent;
            this.lblDayOfWeek.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDayOfWeek.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblDayOfWeek.Location = new System.Drawing.Point(13, 77);
            this.lblDayOfWeek.Margin = new System.Windows.Forms.Padding(0);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(163, 22);
            this.lblDayOfWeek.TabIndex = 3;
            this.lblDayOfWeek.Text = "Wednesday";
            this.lblDayOfWeek.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(188, 127);
            this.Controls.Add(this.lblDayOfWeek);
            this.Controls.Add(this.lblTime12h_ap);
            this.Controls.Add(this.lblTime12h_Sec);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime12h);
            this.Controls.Add(this.lblTime24h_Sec);
            this.Controls.Add(this.lblTime24h);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

