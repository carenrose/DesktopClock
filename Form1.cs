using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // notes
        // https://stackoverflow.com/a/21633902/ - to remove label padding, set the FlatStyle

        // Form height 166
        // left/right form border (9px each), 18 total

        // panel size 185 w X 128 h





        // ////////////////////////////////////////////////////////////////////////////////////////////////

        private Timer Timer { get; set; }


        private        Color InitialColor;
        private static Color FirstChangeColor  = Color.Goldenrod;
        private static Color SecondChangeColor = SystemColors.Highlight;

        private (int hour, int minute) FirstChangeTime;
        private (int hour, int minute) SecondChangeTime;
        private (int hour, int minute) ChangeBackTime;

        private List<DateTime> LockTimes   = new List<DateTime>();
        private List<DateTime> UnlockTimes = new List<DateTime>();
        private List<TimeSpan> Durations   = new List<TimeSpan>();

        // ////////////////////////////////////////////////////////////////////////////////////////////////


        // https://stackoverflow.com/questions/1363374/showing-a-windows-form-on-a-secondary-monitor
        private Screen GetMonitorToPositionOn()
        {
            return (Screen.AllScreens.Length > 1)
                ? Screen.AllScreens.FirstOrDefault(s => s.DeviceName == @"\\.\DISPLAY1")        // the second monitor happens to be "\\.\DISPLAY1"
                : Screen.PrimaryScreen;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitialColor = lblTime12h.ForeColor;

            // ////////////////////////////////////////////////////////////////

            SetFormSize_FromPanelVisibility();

            // ////////////////////////////////////////////////////////////////

            // position!

            var monitorToPositionOn = GetMonitorToPositionOn();
            if (monitorToPositionOn != null)
            {
                this.Top  = monitorToPositionOn.WorkingArea.Bottom - this.Height;
                this.Left = monitorToPositionOn.WorkingArea.Right  - this.Width ;
#if DEBUG
                this.Top = monitorToPositionOn.WorkingArea.Bottom - (this.Height * 2);     // if DEBUG, show it above the currently running one
                this.Opacity = 0.95D;                                                   // and since that's over text on the desktop background, make it more opaque

                this.LockTimes.Add(DateTime.Now.AddHours(-1));
                this.UnlockTimes.Add(DateTime.Now.AddMinutes(-15));
                this.UnlockTimes.Add(DateTime.Now.AddMinutes(-16));
                this.Durations.Add(new TimeSpan(12, 15, 12));
                UpdateLockTimesListBoxes();
#endif
            }

            MoveFormPosition_FromPanelVisibility();

            // ////////////////////////////////////////////////////////////////

            // oooooooh detect locks/unlocks
            // https://stackoverflow.com/a/652574/
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;


            // ////////////////////////////////////////////////////////////////

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

            // ////////////////////////////////////////////////////////////////

            // initialize timer and start
            this.Timer = new Timer { Interval = 1000 };
            this.Timer.Tick += Timer_Tick;
            this.Timer.Start();
        }

        // ////////////////////////////////////////////////////////////////////////////////////////////////

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


        // ////////////////////////////////////////////////////////////////////////////////////////////////

        // https://stackoverflow.com/a/652574/
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            var now = DateTime.Now;

            switch (e.Reason)
            {
                // ////////////////////////////////////////////////
                // On lock or logoff
                // ////////////////////////////////////////////////

                case SessionSwitchReason.SessionLock  :
                case SessionSwitchReason.SessionLogoff:
                    // add to list
                    this.LockTimes.Add(now);

                    // add to box
                    UpdateLockTimesListBoxes(); 

                    break;


                // ////////////////////////////////////////////////
                // On unlock or logon
                // ////////////////////////////////////////////////

                case SessionSwitchReason.SessionUnlock:
                case SessionSwitchReason.SessionLogon :
                    var mostRecentLockTime = this.LockTimes.OrderByDescending(d => d).FirstOrDefault();

                    var addShortLocks = ConfigHelper.GetValueBool("AddShortLocks");     // defaults to false
                    if (this.LockTimes.Any() && !addShortLocks)
                    {
                        // if the duration the computer was locked is < 1 minute (since last lock)
                        // remove the last lock time, and don't add the unlock time
                        if (mostRecentLockTime.AddMinutes(1) > now)
                        {
                            this.LockTimes.Remove(mostRecentLockTime);
                        }
                        else
                        {
                            // add to list
                            this.UnlockTimes.Add(now);
                            this.Durations.Add(now - mostRecentLockTime);
                        }
                    }
                    else
                    {
                        // add to list
                        this.UnlockTimes.Add(now);
                        if (mostRecentLockTime != null)
                        {
                            this.Durations.Add(now - mostRecentLockTime);
                        }
                    }

                    // update listbox
                    UpdateLockTimesListBoxes(); 

                    break;


                // ////////////////////////////////////////////////

                //case SessionSwitchReason.ConsoleConnect      :
                //case SessionSwitchReason.ConsoleDisconnect   :
                //case SessionSwitchReason.RemoteConnect       :
                //case SessionSwitchReason.RemoteDisconnect    :
                //case SessionSwitchReason.SessionRemoteControl:
                //default: break;
            }
        }


        private void UpdateLockTimesListBoxes()
        {
            // remove lock/unlock times that aren't from today
            // (to keep the list from growing and growing)
            var startOfDay = DateTime.Today;

            this.UnlockTimes.RemoveAll(d => d < startOfDay);
            this.LockTimes  .RemoveAll(d => d < startOfDay);

            // ////////////////////////////////////////////////////////////////

            // this determines the format
            var shortLockDurationsShown = ConfigHelper.GetValueBool("AddShortLocks");

            // clear current text in list boxes
            lbxUnlockTimes.Items.Clear();
            lbxLockTimes  .Items.Clear();
            lbxDuration   .Items.Clear();

            // add blank item to lock times at top
            // because it lines up that way (you can read across)
            lbxLockTimes.Items.Add((shortLockDurationsShown) ? "-- -- --" : "-- --");
            lbxDuration .Items.Add((shortLockDurationsShown) ? "-- -- --" : "-- --");

            // order with most recent on top
            var ulOrdered = this.UnlockTimes.OrderByDescending(d => d);
            var lOrdered  = this.LockTimes  .OrderByDescending(d => d);

            // add to list boxes
            foreach (var item in ulOrdered) { lbxUnlockTimes.Items.Add( (shortLockDurationsShown) ? item.ToString("HH:mm:ss") : item.ToString("HH:mm") ); }
            foreach (var item in lOrdered ) { lbxLockTimes  .Items.Add( (shortLockDurationsShown) ? item.ToString("HH:mm:ss") : item.ToString("HH:mm") ); }
            for (int i = this.Durations.Count - 1; i >= 0; i--)
            {
                var item = this.Durations[i];
                lbxDuration.Items.Add((shortLockDurationsShown) 
                    ? item.ToString(@"h\:mm\:ss") 
                    : item.ToString(@"h\:mm"));
            }
        }

        // ////////////////////////////////////////////////

        // alt row color
        // https://stackoverflow.com/a/2555062/
        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var g = e.Graphics;

            //var isAltRow = (sender == this.lbxUnlockTimes)
            //    ? (e.Index % 2 == 1)    // unlock times, alt is second row
            //    : (e.Index % 2 == 0);   // lock times,   alt is first row
            var isAltRow = (e.Index % 2 == 1);

            if (isAltRow)
            {
                // draw the background color you want
                g.FillRectangle(
                    new SolidBrush(Color.FromArgb(64, 0,0,0)),      // 25% opacity black
                    e.Bounds);
            }

            // draw the text of the list item, not doing this will only show the background color
            // you will need to get the text of item to display
            var itemText = (sender as ListBox).Items[e.Index].ToString();
            g.DrawString(itemText, 
                e.Font, 
                new SolidBrush(e.ForeColor), 
                new PointF(e.Bounds.X, e.Bounds.Y) );

            e.DrawFocusRectangle();
        }

        // ////////////////////////////////////////////////

        private void lblDate_Click(object sender, EventArgs e)
        {
            // toggle panel visibility
            pnlLockTimes.Visible = !pnlLockTimes.Visible;

            // set form width, bump over window position if necessary
            SetFormSize_FromPanelVisibility();
            MoveFormPosition_FromPanelVisibility();
        }

        // ////////////////////////////////////////////////

        private void SetFormSize_FromPanelVisibility()
        {
            // I don't think here you have to include the 9px border
            if (pnlLockTimes.Visible)
            {
                this.Width = pnlMain.Width + pnlLockTimes.Width;
            }
            else
            {
                this.Width = pnlMain.Width;
            }
        }

        private void MoveFormPosition_FromPanelVisibility()
        {
            var monitor = GetMonitorToPositionOn();
            if (monitor != null)
            {
                var maxEdgeOfDisplay = monitor.WorkingArea.Right;

                if (pnlLockTimes.Visible &&                     // if the lock times panel is visible
                    this.Left + this.Width > maxEdgeOfDisplay)  // and the form is now wider than will fit on the current monitor
                {
                    // align it to the right edge of the screen
                    this.Left = maxEdgeOfDisplay - this.Width;
                }

                if (!pnlLockTimes.Visible &&                                            // if lock times panel is not visible
                    this.Left + pnlLockTimes.Width + this.Width <= maxEdgeOfDisplay)    // and the right edge will not be off screen
                {
                    // scoot it over to the right by the panel width
                    this.Left += pnlLockTimes.Width;
                }
            }
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Timer?.Enabled ?? false)
            {
                this.Timer.Stop();
                this.Timer.Dispose();
            }
        }


        // ////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
