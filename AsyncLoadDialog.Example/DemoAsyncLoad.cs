﻿using AsyncLoadBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLoadDialog.Example
{
    class DemoAsyncLoad : AsyncLoad
    {
        public override void Worker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;

            try
            {

                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(10, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(20, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(30, new ProcessResult() { ProcessState = eProcessState.Working });
                Thread.Sleep(1000);
                backgroundWorker.ReportProgress(40, new ProcessResult() { ProcessState = eProcessState.Working });
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
}
