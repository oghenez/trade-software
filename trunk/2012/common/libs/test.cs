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
        public static string lastErrorMessage = "";

        private static string ReplaceSpecialSQLChars(string str)
        {
            str = str.Replace('\'', ' ');
            return str;
        }
        public static OleDbConnection OpenConnection(string excelFile)
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

        public static bool CreateExcelFile(string excelFile, string sheetName, DataTable frTable,
                                           ArrayList columnList, ArrayList headerList)
        {
            string SQLCmd = "";
            OleDbConnection oleDbConn = OpenConnection(excelFile);
            if (oleDbConn == null) return false;
            try
            {
                string columName;
                int columnNo;
                for (int idx = 0; idx < frTable.Columns.Count; idx++)
                {
                    if (columnList != null)
                    {
                        columnNo = columnList.IndexOf(frTable.Columns[idx].ColumnName.ToUpper());
                        if (columnNo < 0) continue;
                        columName = headerList[columnNo].ToString();
                    }
                    else columName = frTable.Columns[idx].ColumnName.ToString();

                    SQLCmd += (SQLCmd == "" ? "" : ",") + "[" + columName + "]";
                    switch (frTable.Columns[idx].DataType.ToString().Trim())
                    {
                        case "System.Double":
                        case "System.Decimal":
                        case "System.Int64":
                            SQLCmd = " double";
                            break;
                        case "System.DateTime":
                            SQLCmd = " date ";
                            break;
                        case "System.Boolean":
                            SQLCmd += " bit";
                            break;
                        default:
                            SQLCmd += " string";
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
                lastErrorMessage = er.Message.ToString();
            }
            finally
            {
                if (oleDbConn != null && oleDbConn.State == ConnectionState.Open) oleDbConn.Close();
            }
            return false;
        }

        public static bool ExportToExcel(DataTable frTable, string excelFile, string sheetName,
                                  ArrayList columnList, ArrayList headerList)
        {
            OleDbConnection oleDbConn = null;
            try
            {
                //Change all column name to upper case to make the comparision is case-insensitive
                if (columnList != null)
                {
                    for (int idx1 = 0; idx1 < columnList.Count; idx1++)
                        columnList[idx1] = columnList[idx1].ToString().Trim().ToUpper();

                    if (headerList == null)
                    {
                        lastErrorMessage = "[headerList] is null.";
                        return false;
                    }
                    if (headerList.Count != columnList.Count)
                    {
                        lastErrorMessage = "[columnList] and [headerList] must be the same size.";
                        return false;
                    }
                }

                if (File.Exists(excelFile)) File.Delete(excelFile);
                if (!CreateExcelFile(excelFile, sheetName, frTable, columnList, headerList)) return false;

                oleDbConn = OpenConnection(excelFile);
                if (oleDbConn == null) return false;

                int columnNo;
                string SQL_part1 = "", columName;
                for (int idx1 = 0; idx1 < frTable.Columns.Count; idx1++)
                {
                    if (columnList != null)
                    {
                        columnNo = columnList.IndexOf(frTable.Columns[idx1].ColumnName.ToUpper());
                        if (columnNo < 0) continue;
                        columName = headerList[columnNo].ToString();
                    }
                    else columName = frTable.Columns[idx1].ColumnName.ToString();

                    SQL_part1 += (SQL_part1 == "" ? "" : ",") + "[" + columName + "]";
                }
                SQL_part1 = "INSERT INTO [" + sheetName + "](" + SQL_part1 + ")";

                DateTime dt = DateTime.Today;
                string SQL_part2, tmp;
                OleDbCommand oleDbComm = new OleDbCommand();
                oleDbComm.Connection = oleDbConn;
                for (int idx1 = 0; idx1 < frTable.Rows.Count; idx1++)
                {
                    SQL_part2 = "";
                    for (int idx2 = 0; idx2 < frTable.Columns.Count; idx2++)
                    {
                        if (columnList != null)
                        {
                            columnNo = columnList.IndexOf(frTable.Columns[idx2].ColumnName.ToUpper());
                            if (columnNo < 0) continue;
                        }
                        tmp = frTable.Rows[idx1][idx2].ToString().Trim();
                        switch (frTable.Columns[idx2].DataType.ToString().Trim())
                        {
                            case "System.Double":
                            case "System.Decimal":
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                                double d =0; double.TryParse(tmp,out d);  tmp = sysLibs.ConvertToSQLDoubleString(d);
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
            catch (Exception er)
            {
                lastErrorMessage = er.Message.ToString();
            }
            finally
            {
                if (oleDbConn != null && oleDbConn.State == ConnectionState.Open) oleDbConn.Close();
            }
            return false;
        }

        public static bool ExportToExcel(DataTable frTable, string excelFile,ArrayList columnList, ArrayList headerList)
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
