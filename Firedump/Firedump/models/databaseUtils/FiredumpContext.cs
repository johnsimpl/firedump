using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//While it can be fine to re-use a DbContext across multiple business transactions, its lifetime should still be kept short. 
namespace Firedump.models.databaseutils
{
    public class FiredumpContext
    {

        public FiredumpContext()
        {
        }

        ~FiredumpContext()
        {
            //??
        }

        public List<mysql_servers> getAllMySqlServers()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.mysql_servers.ToList();
            }
        }

        public List<schedules> getSchedules()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedules.ToList();
            }
        }

        public List<schedule_save_locations> getScheduleSaveLocations()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedule_save_locations.ToList();
            }
        }

        public List<logs> getLogs()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.logs.ToList();
            }
        }

        public List<userinfo> getUserinfo()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.userinfo.ToList();
            }
        }

        public List<backup_locations> getBackupLocations()
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.backup_locations.ToList();
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


        public List<schedules> getSchedulesByServerId(int id)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedules.Where(b => b.server_id == id).ToList();
            }
        }

        public List<schedule_save_locations> getScheduleSaveLocationByScheduleId(int id)
        {
            using (firedumpdbEntities1 contextdb = new firedumpdbEntities1())
            {
                return contextdb.schedule_save_locations.Where(
                    s => s.schedule_id == id
                    ).ToList();
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
