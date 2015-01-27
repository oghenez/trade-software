// ---------------------------------------------------------
// Dung Vu's Export class
// Copyright (C) 2007 Dung Vu. All rights reserved.
// ---------------------------------------------------------

# region Includes...

using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Collections; 

# endregion // Includes...

namespace common
{
	public class Export
	{		
		public enum ExportFormat : int {None=0,CSV = 1, Excel = 2,XML=3 }; // Export format enumeration			
        
        private static string ReplaceSpecialSQLChars(string str)
        {
            str = str.Replace('\'', ' ');
            return str;
        }
        private static OleDbConnection OpenConnection(string excelFile)
        {
            OleDbConnection oleDbConn = new OleDbConnection();
            oleDbConn.ConnectionString =
                "Data Source=" + excelFile + ";Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;";
            try
            {
                oleDbConn.Open();
                return oleDbConn;
            }
            catch { }
            return null;
        }

        private int[] ColumnId(DataTable frTable, string[] columnName)
        {
            if (columnName != null) return null;
            int colId, colCount=0;
            int[] columnList = new int[columnName.Length];
            for (int idx = 0; idx < columnName.Length; idx++)
            {
                colId =  frTable.Columns.IndexOf(columnName[idx]);
                if (colId < 0) continue;
                columnList[colCount++] = colId;
            }

            int[] retColumnList = new int[colCount];
            for (int idx = 0; idx < colCount; idx++) retColumnList[idx] = columnList[idx];
            return retColumnList;
        }
        private string[] ColumnName(DataTable frTable,int[] columnList)
        {
            if (columnList != null) return null;
            string[] columName = new string[columnList.Length];
            for (int idx = 0; idx < columnList.Length;idx++)
            {
                columName[idx] = frTable.Columns[columnList[idx]].ColumnName;  
            }
            return columName;
        }


        private static bool CreateExcelFile(string excelFile, string sheetName, DataTable frTable,
                                           int[] columnList, string[] headerList)
        {
            string SQLCmd = "";
            OleDbConnection oleDbConn = OpenConnection(excelFile);
            if (oleDbConn == null) return false;
            try
            {
                if (columnList == null)
                {
                    columnList = new int[frTable.Columns.Count]; 
                    for (int idx = 0; idx < frTable.Columns.Count; idx++) columnList[idx] = idx; 
                }
                if (headerList == null)
                {
                    headerList = new string[frTable.Columns.Count]; 
                    for (int idx = 0; idx < frTable.Columns.Count; idx++) headerList[idx] = frTable.Columns[idx].ColumnName; 
                }
                int colId;
                for (int idx = 0; idx < columnList.Length; idx++)
                {
                    colId = columnList[idx];
                    SQLCmd += (SQLCmd == "" ? "" : ",") + "[" + headerList[idx] + "]";
                    switch (frTable.Columns[colId].DataType.ToString().Trim())
                    {
                        case "System.Float":
                        case "System.Double":
                        case "System.Decimal":
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                            SQLCmd += " double";
                            break;
                        case "System.DateTime":
                            SQLCmd += " date ";
                            break;
                        case "System.Boolean":
                            SQLCmd += " bit";
                            break;
                        default:
                            SQLCmd += " ntext";
                            break;
                    }
                }
                SQLCmd = "CREATE TABLE [" + sheetName + "] (" + SQLCmd + ");";
                OleDbCommand oleDbComm = new OleDbCommand(SQLCmd, oleDbConn);
                oleDbComm.ExecuteNonQuery();
                oleDbConn.Close();
                return true;
            }
            catch (Exception er)
            {
                common.errorHandler.lastErrorMessage = er.Message.ToString();
            }
            finally
            {
                if (oleDbConn != null && oleDbConn.State == ConnectionState.Open) oleDbConn.Close();
            }
            return false;
        }

        public static bool ExportToExcel(DataTable frTable, string excelFile, string sheetName,
                                  int[] columnList, string[] headerList)
        {
            OleDbConnection oleDbConn = null;
            if (columnList == null)
            {
                columnList = new int[frTable.Columns.Count];
                for (int idx = 0; idx < frTable.Columns.Count; idx++) columnList[idx] = idx;
            }
            if (headerList == null)
            {
                headerList = new string[columnList.Length];
                for (int idx = 0; idx < columnList.Length; idx++) headerList[idx] = frTable.Columns[columnList[idx]].ColumnName;
            }
            if (headerList.Length != columnList.Length)
            {
                common.errorHandler.lastErrorMessage = "[columnList] and [headerList] must be the same size.";
                return false;
            }
            
            //Change all space in headers to '-'
            for (int idx = 0; idx < headerList.Length; idx++) headerList[idx] = headerList[idx].Replace(' ','_');

            if (File.Exists(excelFile)) File.Delete(excelFile);
            if (!CreateExcelFile(excelFile, sheetName, frTable, columnList, headerList)) return false;

            oleDbConn = OpenConnection(excelFile);
            if (oleDbConn == null) return false;

            string SQL_part1 = "";
            for (int idx = 0; idx < columnList.Length; idx++)
            {
                SQL_part1 += (SQL_part1 == "" ? "" : ",") + "[" + headerList[idx] + "]";
            }
            SQL_part1 = "INSERT INTO [" + sheetName + "](" + SQL_part1 + ")";

            DateTime dt = DateTime.Today;
            string SQL_part2, tmp;
            OleDbCommand oleDbComm = new OleDbCommand();
            oleDbComm.Connection = oleDbConn;
            int colId = 0;
            for (int rowId = 0; rowId < frTable.Rows.Count; rowId++)
            {
                SQL_part2 = "";
                for (int idx = 0; idx < columnList.Length; idx++)
                {
                    colId = columnList[idx];
                    tmp = frTable.Rows[rowId][colId].ToString().Trim();
                    switch (frTable.Columns[colId].DataType.ToString().Trim())
                    {
                        case "System.Float":
                        case "System.Double":
                        case "System.Decimal":
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                            double d = 0; double.TryParse(tmp, out d); tmp = sysLibs.ConvertToSQLDoubleString(d);
                            SQL_part2 += (SQL_part2 == "" ? "" : ",") + (tmp != "" ? tmp : "0"); ;
                            break;
                        case "System.DateTime":
                            if (DateTime.TryParse(tmp, out dt)) tmp = common.sysLibs.ConvertToSQLDateString(dt); 
                            else tmp = "";
                            SQL_part2 += (SQL_part2 == "" ? "" : ",") + (tmp != "" ? "'" + tmp + "'" : "null");
                            break;
                        case "System.Boolean":
                            SQL_part2 += (SQL_part2 == "" ? "" : ",") + (tmp != "" ? tmp : "null");
                            break;
                        default:
                            tmp = ReplaceSpecialSQLChars(tmp);
                            SQL_part2 += (SQL_part2 == "" ? "" : ",") + "'" + tmp + "'";
                            break;
                    }
                }
                SQL_part2 = " VALUES (" + SQL_part2 + ")";
                oleDbComm.CommandText = SQL_part1 + SQL_part2;
                oleDbComm.ExecuteNonQuery();
            }
            oleDbConn.Close();
            return true;
        }

        public static bool ExportToExcel(DataTable frTable, string excelFile,int[] columnList, string[] headerList)
        {
            return ExportToExcel(frTable, excelFile, "Sheet1", columnList, headerList);
        }

        public static bool ExportToExcel(DataTable frTable, string excelFile, string sheetName)
        {
            return ExportToExcel(frTable, excelFile, sheetName, null, null);
        }
        public static bool ExportToExcel(DataTable frTable, string excelFile)
        {
            return ExportToExcel(frTable, excelFile, "Sheet1", null, null);
        }
	}
}
