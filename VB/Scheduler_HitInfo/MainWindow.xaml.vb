Imports DevExpress.Xpf.Scheduler
Imports DevExpress.XtraScheduler.Drawing
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Scheduler_HitInfo
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
        #Region "#hittest"
        Private Sub SchedulerControl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            ' Obtain hit information under the test point.
            Dim hitInfo As SchedulerControlHitInfo = schedulerControl1.ActiveView.CalcHitInfo(e)
            Dim builder As New StringBuilder()

            ' Check whether the scheduler element is located at the test point.
            Select Case hitInfo.HitTest
                Case SchedulerHitTest.AllDayArea
                    builder.AppendLine("All-Day Area")
                Case SchedulerHitTest.AppointmentContent
                    builder.AppendLine("Appointment")
                    Dim appView As IAppointmentView = TryCast(hitInfo.ViewInfo, IAppointmentView)
                    If appView IsNot Nothing Then
                        builder.AppendLine("Subject: " & appView.Appointment.Subject)
                        builder.AppendLine("Start: " & appView.Appointment.Start.ToString())
                        builder.AppendLine("End: " & appView.Appointment.End.ToString())
                    End If
                Case SchedulerHitTest.Cell
                    builder.AppendLine("Time Cell")
            End Select

            If builder.Length > 0 Then
                builder.AppendLine("Interval: " & hitInfo.ViewInfo.Interval.ToString())
                builder.AppendLine("Is Selected? " & hitInfo.ViewInfo.Selected.ToString())
                lbl1.Content = String.Format("Hit test results:" & ControlChars.Lf & builder.ToString())
            Else
                lbl1.Content = "Move the mouse pointer over the scheduler" & ControlChars.Lf & " to get information on the element which is hovered over."
            End If
        End Sub
        #End Region ' #hittest

        Private Sub schedulerControl1_MouseLeave(ByVal sender As Object, ByVal e As MouseEventArgs)
            lbl1.Content = "Move the mouse pointer over the scheduler" & ControlChars.Lf & " to get information on the element which is hovered over."
        End Sub

    End Class
End Namespace
