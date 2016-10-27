using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump
{
    public class FiredumpContext
    {

        public FiredumpContext()
        {
        }

        ~FiredumpContext()
        {
            
        }

        public List<mysql_servers> getAllMySqlServers()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.mysql_servers.ToList();
            }
        }
        
        //return the new id
        public int saveMysqlServer(mysql_servers server)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                contextdb.mysql_servers.Add(server);
                contextdb.SaveChanges();
                return (int)server.id;
            }
        }

        public mysql_servers getMysqlServerById(int id)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                mysql_servers server = contextdb.mysql_servers.Find(id);
                return server;
            }
        }


        public void deleteMysqlServer(mysql_servers server)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                contextdb.mysql_servers.Remove(server);
                contextdb.SaveChanges();
            }
        }

    }
}
