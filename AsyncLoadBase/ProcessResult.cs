using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLoadBase
{
   public class ProcessResult
    {
        public eProcessState ProcessState { get; set; }
        public string ErrorMsg { get; set; } = string.Empty;
        public object Content = null;


    }
}
