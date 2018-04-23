using DevExpress.Xpf.Scheduler;
using DevExpress.XtraScheduler.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scheduler_HitInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        #region #hittest
        private void SchedulerControl_MouseMove(object sender, MouseEventArgs e)
        {
            // Obtain hit information under the test point.
            SchedulerControlHitInfo hitInfo = schedulerControl1.ActiveView.CalcHitInfo(e);
            StringBuilder builder = new StringBuilder();

            // Check whether the scheduler element is located at the test point.
            switch (hitInfo.HitTest)
            {
                case SchedulerHitTest.AllDayArea:
                    builder.AppendLine("All-Day Area");
                    break;
                case SchedulerHitTest.AppointmentContent:
                    builder.AppendLine("Appointment");
                    IAppointmentView appView = hitInfo.ViewInfo as IAppointmentView;
                    if (appView != null)
                    {
                        builder.AppendLine("Subject: " + appView.Appointment.Subject);
                        builder.AppendLine("Start: " + appView.Appointment.Start.ToString());
                        builder.AppendLine("End: " + appView.Appointment.End.ToString());
                    }
                    break;
                case SchedulerHitTest.Cell:
                    builder.AppendLine("Time Cell");
                    break;
            }

            if (builder.Length > 0)
            {
                builder.AppendLine("Interval: " + hitInfo.ViewInfo.Interval.ToString());
                builder.AppendLine("Is Selected? " + hitInfo.ViewInfo.Selected.ToString());
                lbl1.Content = string.Format("Hit test results:\n" + builder.ToString());
            }
            else
                lbl1.Content = "Move the mouse pointer over the scheduler\n to get information on the element which is hovered over.";
        }
        #endregion #hittest

        private void schedulerControl1_MouseLeave(object sender, MouseEventArgs e)
        {
            lbl1.Content = "Move the mouse pointer over the scheduler\n to get information on the element which is hovered over.";
        }

    }
}
