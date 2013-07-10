using System.Data.SqlClient;
using System.Data.SqlServerCe;

using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data.SqlServerCe;
using System;

namespace ProvisionClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a connection to the SyncCompactDB database
            try
            {
                //SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='C:\Users\quan_nh\Documents\Visual Studio 2008\Projects\SyncApplication130702\ProvisionClient\SyncCompactDB.sdf'");
                SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='C:\Users\qnguyen37\Documents\SyncProj\ProvisionClient\SyncDB7.sdf'");                
                
                // create a connection to the SyncDB server database
                SqlConnection serverConn = new SqlConnection("Data Source=MOSS-SVR6;user id=sa;password=P@ssword123;Initial Catalog=SyncDB");

                //// get the description of ProductsScope from the SyncDB server database
                DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("ProductsScope", serverConn);

                //// create CE provisioning object based on the ProductsScope
                SqlCeSyncScopeProvisioning clientProvision;
                clientProvision = new SqlCeSyncScopeProvisioning(clientConn, scopeDesc);

                //// starts the provisioning process
                clientProvision.Apply();
            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
            }
        }
    }
}