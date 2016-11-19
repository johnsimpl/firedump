using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.utils
{
    public class SqlUtils
    {


        /// <summary>
        /// add safe limit to query results
        /// max row results is 500
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string limitQuery(string query)
        {
            if(!query.ToUpper().StartsWith("SHOW"))
            {
                if (query.ToUpper().Contains("LIMIT"))
                {
                    return query;
                }
                else
                {
                    return query + " LIMIT 500";
                }
            }

            return query;
        }





        


    }
}
