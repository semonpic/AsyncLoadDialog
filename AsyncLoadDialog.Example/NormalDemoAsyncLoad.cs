using AsyncLoadBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLoadDialog.Example
{
    class NormalDemoAsyncLoad : AsyncLoad
    {
        public override void Worker()
        {
            Thread.Sleep(1000);
            UpdatePrecent(10);
            Thread.Sleep(1000);
            UpdatePrecent(20);
            Thread.Sleep(1000);
            UpdatePrecent(30);
            Thread.Sleep(1000);
            UpdatePrecent(40);
            Thread.Sleep(1000);
            UpdatePrecent(50);
            Thread.Sleep(1000);
            UpdatePrecent(60);
            Thread.Sleep(1000);
            UpdatePrecent(70);
            Thread.Sleep(1000);
            UpdatePrecent(80);
            Thread.Sleep(1000);
            UpdatePrecent(90);
            Thread.Sleep(1000);
            UpdatePrecent(100);
            Thread.Sleep(500);
            LoadCompelete("DemoAsyncLoad");//Return the object we load
        }
    }
}
