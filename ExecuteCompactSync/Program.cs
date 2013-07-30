using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data.SqlServerCe;

namespace ExecuteCompactSync
{
    class Program
    {
        static void productSync(SqlConnection serverConn,SqlCeConnection clientConn)
        {
            // create the sync orhcestrator 
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

            // set local provider of orchestrator to a CE sync provider associated with the  
            // ProductsScope in the SyncCompactDB compact client database 
            syncOrchestrator.LocalProvider = new SqlCeSyncProvider("ProductsScope", clientConn);

            // set the remote provider of orchestrator to a server sync provider associated with 
            // the ProductsScope in the SyncDB server database 
            syncOrchestrator.RemoteProvider = new SqlSyncProvider("ProductsScope", serverConn);

            // set the direction of sync session to Upload and Download 
            syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
            // subscribe for errors that occur when applying changes to the client 
            //((SqlCeSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed); 
            ((SqlCeSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);
            // execute the synchronization process 
            SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

            // print statistics 
            Console.WriteLine("Start Time: " + syncStats.SyncStartTime);
            Console.WriteLine("Total Changes Uploaded: " + syncStats.UploadChangesTotal);
            Console.WriteLine("Total Changes Downloaded: " + syncStats.DownloadChangesTotal);
            Console.WriteLine("Complete Time: " + syncStats.SyncEndTime);
            Console.WriteLine(String.Empty); 
        }

        static void orderSync(SqlConnection serverConn, SqlCeConnection clientConn)
        {
            try
            {
                clientConn.Open();
                string intero = "Select * from Products";
                SqlCeCommand cmd = new SqlCeCommand(intero, clientConn);

                SqlCeDataReader row;

                row = cmd.ExecuteReader();

                while (row.Read())
                {
                    //Create scope for Orders
                    System.Console.WriteLine(row["ID"]);
                    string productID = row["ID"].ToString();
                    string scopeName = productID + "scope";


                    // create the sync orhcestrator 
                    SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

                    // set local provider of orchestrator to a CE sync provider associated with the  
                    // ProductsScope in the SyncCompactDB compact client database 
                    syncOrchestrator.LocalProvider = new SqlCeSyncProvider(scopeName, clientConn);

                    // set the remote provider of orchestrator to a server sync provider associated with 
                    // the ProductsScope in the SyncDB server database 
                    syncOrchestrator.RemoteProvider = new SqlSyncProvider(scopeName, serverConn);

                    // set the direction of sync session to Upload and Download 
                    syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;
                    // subscribe for errors that occur when applying changes to the client 
                    //((SqlCeSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed); 
                    ((SqlCeSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);
                    // execute the synchronization process 
                    SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();
                }
                row.Close();
                clientConn.Close();
            }

            catch (Exception e)
            {
                System.Console.Write(e.Message);
            }
        }

        static void Main(string[] args)
        {
            //SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='C:\Users\quan_nh\Documents\Visual Studio 2008\Projects\SyncApplication130702\ProvisionClient\SyncCompactDB.sdf'");
            SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='C:\Users\qnguyen37\Documents\SyncProj\ProvisionClient\SyncDB7.sdf'");

            // create a connection to the SyncDB server database
            SqlConnection serverConn = new SqlConnection("Data Source=MOSS-SVR6;user id=sa;password=P@ssword123;Initial Catalog=SyncDB");

            productSync(serverConn,clientConn);
            orderSync(serverConn, clientConn);
        } 
  
        static void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e) 
        { 
            // display conflict type 
            Console.WriteLine(e.Conflict.Type); 
  
            // display error message  
            Console.WriteLine(e.Error); 
        }             
    }
}
