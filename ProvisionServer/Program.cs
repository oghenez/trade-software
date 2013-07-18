using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System.Data.SqlClient;
using System.Data;

namespace ProvisionServer
{
    class Program
    {
        static ProductDataSetTableAdapters.ProductsTableAdapter productTableAdapter = new ProvisionServer.ProductDataSetTableAdapters.ProductsTableAdapter();        
        static private void CreateProductScope(SqlConnection serverConn)
        {
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
            if (!serverProvision.ScopeExists("ProductsScope"))
                serverProvision.Apply();
        }

        static private void CreateOrderFilterScope(SqlConnection serverConn)
        {            
            ProductDataSet.ProductsDataTable productTable=productTableAdapter.GetData();
            
            foreach (DataRow row in productTable.Rows)
            {
                //with each row in Product Table, create a Scope  it with row["ID"]
                string productID = row["ID"].ToString();
                string scopeName =  productID + "scope";
                DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(scopeName);

                // Definition for tables.
                DbSyncTableDescription orderDescription =
                    SqlSyncDescriptionBuilder.GetDescriptionForTable("Orders", serverConn);

                // add the table description to the sync scope definition            
                scopeDesc.Tables.Add(orderDescription);


                // Create a provisioning object for "customertype_template" that can be used to create a template
                // from which filtered synchronization scopes can be created. We specify that
                // all synchronization-related objects should be created in a 
                // database schema named "Sync". If you specify a schema, it must already exist
                // in the database.
                SqlSyncScopeProvisioning serverTemplate = new SqlSyncScopeProvisioning(serverConn, scopeDesc, SqlSyncScopeProvisioningType.Template);
                //serverTemplate.ObjectSchema = "Sync";
                // skipping the creation of table since table already exists on server
                serverTemplate.SetCreateTableDefault(DbSyncCreationOption.Skip);

                // Specify the column in the Customer table to use for filtering data, 
                // and the filtering clause to use against the tracking table.
                // "[side]" is an alias for the tracking table.
                // The CustomerType column that defines the filter is set up as a parameter in this template.
                // An actual customer type will be specified when the synchronization scope is created.
                serverTemplate.Tables["Orders"].AddFilterColumn("ProductID");
                serverTemplate.Tables["Orders"].FilterClause = "[side].[ProductID] = @productid";
                SqlParameter param = new SqlParameter("@productid", SqlDbType.Int, 4);
                serverTemplate.Tables["Orders"].FilterParameters.Add(param);

                // Create the "customertype_template" template in the database.
                // This action creates tables and stored procedures in the database, so appropriate database permissions are needed.
                serverTemplate.Apply();


            }
             
        }

        static void Main(string[] args)
        {
            SqlConnection serverConn = new SqlConnection("Data Source=MOSS-SVR6;user id=sa;password=P@ssword123;Initial Catalog=SyncDB; ");            

            CreateProductScope(serverConn);
            CreateOrderFilterScope(serverConn);        
            //serverConn.Open();
            //DataTable schema = serverConn.GetSchema("Tables");            
            //foreach (DataRow row in schema.Rows)
            //{
            //    string tablename = row[2].ToString();                
            //    //check if Scope exists or not
            //    string scopename = "Scope" + tablename;
            //    DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(scopename);

            //    //// get the description of the Products table from SyncDB dtabase
            //    DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(tablename, serverConn);                

            //    // add the table description to the sync scope definition
                
            //        scopeDesc.Tables.Add(tableDesc);


            //    //// create a server scope provisioning object based on the ProductScope
            //    SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

            //    //// skipping the creation of table since table already exists on server
            //    serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

            //    // start the provisioning process
            //    if (!serverProvision.ScopeExists(scopename))
            //        serverProvision.Apply();
            //}

            //DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription("ProductsScope");

  
            //// get the description of the Products table from SyncDB dtabase
            //DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable("Products", serverConn);

            //DbSyncTableDescription tableOrderDes = SqlSyncDescriptionBuilder.GetDescriptionForTable("Orders", serverConn);

            //// add the table description to the sync scope definition
            //if (!scopeDesc.Tables.Contains(tableDesc))
            //    scopeDesc.Tables.Add(tableDesc);
            //if (!scopeDesc.Tables.Contains(tableOrderDes)) 
            //    scopeDesc.Tables.Add(tableOrderDes);
  

            //// create a server scope provisioning object based on the ProductScope
            //SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);
  
            //// skipping the creation of table since table already exists on server
            //serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);
  
            //// start the provisioning process
            //serverProvision.Apply();
        }        
    }
}
