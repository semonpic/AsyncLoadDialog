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

namespace AsyncLoadDialog.WPF.Example
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FailCase_Click(object sender, RoutedEventArgs e)
        {
            FailDemoAsyncLoad failDemoAsyncLoad = new FailDemoAsyncLoad();
            AsyncLoadForm asyncLoadForm = new AsyncLoadForm(failDemoAsyncLoad);
            bool? res = asyncLoadForm.ShowDialog();

            if (res.HasValue && res == true)
            {
                MessageBox.Show("Load Complete:Data is " + asyncLoadForm.ReturnObj.ToString());
            }
            else
            {
                MessageBox.Show("Load Fail");
            }

        }

        private void OkCase_Click(object sender, RoutedEventArgs e)
        {
            NormalDemoAsyncLoad normalDemoAsyncLoad = new NormalDemoAsyncLoad();
            AsyncLoadForm asyncLoadForm = new AsyncLoadForm(normalDemoAsyncLoad);
            bool? res = asyncLoadForm.ShowDialog();

            if (res.HasValue && res == true)
            {
                MessageBox.Show("Load Complete:Data is " + asyncLoadForm.ReturnObj.ToString());
            }
            else
            {
                MessageBox.Show("Load Fail");
            }

        }
    }
}
