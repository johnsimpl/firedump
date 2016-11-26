using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    abstract class Location //ola public alliws den ta vlepoun alles klaseis oute kan autes pou klironomoun
    {
        public string path { set; get; }
        public void setListener(ICallBack callback)
        {
            throw new NotImplementedException();
        }
    }
}
