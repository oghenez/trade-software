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

                    // Create a synchronization scope for retail customers.
                    // This action adds rows to synchronization tables but does not create new tables or stored procedures, reducing
                    // the permissions needed on the server.
                    SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn);
                    //serverProvRetail.ObjectSchema = "Sync";
                    serverProvision.PopulateFromTemplate(scopeName, scopeName);
                    serverProvision.Tables["Orders"].FilterParameters["@productid"].Value = row["ID"];
                    //serverProvision.UserDescription = "Customer data includes only retail customers.";
                    serverProvision.Apply();

                    // Provision the existing database SyncSamplesDb_SqlPeer2 based on filtered scope
                    // information that is retrieved from the server.
                    DbSyncScopeDescription clientSqlDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope("RetailCustomers", null, "Sync", serverConn);
                    SqlSyncScopeProvisioning clientSqlConfig = new SqlSyncScopeProvisioning(clientSqlConn, clientSqlDesc);
                    clientSqlConfig.ObjectSchema = "Sync";
                    clientSqlConfig.Apply();

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