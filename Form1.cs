using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        private List<DateTime>                 LockTimes   = new List<DateTime>();
        private List<DateTime>                 UnlockTimes = new List<DateTime>();
        private Dictionary<DateTime, TimeSpan> Durations   = new Dictionary<DateTime, TimeSpan>();        // key is lock time

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
#endif
            }

            MoveFormPosition_FromPanelVisibility();

            // ////////////////////////////////////////////////////////////////

            // if we have a "Persist" file, read from there
            ParseTimesFromPersistFile();
            UpdateLockTimesListBoxes();

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

        #region Writing to/Reading from persist file

        private const string Persist_TypeUnlock = "Unlock";
        private const string Persist_TypeLock   = "Locked";

        private const string Persist_DateTimeFormat = "yyyy/MM/dd_HH:mm:ss.ff";

        public void AddTimeToPersistFile(string type, DateTime time)
        {
            var persistFile = ConfigHelper.GetValue("LockTimePersistFile");
            if (persistFile != null)
            {
                File.AppendAllText(
                    persistFile, 
                    $"{type}|{time.ToString(Persist_DateTimeFormat)}" + Environment.NewLine);
            }
        }

        public void ParseTimesFromPersistFile()
        {
            var persistFile = ConfigHelper.GetValue("LockTimePersistFile");
            if (persistFile != null && File.Exists(persistFile))
            {
                var addShortLocks = ConfigHelper.GetValueBool("AddShortLocks");     // will determine whether to ignore short ones or not
                var earliestDate  = DateTime.Today.AddDays(-7);                     // don't add dates to the list from more than a week ago


                // get all lines
                var allLines = File.ReadAllLines(persistFile);
                if (allLines.Any())
                {
                    foreach (var line in allLines.Where(l => l.Contains('|')))
                    {
                        // $"{type}|{time.ToString(Persist_DateTimeFormat)}"
                        var split = line.Split('|');

                        var type = split[0];
                        var date = split[1].ToDate(Persist_DateTimeFormat);

                        if (date.HasValue && date > earliestDate)
                        {
                            if      (type == Persist_TypeUnlock) { this.UnlockTimes.Add(date.Value); }
                            else if (type == Persist_TypeLock  ) { this.LockTimes  .Add(date.Value); }
                        }
                    }
                }


                // calculate durations
                // this.Durations.Add(mostRecentLockTime, now - mostRecentLockTime);

                var unlocksOrdered = this.UnlockTimes.OrderBy(d => d).ToList();
                var   locksOrdered = this.LockTimes  .OrderBy(d => d).ToList();

                foreach (var unlock in unlocksOrdered)
                {
                    var prevLock = locksOrdered.LastOrDefault(d => d < unlock);
                    if (prevLock != default)
                    {
                        var duration = (unlock - prevLock);

                        // if duration of time locked is > 1 minute, or we're adding short locks
                        if (addShortLocks || duration.TotalMinutes > 1)
                        {
                            this.Durations.Add(prevLock, duration);
                        }
                        else    // otherwise, remove the lock/unlock pair
                        {
                            this.UnlockTimes.Remove(unlock);
                            this.LockTimes  .Remove(prevLock);
                        }
                    }
                }

            }
        }

        #endregion


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

                    // add to persist file
                    AddTimeToPersistFile(Persist_TypeLock, now);

                    // add to box
                    UpdateLockTimesListBoxes();

                    break;


                // ////////////////////////////////////////////////
                // On unlock or logon
                // ////////////////////////////////////////////////

                case SessionSwitchReason.SessionUnlock:
                case SessionSwitchReason.SessionLogon :
                    var mostRecentLockTime = this.LockTimes.OrderByDescending(d => d).FirstOrDefault();

                    var addShortLocks = ConfigHelper.GetValueBool("AddShortLocks");
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
                            this.Durations  .Add(mostRecentLockTime, now - mostRecentLockTime);
                        }
                    }
                    else
                    {
                        // add to list
                        this.UnlockTimes.Add(now);

                        if (mostRecentLockTime != null)
                        {
                            this.Durations.Add(mostRecentLockTime, now - mostRecentLockTime);
                        }
                    }

                    // add to persist file even if it's a short lock
                    AddTimeToPersistFile(Persist_TypeUnlock, now);

                    // update listbox
                    UpdateLockTimesListBoxes(); 

                    break;
            }
        }


        private void UpdateLockTimesListBoxes()
        {
            // ////////////////////////////////////////////////////////////////
            // remove lock/unlock times that aren't from today
            // (to keep the list from growing and growing)
            // ////////////////////////////////////////////////////////////////

            var startOfDay = DateTime.Today;

            // remove old unlock times
            this.UnlockTimes.RemoveAll(d => d < startOfDay);

            // remove old lock times
            // leave the lastest end-of-day lock from the previous day worked
            var oldLockTimes = this.LockTimes.Where(d => d < startOfDay)
                .OrderByDescending(d => d).Skip(1)      // order with most recent first, then skip removing the last lock of the previous day
                .ToList();
            foreach (var oldLockTime in oldLockTimes)
            {
                this.LockTimes.Remove(oldLockTime);
            }

            // remove old durations
            var oldDurations = this.Durations.Where(kvp => kvp.Key < startOfDay).ToList();
            foreach (var kvp in oldDurations)
            {
                this.Durations.Remove(kvp.Key);
            }


            // ////////////////////////////////////////////////////////////////
            // this determines the format shown in the listboxes
            // ////////////////////////////////////////////////////////////////

            var shortLockDurationsShown = ConfigHelper.GetValueBool("AddShortLocks");

            var timeFormat = (shortLockDurationsShown)
                ? "HH:mm:ss"
                : "HH:mm";
            var timespanFormat = (shortLockDurationsShown)      // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-timespan-format-strings
                ? @"h\h\ mm\:ss"        // you have to escape spaces too I guess
                : @"h\h\ mm\m"  ;


            // ////////////////////////////////////////////////////////////////
            // clear current text in list boxes
            // ////////////////////////////////////////////////////////////////

            lbxUnlockTimes.Items.Clear();
            lbxLockTimes  .Items.Clear();
            lbxDuration   .Items.Clear();


            // ////////////////////////////////////////////////////////////////
            // add blank item to lock times at top
            // because it lines up that way (you can read across)
            // ////////////////////////////////////////////////////////////////

            lbxDuration.Items.Add((shortLockDurationsShown) ? "-- -- --" : "-- --");

            // if there isn't a last lock of previous day, add the dashes
            if (!this.LockTimes.Any(d => d < startOfDay))
            {
                lbxLockTimes.Items.Add((shortLockDurationsShown) ? "-- -- --" : "-- --");
            }


            // ////////////////////////////////////////////////////////////////
            // add to list boxes
            // ////////////////////////////////////////////////////////////////

            // order with earliest on top
            var ulOrdered = this.UnlockTimes.OrderBy(d => d);
            var lOrdered  = this.LockTimes  .OrderBy(d => d);

            // unlocks
            foreach (var item in ulOrdered)
            {
                lbxUnlockTimes.Items.Add( item.ToString(timeFormat) );
            }

            // locks
            foreach (var item in lOrdered)
            {
                if (item < startOfDay) { lbxLockTimes.Items.Add( item.ToString("HH:mm ddd").Substring(0, 8) ); }    // for last lock of prev day - just hour:minute, 2-letter day abbreviation
                else                   { lbxLockTimes.Items.Add( item.ToString(timeFormat) ); }
            }

            // durations
            foreach (var kvp in this.Durations)
            {
                lbxDuration.Items.Add( kvp.Value.ToString(timespanFormat) );
            }
        }



        // ////////////////////////////////////////////////

        // how to style with alt row color - from https://stackoverflow.com/a/2555062/

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var g = e.Graphics;

            var isAltRow = (e.Index % 2 == 1);
            if (isAltRow)
            {
                // draw the background color you want
                g.FillRectangle(
                    new SolidBrush(Color.FromArgb(64, 0,0,0)),      // 25% opacity black
                    e.Bounds);
            }

            // the text of item to display
            var itemText  = (sender as ListBox).Items[e.Index].ToString();

            // make the first item a different color
            var itemColor = e.ForeColor;
            if (e.Index == 0)
            {
                if      (sender == this.lbxUnlockTimes) { itemColor = Color.LawnGreen;   }      // first unlock time of the day green
                else if (sender == this.lbxLockTimes  ) { itemColor = Color.LightSalmon; }      // last lock from yesterday     orangish
            }

            // draw the text of the list item, not doing this will only show the background color
            g.DrawString(itemText, 
                e.Font, 
                new SolidBrush(itemColor), 
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

        // TODO would like to get it to extend out to the *left* of the time?

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
