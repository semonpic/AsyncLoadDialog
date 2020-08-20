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
        public AsyncLoadForm()
        {
            InitializeComponent();
        }
        public AsyncLoadForm(AsyncLoad asyncLoadBase)
        {
            InitializeComponent();
            this.asyncLoadBase = asyncLoadBase;
        }
        void UpdatePrecent(double data)
        {
            PrecentValue = data;
            try
            {
                ChangeProcessbarValue(this.processBar, (int)data);
                double precent = data;
                string str = precent.ToString("f1") + "%";
                ChangeLabelTxt(this.labPrecent, str);
                //this.Dispatcher.Invoke(new Action(() => { this.processBar.Value = PrecentValue; }));
            }
            catch
            { }
        }

        void WorkFail(string errormsg)
        {


            try
            {
                MessageBox.Show(errormsg);
                ReturnObj = null;
                ChangeFormState(this, DialogResult.Cancel);
            }
            catch
            { }
        }
        void WorkCompelete(object ojb)
        {
            try
            {
                ReturnObj = ojb;
                ChangeFormState(this, DialogResult.OK);
            }
            catch
            { }


        }
        private void AsynLoadForm_Load(object sender, EventArgs e)
        {
            this.CancelButton = (IButtonControl)btnCancel;
            this.FormBorderStyle = FormBorderStyle.None;//设置无标题栏
            if (asyncLoadBase != null)
            {
                asyncLoadBase.loadCompeleteHandle += new LoadCompeleteHandle(WorkCompelete);
                asyncLoadBase.loadFaitHandle += new LoadFaitHandle(WorkFail);
                asyncLoadBase.updatePrecentHandle += new UpdatePrecentHandle(UpdatePrecent);
                Thread thread = new Thread(new ThreadStart(asyncLoadBase.Worker));
                thread.Name = "AsyncLoadThread";
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void AsyncLoadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (asyncLoadBase != null)
            {
                asyncLoadBase.loadCompeleteHandle -= new LoadCompeleteHandle(WorkCompelete);
                asyncLoadBase.loadFaitHandle -= new LoadFaitHandle(WorkFail);
                asyncLoadBase.updatePrecentHandle -= new UpdatePrecentHandle(UpdatePrecent);
            }
        }

        public void ChangeLabelTxt(Label Lb, string Str)
        {

            Action<Label, string> DoAction = delegate (Label lb, string str)
            {
                if (lb.InvokeRequired)
                {
                    lb.Text = str;
                }
                else
                {
                    lb.Text = str;
                }

            };

            Lb.Invoke(DoAction, Lb, Str);

        }
        public void ChangeProcessbarValue(ProgressBar Pb, int va)
        {

            Action<ProgressBar, int> DoAction = delegate (ProgressBar lb, int value)
            {
                if (lb.InvokeRequired)
                {
                    lb.Value = value;
                }
                else
                {
                    lb.Value = value;
                }

            };
            Pb.Invoke(DoAction, Pb, va);

        }

        public void ChangeFormState(AsyncLoadForm Pb, DialogResult va)
        {

            Action<AsyncLoadForm, DialogResult> DoAction = delegate (AsyncLoadForm lb, DialogResult value)
            {
                if (lb.InvokeRequired)
                {
                    lb.DialogResult = value;
                }
                else
                {
                    lb.DialogResult = value;
                }

            };
            Pb.Invoke(DoAction, Pb, va);

        }

    }
}
