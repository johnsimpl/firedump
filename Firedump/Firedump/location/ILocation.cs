using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    interface ILocation
    {
        void connect();

        void connect(object o);

        void getFile();

        void send();

        void setListener(ICallBack callback);
    }
}
