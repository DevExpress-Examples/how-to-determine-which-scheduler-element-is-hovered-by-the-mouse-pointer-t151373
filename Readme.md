<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml.cs](./CS/Scheduler_HitInfo/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/Scheduler_HitInfo/MainWindow.xaml.vb))
<!-- default file list end -->
# How to determine which scheduler element is hovered by the mouse pointer.


<p>This example demonstrates how to obtain the hit information for the scheduler element over which the mouse pointer is hovering.</p>
<p>To accomplish this, handle the <strong>SchedulerControl.MouseMove</strong> event and use the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulerSchedulerViewBase_CalcHitInfotopic">SchedulerViewBase.CalcHitInfo</a> method to get the required information.</p>

<br/>


