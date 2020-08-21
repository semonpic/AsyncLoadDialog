# AsyncLoadDialog
A tool help to  provide a async loading dialog when Perform time-consuming operations，support WinForm and WPF

When we perform a time-consuming operation,we need Pop up a  friendly Mode dialog which show the Progress of work。
How to simplify this work，AsyncLoadDialog Will Help。
With The Help Of AsyncLoadDialog,we only need Foucus On our main job。
1 Creat a Class Like this,
 class NormalDemoAsyncLoad : AsyncLoad
    {
        public override void Worker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            try
            {
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(10, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(30, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(50, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(70, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                //If User Cancel
                if (backgroundWorker.CancellationPending)
                {
                    backgroundWorker.ReportProgress(80, new ProcessResult() { ProcessState = eProcessState.Cancel });
                    return;
                }
                backgroundWorker.ReportProgress(90, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(100, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(500);
                //Work Compelete,Return By Set Content And ProcessState eProcessState.Compelete
                backgroundWorker.ReportProgress(100, new ProcessResult() { ProcessState = eProcessState.Compelete, Content = "Loaded Data" });
            }
            catch
            {
                backgroundWorker.ReportProgress(100, new ProcessResult() { ProcessState = eProcessState.Fail, Content = "Error Msg" });
            }
        }
    }

