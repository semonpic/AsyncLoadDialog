using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncLoadDialog.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DemoAsyncLoad normalDemoAsyncLoad = new DemoAsyncLoad();
            AsyncLoadForm asyncLoadForm = new AsyncLoadForm(normalDemoAsyncLoad);
            asyncLoadForm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult res = asyncLoadForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                MessageBox.Show("Load Complete");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FailDemoAsyncLoad failDemoAsyncLoad = new FailDemoAsyncLoad();
            AsyncLoadForm asyncLoadForm = new AsyncLoadForm(failDemoAsyncLoad);
            asyncLoadForm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult res = asyncLoadForm.ShowDialog();

            if (res == DialogResult.OK)
            {
                object loadedObj = asyncLoadForm.ReturnObj;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
