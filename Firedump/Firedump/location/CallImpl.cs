using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    public delegate void OnError(int error);
    class CallImpl 
    {
        public void Start(OnError error)
        {
            error(10);
        }
    }
}
