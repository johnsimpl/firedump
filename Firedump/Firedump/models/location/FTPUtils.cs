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
            setupLocationPath();
        }

        public void setupSessionOptions()
        {
            sessionOptions = new SessionOptions
            {
                HostName = config.hostname,
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
        }

        private void setupLocationPath()
        {
            //EDW NA MPEI TO EXTENSION STO LOCATION PATH
        }

        public void sendFile()
        {
            try
            {
                session = new Session();

                session.FileTransferProgress += sessionFileTransferProgress;
                session.Open(sessionOptions);

                //mporeis na peirakseis ta dikaiwmata tou arxeiou
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult;
                transferResult = session.PutFiles(config.sourcePath,config.locationPath, false, transferOptions);

                transferResult.Check(); //Prepei na kanei throw exception se periptwsi fail iparxei kai transferResult.isSuccess den to exw testarei

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
                session.Open(sessionOptions);

                session.GetFiles(config.sourcePath, config.locationPath).Check();

                listener.onTransferComplete();
            }
            catch (Exception ex)
            {
                listener.onTransferError(ex.Message);
            }
        }

        private void sessionFileTransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            //exei kialla gia to progress opws filename ama exeis polapla arxeia klp
            listener.onProgress(Convert.ToInt32(e.OverallProgress), e.CPS);
        }
    }
}
