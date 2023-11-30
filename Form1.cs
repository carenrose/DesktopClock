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

        // ////////////////////////////////////////////////////////////////////////////////////////////////



        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitialColor = lblTime12h.ForeColor;

            // ////////////////////////////////////////////////////////////////

            // position!
            // https://stackoverflow.com/questions/1363374/showing-a-windows-form-on-a-secondary-monitor

            var positionOnScreen = (Screen.AllScreens.Length > 1)
                ? Screen.AllScreens.FirstOrDefault(s => s.DeviceName == @"\\.\DISPLAY1")        // the second monitor happens to be "\\.\DISPLAY1"
                : Screen.PrimaryScreen;
            if (positionOnScreen != null)
            {
                this.Top  = positionOnScreen.WorkingArea.Bottom - this.Height;
                this.Left = positionOnScreen.WorkingArea.Right  - this.Width ;
#if DEBUG
                this.Top = positionOnScreen.WorkingArea.Bottom - (this.Height * 2);     // if DEBUG, show it above the currently running one
                this.Opacity = 0.95D;                                                   // and since that's over text on the desktop background, make it more opaque
#endif
            }

            // ////////////////////////////////////////////////////////////////

            // oooooooh can we detect locks/unlocks??
            // https://stackoverflow.com/a/652574/

            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

            //// TODO for now
            //ttpLockedUnlockedTimes.SetToolTip(lblDate, "None yet!");
            //lblDate.Cursor = Cursors.Hand;

            SetFormSizeBasedOnPanels();


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
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionUnlock:
                case SessionSwitchReason.SessionLogon : this.UnlockTimes.Add(DateTime.Now); AddLockTimesToListBox(); break; //SetToolTip(); break;

                case SessionSwitchReason.SessionLock  :
                case SessionSwitchReason.SessionLogoff: this.  LockTimes.Add(DateTime.Now); AddLockTimesToListBox(); break; // SetToolTip(); break;

                //case SessionSwitchReason.ConsoleConnect      :
                //case SessionSwitchReason.ConsoleDisconnect   :
                //case SessionSwitchReason.RemoteConnect       :
                //case SessionSwitchReason.RemoteDisconnect    :
                //case SessionSwitchReason.SessionRemoteControl:

                //default: break;
            }
        }



        private void RemoveOldLockUnlockTimes()
        {
            // remove lock/unlock times that aren't from today
            // (to keep the list from growing and growing)
            var startOfDay = DateTime.Today;

            this.UnlockTimes.RemoveAll(d => d < startOfDay);
            this.LockTimes  .RemoveAll(d => d < startOfDay);
        }


        private void SetToolTip()
        {
            // remove old times
            RemoveOldLockUnlockTimes();

            var unlockedMsg = "";
            var lockedMsg   = "";

            if (this.UnlockTimes.Any())
            {
                unlockedMsg = "Unlocked: " + string.Join(", ", this.UnlockTimes.Select(d => d.ToShortTimeString()) );
            }

            if (this.LockTimes.Any())
            {
                lockedMsg = "Locked: " + string.Join(", ", this.LockTimes.Select(d => d.ToShortTimeString()));
            }

            var tooltipText = (lockedMsg + Environment.NewLine + unlockedMsg).Trim();

            // set tooltip text - it shows when hovering over the date label (at the bottom)
            ttpLockedUnlockedTimes.SetToolTip(lblDate, tooltipText);
            lblDate.Cursor = Cursors.Hand;
        }

        private void AddLockTimesToListBox()
        {
            // remove old times
            RemoveOldLockUnlockTimes();

            // clear current text in list boxes
            lbxUnlockTimes.Items.Clear();
            lbxLockTimes  .Items.Clear();

            // order with most recent on top
            var ulOrdered = this.UnlockTimes.OrderByDescending(d => d);
            var lOrdered  = this.LockTimes  .OrderByDescending(d => d);

            // add to list boxes
            foreach (var item in ulOrdered) { lbxUnlockTimes.Items.Add( item.ToShortTimeString() ); }
            foreach (var item in lOrdered ) { lbxLockTimes  .Items.Add( item.ToShortTimeString() ); }
        }



        private void lblDate_Click(object sender, EventArgs e)
        {
            // toggle
            splitContainer.Panel2Collapsed = !splitContainer.Panel2Collapsed;

            // TODO just for now
            if (splitContainer.Panel2Collapsed) lblDate.ForeColor = Color.Goldenrod;
            else                                lblDate.ForeColor = Color.Red;

            SetFormSizeBasedOnPanels();
        }

        private void SetFormSizeBasedOnPanels()
        {
            // if Panel2 is hidden, shrink form width
            // if Panel2 is showing, increase form width

            /*
            if (splitContainer.Panel2Collapsed) { splitContainer.Width = splitContainer.Panel1MinSize; }
            else                                { splitContainer.Width = splitContainer.Panel1MinSize + splitContainer.Panel2MinSize + 1; }     // the splitter has to be at least 1px
            */

            // The SplitterPanel's width cannot be set explicitly. Set the SplitterDistance on the SplitContainer instead.
            //splitContainer.Panel1.Width = splitContainer.Panel1MinSize;
            splitContainer.SplitterDistance = splitContainer.Panel1MinSize;


            // ok now set form resize mode to Grow/Shrink so see if that does it automatically
            // actualy, looks like splitContainer is not changing width
            // even when setting it to 175, it doesn't actually change!         ahhhhhhhh it's because it expands Panel 1!!!

            int goalSize;
            if (splitContainer.Panel2Collapsed) { goalSize = splitContainer.Panel1MinSize; }
            else                                { goalSize = splitContainer.Panel1MinSize + splitContainer.Panel2MinSize + 1; }


            Debug.WriteLine($"Panel 2 collapsed   : {splitContainer.Panel2Collapsed}");
            Debug.WriteLine($"Form width          : {this.Width}px");
            Debug.WriteLine($"SplitContainer width: {splitContainer.Width}px   - goal: {goalSize}px");
            Debug.WriteLine($"Panel 1 width        : {splitContainer.Panel1.Width}px");        // hmm
            Debug.WriteLine("---------------------------------------------------" + Environment.NewLine);
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
