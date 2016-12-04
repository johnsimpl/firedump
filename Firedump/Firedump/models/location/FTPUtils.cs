using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace Firedump.models.location
{
    class FTPUtils
    {
        private SessionOptions sessionOptions;
        private FTPCredentialsConfig config;
        private IFTPListener listener;
        private Session session;
        private FTPUtils() { }
        /// <summary>
        /// Use this for listings not for transfer operations
        /// </summary>
        /// <param name="config"></param>
        public FTPUtils(FTPCredentialsConfig config)
        {
            this.config = config;
            setupSessionOptions();
        }
        /// <summary>
        /// This is the constructor to use for file transfer operations
        /// </summary>
        /// <param name="config"></param>
        /// <param name="listener"></param>
        public FTPUtils(FTPCredentialsConfig config, IFTPListener listener)
        {
            this.config = config;
            this.listener = listener;
            setupSessionOptions();
        }

        public void setupSessionOptions()
        {
            sessionOptions = new SessionOptions
            {
                HostName = config.host,
                UserName = config.username,
                Password = config.password,
                PortNumber = config.port,
            };
            if (config.useSFTP)
            {
                sessionOptions.Protocol = Protocol.Sftp;
                sessionOptions.SshHostKeyFingerprint = config.SshHostKeyFingerprint;
                if (config.usePrivateKey)
                {
                    sessionOptions.SshPrivateKeyPath = config.privateKeyPath;
                }
            }
            else
            {
                sessionOptions.Protocol = Protocol.Ftp;
            }
            if (config.usePrivateKey)
            {
                sessionOptions.SshPrivateKeyPath = config.privateKeyPath;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Empty string for success or the exception message</returns>
        public FTPConnectionResultSet testConnection()
        {
            FTPConnectionResultSet result = new FTPConnectionResultSet();
            try
            {
                session = new Session();
                result.sshHostKeyFingerprint = session.ScanFingerprint(sessionOptions);
                sessionOptions.SshHostKeyFingerprint = result.sshHostKeyFingerprint;
                session.Open(sessionOptions);
                result.wasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.errorMessage = ex.Message;
            }
            finally
            {
                session.Dispose();
            }
            return result;
        }

        private string[] splitPath(string path)
        {
            string[] splitpath = new string[2];
            char splitchar = '\\';
            if (path.Contains('/'))
            {
                splitchar = '/';
            }
            string[] temp = path.Split(splitchar);
            splitpath[1] = temp[temp.Length - 1];
            splitpath[0] = "";
            for(int i=0; i<temp.Length-1; i++)
            {
                splitpath[0] += temp[i] + splitchar;
            }
            return splitpath;
        }

        private string getExtension(string filename)
        {
            string[] temp = filename.Split('.');
            return "."+temp[temp.Length - 1];
        }

        /// <summary>
        /// To location path prepei na einai directory
        /// Location path tis morfis /home/user/filename
        /// </summary>
        public void sendFile()
        {
            try
            {
                session = new Session();

                session.FileTransferProgress += sessionFileTransferProgress;
                if(config.useSFTP && string.IsNullOrEmpty(sessionOptions.SshHostKeyFingerprint))
                    sessionOptions.SshHostKeyFingerprint = session.ScanFingerprint(sessionOptions);

                string[] locationinfo = splitPath(config.locationPath);
                string[] sourceinfo = splitPath(config.sourcePath);
                string ext = getExtension(sourceinfo[1]);

                session.Open(sessionOptions);

                //mporeis na peirakseis ta dikaiwmata tou arxeiou
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                transferResult = session.PutFiles(config.sourcePath,locationinfo[0], false, transferOptions);

                transferResult.Check(); //Prepei na kanei throw exception se periptwsi fail iparxei kai transferResult.isSuccess den to exw testarei

                session.MoveFile(locationinfo[0]+sourceinfo[1],locationinfo[0]+locationinfo[1]+ext);

                /* ama ithela na xeiristw results apo transfers polaplwn arxeiwn
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                }*/

                listener.onTransferComplete();
            }
            catch(Exception ex)
            {
                listener.onTransferError(ex.Message);
            }
            finally
            {
                session.Dispose();
            }
        }

        /// <summary>
        /// Sto config sourcePath einai tou server kai to locationPath prepei na einai directory
        /// </summary>
        public void getFile()
        {
            try
            {
                session = new Session();

                session.FileTransferProgress += sessionFileTransferProgress;
                if (config.useSFTP && string.IsNullOrEmpty(sessionOptions.SshHostKeyFingerprint))
                    sessionOptions.SshHostKeyFingerprint = session.ScanFingerprint(sessionOptions);

                session.Open(sessionOptions);

                session.GetFiles(config.sourcePath, config.locationPath).Check();

                listener.onTransferComplete();
            }
            catch (Exception ex)
            {
                listener.onTransferError(ex.Message);
            }
            finally
            {
                session.Dispose();
            }
        }

        private void sessionFileTransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            listener.onProgress(Convert.ToInt32(e.OverallProgress*100), e.CPS);
        }
    }
}
