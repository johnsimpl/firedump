﻿using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.CSharp.RuntimeBinder;

namespace Firedump.models.configuration.dynamicconfig
{
    public class CredentialsConfig
    {
        //<!configuration fields section>
        /// <summary>
        /// mysql server ip or domain name
        /// </summary>
        public string host { set; get; }
        /// <summary>
        /// mysql port number
        /// </summary>
        public int port { set; get; } = 3306;
        /// <summary>
        /// user's username
        /// </summary>
        public string username { set; get; }
        /// <summary>
        /// user's password (leave null or empty to attemp a connection without password)
        /// </summary>
        public string password { set; get; }
        /// <summary>
        /// the database name to dump (leave null or empty to dump all databases in the server)
        /// This is disregarded if the databases array is not null.
        /// </summary>
        public string database { set; get; }
        /// <summary>
        /// Tables to be excluded from the dump seperated with commas (Table1,Table2).
        /// Leave it null to exclude no tables. This is disregarded if the databases
        /// array is not null or if both database and databases are null or empty.
        /// </summary>
        public string excludeTablesSingleDatabase { set; get; }
        /// <summary>
        /// string array with all the database names to dump (leave it null to disregard this field)
        /// </summary>
        public string[] databases { set; get; }
        /// <summary>
        /// each element in this array is a string of table names from a database seperated with commas.
        /// For example if database Foo contains tables Table1 Table2 and Table3 and 1,2 are excluded the
        /// table names must be placed in this format Table1,Table2 at the exact index of the database for the databases array.
        /// If there are more than one databases in the databases array fill all other indexes of this array with empty strings.
        /// This array must always have the same length as the databases array in order to be used. Leave it null to exclude
        /// no tables. If the length of databases and this array differs this option is disregarded and no tables are excluded.
        /// </summary>
        public string[] excludeTables { set; get; }
        //</configuration fields section>

        public CredentialsConfig() { }

       
    }
}
