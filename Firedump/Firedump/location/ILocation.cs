using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    interface ILocation
    {
        void send();

        void setFile();

        void setRemote();

        void setCredentials(object o);
    }
}
