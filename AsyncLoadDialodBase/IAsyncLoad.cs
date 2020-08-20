using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLoadDialodBase
{


    public delegate void UpdatePrecentHandle(double precent);
    public delegate void LoadFaitHandle(string msg);
    public delegate void LoadCompeleteHandle(object returnobj);

    interface IAsyncLoad
    {
    }
}
