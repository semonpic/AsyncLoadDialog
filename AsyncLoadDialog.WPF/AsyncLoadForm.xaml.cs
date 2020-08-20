
using AsyncLoadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncLoadDialog.WPF
{
    /// <summary>
    /// AsyncLoadForm.xaml 的交互逻辑
    /// </summary>
    public partial class AsyncLoadForm : Window
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

                this.Dispatcher.Invoke(new Action(() => { this.processBar.Value = PrecentValue; }));
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
                this.Dispatcher.Invoke(new Action(() => { DialogResult = false; }));
            }
            catch
            { }
        }
        void WorkCompelete(object ojb)
        {
            try
            {
                ReturnObj = ojb;
                this.Dispatcher.Invoke(new Action(() => { DialogResult = true; }));
            }
            catch
            { }


        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void Window_Closed(object sender, EventArgs e)
        {
            if (asyncLoadBase != null)
            {
                asyncLoadBase.loadCompeleteHandle -= new LoadCompeleteHandle(WorkCompelete);
                asyncLoadBase.loadFaitHandle -= new LoadFaitHandle(WorkFail);
                asyncLoadBase.updatePrecentHandle -= new UpdatePrecentHandle(UpdatePrecent);
            }
        }
    }
}
