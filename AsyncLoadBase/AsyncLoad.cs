using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLoadBase
{
   public abstract class AsyncLoad:IAsyncLoad
    {
        public UpdatePrecentHandle updatePrecentHandle;
        public LoadFaitHandle loadFaitHandle;

        public LoadCompeleteHandle loadCompeleteHandle;
        public abstract void Worker();

        protected void UpdatePrecent(double data)
        {
            updatePrecentHandle?.Invoke(data);
        }

        protected void LoadFail(string msg)
        {
            loadFaitHandle?.Invoke(msg);
        }

        protected void LoadCompelete(object obj)
        {
            loadCompeleteHandle?.Invoke(obj);
        }
    }
}
