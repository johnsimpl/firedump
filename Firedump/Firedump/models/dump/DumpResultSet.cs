using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.dump
{
    class DumpResultSet
    {
        /// <summary>
        /// wether the dump was successful or not
        /// </summary>
        public bool wasSuccessful { set; get; }
        /// <summary>
        /// absolute path of the temporal dump file
        /// </summary>
        public string fileAbsPath { set; get; }
        /// <summary>
        /// mysql error number in case of mysql error or -1 if dump was code aborted.
        /// For -1 use mysqlErrorMessage for the error message.
        /// </summary>
        public int mysqlErrorNumber { set; get; }
        /// <summary>
        /// mysql exception message
        /// </summary>
        public string mysqlErrorMessage { set; get; }
        /// <summary>
        /// the exception.ToString()
        /// </summary>
        public string mysqlExceptionToString { set; get; }
        /// <summary>
        /// standard error of mysqldump.exe (use in case of failure)
        /// </summary>
        public string mysqldumpexeStandardError { set; get; }

        public DumpResultSet() { }
    }
}
