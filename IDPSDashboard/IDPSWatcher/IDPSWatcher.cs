using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using IDPSDashboard.Model;
using IDPSDashboard.Business;
using IDPSWatcher.libIDPSWatcher;

namespace IDPSWatcher
{
    public partial class IDPSWatcher : Form
    {
        private System.Timers.Timer tmrChecks = new System.Timers.Timer();

        public IDPSWatcher()
        {
            InitializeComponent();
        }

        private void IDPSWatcher_Load(object sender, EventArgs e)
        {
            tmrChecks.Interval = Properties.Settings.Default.intervalChecks;
            tmrChecks.Elapsed += tmrChecks_Elapsed;
            tmrChecks.Start();
            tmrChecks_Elapsed(null, null);

            notifyIcon1.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        void tmrChecks_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
           
            DataTable dttResult = new DataTable();
            libIDPSWatcherImpl libIDPS = new libIDPSWatcherImpl();
            eventsdetectionBus oEventsDetection = new eventsdetectionBus();
            tasksBus oTask = new tasksBus();
            int newEventDetectionId;
            int counter;

            dttResult = libIDPS.getIDPSData();

            if (dttResult.Rows.Count > 0)
            {
                counter = 0;

                foreach (DataRow row in dttResult.Rows)
                {
                    DateTime dateTime = new DateTime();

                    if (String.IsNullOrEmpty(row[3].ToString()))
                        dateTime = DateTime.Now;
                    else
                        dateTime = DateTime.Parse(row[3].ToString());
                    
                    //DateTime.ParseExact(row[3].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    newEventDetectionId = 0;
                    eventsdetection newEventDetection = new eventsdetection();
                    newEventDetection.IdsId = Convert.ToInt32(row[0].ToString());
                    newEventDetection.EventsAlarmId = Convert.ToInt32(row[1].ToString());
                    newEventDetection.IDPSEventId = Convert.ToInt32(row[2].ToString());
                    newEventDetection.DateTime = dateTime;
                    newEventDetection.EventStatus = 1;
                    newEventDetectionId = oEventsDetection.eventsdetectionAdd(newEventDetection);

                    if (newEventDetectionId > 0)
                    {
                        tasks newTask = new tasks();
                        newTask.TaskStatudId = 1;
                        newTask.DateTime = dateTime;
                        newTask.UserId = 0;
                        if (row[4].ToString().Length > 49)
                            newTask.TaskTittle = row[4].ToString().Substring(0, 49);
                        else
                            newTask.TaskTittle = row[4].ToString();
                        newTask.EventsDetectionId = newEventDetectionId;

                        if (oTask.tasksAdd(newTask) > 0)
                        {
                            counter++;
                            lblCount.Text = counter.ToString();
                        }
                    }
                }

                lblTimeStamp.Text = DateTime.Now.ToString();
            }        
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
