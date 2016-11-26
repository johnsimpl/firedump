using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    abstract class Location
    {
        private string path { set; get; }
        public void setListener(ICallBack callback)
        {
            throw new NotImplementedException();
        }
    }
}
