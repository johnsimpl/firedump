using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    public class Test
    {

        public void meth(int i)
        {
            CallImpl c = new CallImpl();
            OnError error = onError;
            c.Start(error);
        }

        public void onError(int i)
        {
            Console.WriteLine(i);
        }
    }
}
