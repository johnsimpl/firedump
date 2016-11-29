using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    public interface ICallback
    {

        void onError(int error);
    }
}
