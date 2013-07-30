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
        static void CreateProductScope(SqlConnection serverConn, SqlCeConnection clientConn)
        {
            //// get the description of ProductsScope from the SyncDB server database
            DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("ProductsScope", serverConn);

            //// create CE provisioning object based on the ProductsScope
            SqlCeSyncScopeProvisioning clientProvision;
            clientProvision = new SqlCeSyncScopeProvisioning(clientConn, scopeDesc);

            //// starts the provisioning process
            if (!clientProvision.ScopeExists("ProductsScope"))
                clientProvision.Apply();
        }

        static void CreateOrderFilterScope(SqlConnection serverConn, SqlCeConnection clientConn)
        {
            string template_name = "orders_template";
            //Read from table Products using TableAdapter
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
                    
                    // Provision the existing database SyncSamplesDb_SqlPeer2 based on filtered scope
                    // information that is retrieved from the server.
                    DbSyncScopeDescription clientScopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(scopeName, serverConn);

                    SqlCeSyncScopeProvisioning clientProvision;
                    clientProvision = new SqlCeSyncScopeProvisioning(clientConn, clientScopeDesc);

                    //// starts the provisioning process
                    if (!clientProvision.ScopeExists(scopeName))
                        clientProvision.Apply();
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

            // create a connection to the SyncCompactDB database
            try
            {
                //SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='C:\Users\quan_nh\Documents\Visual Studio 2008\Projects\SyncApplication130702\ProvisionClient\SyncCompactDB.sdf'");
                SqlCeConnection clientConn = new SqlCeConnection(@"Data Source='C:\Users\qnguyen37\Documents\SyncProj\ProvisionClient\SyncDB7.sdf'");                
                
                // create a connection to the SyncDB server database
                SqlConnection serverConn = new SqlConnection("Data Source=MOSS-SVR6;user id=sa;password=P@ssword123;Initial Catalog=SyncDB");

                CreateProductScope(serverConn,clientConn);
                CreateOrderFilterScope(serverConn, clientConn);                 
            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
            }
        }
    }
}