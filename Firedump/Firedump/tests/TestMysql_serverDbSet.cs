using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.tests
{
    public class TestMysql_serverDbSet : TestContext.TestDbSet<mysql_servers>
    {
        public override mysql_servers Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(b => b.id == id);
        }
    }


}

