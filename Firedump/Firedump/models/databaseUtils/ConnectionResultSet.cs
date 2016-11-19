using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.databaseUtils
{
    public class ConnectionResultSet
    {
        public bool wasSuccessful { set; get; }
        public int exceptionType { set; get; }
        public string errorMessage { set; get; }
        public string errorSource { set; get; }
        public int mysqlErrNum { set; get; }
        public ConnectionResultSet() { }
    }
}
