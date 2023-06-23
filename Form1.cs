using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Timer Timer { get; set; }

        private Color InitialColor;
        //private static Color InitialColor      = SystemColors.ControlLight;
        private static Color FirstChangeColor  = Color.Goldenrod;
        private static Color SecondChangeColor = SystemColors.Highlight;

        private (int hour, int minute) FirstChangeTime;
        private (int hour, int minute) SecondChangeTime;
        private (int hour, int minute) ChangeBackTime;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitialColor = lblTime12h.ForeColor;

            // position!
            // https://stackoverflow.com/questions/1363374/showing-a-windows-form-on-a-secondary-monitor

            var positionOnScreen = (Screen.AllScreens.Length > 1)
                ? Screen.AllScreens.FirstOrDefault(s => s.DeviceName == @"\\.\DISPLAY1")        // the second monitor happens to be "\\.\DISPLAY1"
                : Screen.PrimaryScreen;
            if (positionOnScreen != null)
            {
                this.Top  = positionOnScreen.WorkingArea.Bottom - this.Height;
                this.Left = positionOnScreen.WorkingArea.Right  - this.Width ;
            }



            #region Parse times from App.config

            var change1 = ConfigurationManager.AppSettings.Get("FirstColorChangeTime" )?.Split(':');
            var change2 = ConfigurationManager.AppSettings.Get("SecondColorChangeTime")?.Split(':');
            var change3 = ConfigurationManager.AppSettings.Get("ChangeBackTime"       )?.Split(':');

            // fallback to 16:30
            this.FirstChangeTime = (16, 30);
            if (change1 != null && change1.Length == 2)
            {
                if (int.TryParse(change1[0], out var hour) && int.TryParse(change1[1], out var mins))
                {
                    this.FirstChangeTime = (hour, mins);
                }
            }

            // fallback to 17:00
            this.SecondChangeTime = (17, 00);
            if (change2 != null && change2.Length == 2)
            {
                if (int.TryParse(change2[0], out var hour) && int.TryParse(change2[1], out var mins))
                {
                    this.SecondChangeTime = (hour, mins);
                }
            }

            // fallback to 20:00
            this.ChangeBackTime = (20, 00);
            if (change3 != null && change3.Length == 2)
            {
                if (int.TryParse(change3[0], out var hour) && int.TryParse(change3[1], out var mins))
                {
                    this.ChangeBackTime = (hour, mins);
                }
            }

            #endregion

            // timer
            this.Timer = new Timer { Interval = 1000 };
            this.Timer.Tick += Timer_Tick;
            this.Timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            lblTime24h  .Text = $"{now:HH:mm}";
            lblTime12h  .Text = $"{now:h:mm}";
            lblDate     .Text = $"{now:M/d/yyyy}";
            lblDayOfWeek.Text = now.DayOfWeek.ToString();

            lblTime24h_Sec.Text = $":{now:ss}";
            lblTime12h_Sec.Text = $":{now:ss}";
            lblTime12h_ap .Text = $"{now:tt}".ToLower();


            #region Color changing

            var withinFirstColorTime = now.Hour > this.FirstChangeTime .hour || (now.Hour == this.FirstChangeTime .hour && now.Minute >= this.FirstChangeTime .minute);
            var withinSecndColorTime = now.Hour > this.SecondChangeTime.hour || (now.Hour == this.SecondChangeTime.hour && now.Minute >= this.SecondChangeTime.minute);
            var afterChangeBackTime  = now.Hour > this.ChangeBackTime  .hour || (now.Hour == this.ChangeBackTime  .hour && now.Minute >= this.ChangeBackTime  .minute);

            if (withinFirstColorTime && !withinSecndColorTime && !afterChangeBackTime)
            {
                // change to first color
                if (lblTime12h.ForeColor != FirstChangeColor)
                {
                    lblTime12h.ForeColor     = FirstChangeColor;
                    lblTime12h_Sec.ForeColor = FirstChangeColor;
                    lblTime12h_ap.ForeColor  = FirstChangeColor;
                }
            }
            else if (withinSecndColorTime && !afterChangeBackTime)
            {
                // change to second color
                if (lblTime12h.ForeColor != SecondChangeColor)
                {
                    lblTime12h.ForeColor     = SecondChangeColor;
                    lblTime12h_Sec.ForeColor = SecondChangeColor;
                    lblTime12h_ap.ForeColor  = SecondChangeColor;
                }
            }
            else
            {
                // if color is not initial, change back to initial
                if (lblTime12h.ForeColor != InitialColor)
                {
                    lblTime12h.ForeColor     = InitialColor;
                    lblTime12h_Sec.ForeColor = InitialColor;
                    lblTime12h_ap.ForeColor  = InitialColor;
                }
            }

            /*
            // change at 1630
            if (lblTime12h.ForeColor == this.InitialColor && now.Hour >= 16 && now.Minute >= 30)
            {
                lblTime12h.ForeColor     = FirstChangeColor;
                lblTime12h_Sec.ForeColor = FirstChangeColor;
                lblTime12h_ap.ForeColor  = FirstChangeColor;
            }
            // change at 1700
            else if (lblTime12h.ForeColor != SecondChangeColor && now.Hour >= 17)
            {
                lblTime12h.ForeColor     = SecondChangeColor;
                lblTime12h_Sec.ForeColor = SecondChangeColor;
                lblTime12h_ap.ForeColor  = SecondChangeColor;
            }
            // change back
            else if (lblTime12h.ForeColor != this.InitialColor && now.Hour >= 20)
            {
                lblTime12h.ForeColor     = this.InitialColor;
                lblTime12h_Sec.ForeColor = this.InitialColor;
                lblTime12h_ap.ForeColor  = this.InitialColor;
            }
            */
            #endregion
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Timer?.Enabled ?? false)
            {
                this.Timer.Stop();
                this.Timer.Dispose();
            }
        }
    }
}
