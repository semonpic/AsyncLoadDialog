using AsyncLoadBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncLoadDialog
{
    public partial class AsyncLoadForm : Form
    {
        public Object ReturnObj { get; set; }

        public double PrecentValue { get; set; } = 0.0;

        private AsyncLoad asyncLoadBase = null;

        private BackgroundWorker bw = new BackgroundWorker();

        public AsyncLoadForm()
        {
            InitializeComponent();
        }
        public AsyncLoadForm(AsyncLoad asyncLoadBase)
        {
            InitializeComponent();
            this.asyncLoadBase = asyncLoadBase;
        }
       
        private void AsynLoadForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//设置无标题栏
            if (asyncLoadBase != null)
            {
                bw.WorkerReportsProgress = true;
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(asyncLoadBase.Worker);
                bw.ProgressChanged += Bw_ProgressChanged;
                bw.RunWorkerAsync();
            }
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int precent = e.ProgressPercentage;
            this.labPrecent.Text = precent.ToString("f1") + "%";
            this.processBar.Value = precent;
            ProcessResult processResult = e.UserState as ProcessResult;
            if (processResult != null)
            {
                if (processResult.ProcessState == eProcessState.Cancel)
                {
                    ReturnObj = null;
                    this.DialogResult = DialogResult.Cancel;
                }
                else if (processResult.ProcessState == eProcessState.Fail)
                {
                    ReturnObj = null;
                    this.DialogResult = DialogResult.No;
                }
                else if (processResult.ProcessState == eProcessState.Compelete)
                {
                    ReturnObj = processResult.Content;
                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        private void AsyncLoadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (asyncLoadBase != null)
            {
                bw.DoWork -= new DoWorkEventHandler(asyncLoadBase.Worker);
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
                ReturnObj = null;
                this.DialogResult = DialogResult.Cancel;
            }

        }
    }
}
