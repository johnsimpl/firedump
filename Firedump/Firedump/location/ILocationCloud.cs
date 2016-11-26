using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    interface ILocationCloud : ILocation
    {
        void setExtraCredentials();

        void doExtraStuff();
    }
}
