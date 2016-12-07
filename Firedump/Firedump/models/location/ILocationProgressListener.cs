using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    interface ILocationProgressListener
    {
        void setProgress(int progress, int speed);
    }
}
