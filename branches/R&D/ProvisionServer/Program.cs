using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System.Data.SqlClient;

namespace ProvisionServer
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection serverConn = new SqlConnection("Data Source=MOSS-SVR6;user id=sa;password=P@ssword123;Initial Catalog=SyncDB; ");
            //serverConn.p
  
            // define a new scope named ProductsScope
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("ProductsScope");
  
            // get the description of the Products table from SyncDB dtabase
            DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable("Products", serverConn);
  
            // add the table description to the sync scope definition
            scopeDesc.Tables.Add(tableDesc);
  
            // create a server scope provisioning object based on the ProductScope
            SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);
  
            // skipping the creation of table since table already exists on server
            serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);
  
            // start the provisioning process
            serverProvision.Apply();
        }        
    }
}
