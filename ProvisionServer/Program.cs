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

            
            string template_name="orders_template";
            DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(template_name);
            scopeDesc.UserComment="Table template for Orders";

            // Definition for tables.
            DbSyncTableDescription orderDescription =
                SqlSyncDescriptionBuilder.GetDescriptionForTable("Orders", serverConn);

            // add the table description to the sync scope definition            
            scopeDesc.Tables.Add(orderDescription);

            // Create a provisioning object for "orders_template" that can be used to create a template
            // from which filtered synchronization scopes can be created. 
            SqlSyncScopeProvisioning serverTemplate = new SqlSyncScopeProvisioning(serverConn, scopeDesc, SqlSyncScopeProvisioningType.Template);
        
            // Specify the column in the Customer table to use for filtering data, 
            // and the filtering clause to use against the tracking table.
            // "[side]" is an alias for the tracking table.
            // The CustomerType column that defines the filter is set up as a parameter in this template.
            // An actual customer type will be specified when the synchronization scope is created.
            serverTemplate.Tables["Orders"].AddFilterColumn("ProductID");
            serverTemplate.Tables["Orders"].FilterClause = "[side].[ProductID] = @productid";
            SqlParameter param = new SqlParameter("@productid", SqlDbType.Int, 4);                
            serverTemplate.Tables["Orders"].FilterParameters.Add(param);

            // Create the "orders_template" template in the database.
            // This action creates tables and stored procedures in the database, so appropriate database permissions are needed.
            if (!serverTemplate.TemplateExists(template_name))
                serverTemplate.Apply();              

            //create a specific scope using Product ID as parameter
            foreach (DataRow row in productTable.Rows)
            {
                //with each row in Product Table, create a Scope  it with row["ID"]
                string productID = row["ID"].ToString();
                string scopeName = productID + "scope";

                SqlSyncScopeProvisioning serverProvScope1 = new SqlSyncScopeProvisioning(serverConn);                    
                serverProvScope1.PopulateFromTemplate(scopeName, "orders_template");
                serverProvScope1.Tables["Orders"].FilterParameters["@productid"].Value = row["ID"];
                if (!serverProvScope1.ScopeExists(scopeName)) 
                    serverProvScope1.Apply();
            }
             
        }

        static void Main(string[] args)
        {
            SqlConnection serverConn = new SqlConnection("Data Source=MOSS-SVR6;user id=sa;password=P@ssword123;Initial Catalog=SyncDB; ");            

            CreateProductScope(serverConn);
            CreateOrderFilterScope(serverConn);                    
        }        
    }
}
