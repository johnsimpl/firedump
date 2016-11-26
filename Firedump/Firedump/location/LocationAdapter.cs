using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.location
{
    class LocationAdapter
    {

        private ILocation location;

        public void setLocation(ILocation location)
        {
            this.location = location;
        }

        public void setFtpLocation(LocationFtp loc)
        {
            
        }


    }
}
