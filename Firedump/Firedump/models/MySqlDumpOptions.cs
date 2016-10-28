

using System;

namespace Firedump.models
{
    /// <summary>
    /// better store all mysql options in object instance
    /// tha mporousame na xorisoume ta options se katigories
    /// 1.mysql credentials
    /// 2.dump optins(ama thaxei create schema kai tetia)
    /// 3.compress options(zip i sql)
    /// 4.output format?? xml,...?
    /// 
    /// ??diaxorismos katigorion se ipoklaseis??
    /// !!eukoloteri diaxeirisi ama exei ipoklaseis!
    /// </summary>
    public class MySqlDumpOptions
    {
        public MySqlDumpOptions() { }

        internal string getHost()
        {
            return "";
        }


    }
}