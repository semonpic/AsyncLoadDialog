using AsyncLoadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLoadDialog.Example
{
    class FailDemoAsyncLoad : AsyncLoad
    {
        public override void Worker()
        {
            try
            {
                Thread.Sleep(1000);
                UpdatePrecent(10);
                Thread.Sleep(1000);
                UpdatePrecent(20);
                Thread.Sleep(1000);
                UpdatePrecent(30);
                Thread.Sleep(1000);
                UpdatePrecent(40);
                throw new Exception("LoadFail");
            }
            catch (Exception exp)
            {
                LoadFail(exp.Message);
            }

        }
    }
}
