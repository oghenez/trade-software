using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;
using System.Net.Mail;
using System.Drawing;

namespace common
{
    public static class fileFuncs
    {
        #region copy file
        public class UpLoadParams
        {
            public string URL = "";
            internal string Directory = "data";
            internal string DirectoryParam = "toDir";
            public string SubDirectory = "";
            public string Account = "", Password = "";
            public bool AddHashDir = true;
        }
        public class DownLoadParams
        {
            public string URL = "";
            internal string Directory = "data";
            public string SubDirectory = "";
            public string Account = "", Password = "";
        }
       
        #endregion

        #region file search
        private static bool ProcessSearchDirectory(string folder, StringCollection searchPattern, Func<string, bool, bool> func)
        {
            if (func(folder, true) == false) return false;
            if (searchPattern == null || searchPattern.Count == 0)
            {
                foreach (string file in Directory.GetFiles(folder))
                {
                    Application.DoEvents();
                    if (func == null) continue;
                    if (func(file, false) == false) return false;
                }
            }
            else
            {
                for (int idx = 0; idx < searchPattern.Count; idx++)
                {
                    foreach (string file in Directory.GetFiles(folder, searchPattern[idx]))
                    {
                        Application.DoEvents();
                        if (func == null) continue;
                        if (func(file, false) == false) return false;
                    }
                }
            }
            return true;
        }
        public static void SearchDirectory(string path, StringCollection searchPattern, bool recursive, Func<string, bool, bool> func)
        {
            SearchOption searchOption = (recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);

            if (ProcessSearchDirectory(path, searchPattern, func) == false) return;
            if (recursive == false) return;
            foreach (string folder in Directory.GetDirectories(path))
            {
                //if (ProcessSearchDirectory(folder, searchPattern, func) == false) return;
                SearchDirectory(folder, searchPattern, recursive, func);
            }
        }
        #endregion

        public static string ValidateFileName(string fn)
        {
            //fn.Replace("\\", "-");
            //fn.Replace("/", "-");
            //char[] invalidChar = System.IO.Path.GetInvalidFileNameChars();
            for (int idx = 0; idx < fn.Length; idx++)
            {
                if (!Char.IsLetterOrDigit(fn[idx])) fn = fn.Replace(fn[idx], '-');
            }
            return fn;
        }

        //Cut off  / and  \ at the end of a folder name
        public static string NormalizeFolderName(string dirName)
        {
            dirName = dirName.Trim();
            int idx;
            for (idx = dirName.Length - 1; idx >= 0; idx--)
            {
                if ((dirName[idx] == '/') || (dirName[idx] == '\\')) continue;
                break;
            }
            return dirName.Substring(0, idx + 1);
        }
        public static bool IsFileReadWritable(string fileName)
        {
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bool retVal = (fs.CanRead && fs.CanWrite);
                fs.Close();
                return retVal;
            }
            catch { return false;}
        }
        
        //Create Directory + Sub-Directory
        public static void  CreateDirectory(string dirName)
        {
            if (!Directory.Exists(dirName))  Directory.CreateDirectory(dirName);
            return;
        }
        public static bool PathExist(string path)
        {
            return (Directory.Exists(path));
        }
        public static bool FileExist(string fileName)
        {
            return (File.Exists(fileName));
        }
        public static long FileSize(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.Length;
        }
        public static string GetFullPath(string fileName)
        {
            if (fileName.Trim() == "") return "";
            fileName = FileNameOnly(fileName) + FileExtension(fileName);
            return MakeFileName(EnvironmentLibs.GetExecutePath(), fileName);
        }
        public static string MakeFileNameFromExecutablePath(string ext)
        {
            string fileName = EnvironmentLibs.GetExecuteFullPath();
            string tmp1 = FileNamePath(fileName);
            string tmp2 = FileNameOnly(fileName) + ext;
            return MakeFileName(tmp1, tmp2);
        }

        public static string FileNamePath(string fileName)
        {
            if (fileName == null) return null;
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.DirectoryName;
        }
        public static string ShortFileName(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.Name;
        }
        public static string FileExtension(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            return fInfo.Extension;
        }
        public static string FileNameOnly(string fileName)
        {
            FileInfo fInfo = new FileInfo(@fileName);
            if (fInfo.Extension == "") return fInfo.Name;
            return fInfo.Name.Replace(fInfo.Extension,"");
        }

        public static void FileRemove(string fileName)
        {
            if (File.Exists(fileName)) File.Delete(fileName);
        }
        public static void FileCopy(string srcFileName, string dstFileName)
        {
            if (File.Exists(dstFileName)) File.Delete(dstFileName);
            File.Copy(srcFileName, dstFileName);
        }
        public static void FileMove(string srcFileName, string dstFileName)
        {
            if (File.Exists(dstFileName)) File.Delete(dstFileName);
            File.Move(srcFileName, dstFileName);
        }

        public static string GetTempPath()
         {
             return System.IO.Path.GetTempPath().Replace("\\","//");
         }
        public static string MakeFileName(string path,string fileName)
        {
            path = path.Trim();
            fileName = fileName.Trim();
            if (path == "") return fileName;
            if (path.LastIndexOf("\\") == path.Length) path = path.Substring(0, path.Length - 1);
            return path + "\\" + fileName;
        }

        public static string MakeFullPath(string rootPath, string fileName)
        {
            if (rootPath.Length > 0 && fileName.StartsWith(rootPath)) return fileName;
            return MakeFileName(rootPath, fileName);
        }
        public static string MakeFullPath(string fileName)
        {
            return MakeFullPath(EnvironmentLibs.GetExecutePath(), fileName);
        }

        public static string MakeRelativePath(string rootPath, string fileName)
        {
            if (rootPath.Length > 0 && fileName.StartsWith(rootPath))
            {
                fileName = fileName.Substring(rootPath.Length);
                if (fileName.StartsWith("\\")) fileName = fileName.Substring(1);
            }
            return fileName;
        }
        public static string MakeRelativePath(string fileName)
        {
            return MakeRelativePath(EnvironmentLibs.GetExecutePath(), fileName);
        }
        public static string ConcatFileName( params string[] fileNames)
        {
            return StringLibs.MakeString("\\", fileNames);
        }

        
        public static string ReadFile(string fileName)
        {
            string value = "";
            if (!File.Exists(fileName)) return "";
            StreamReader file = File.OpenText(fileName);
            while (!file.EndOfStream) value += file.ReadLine();
            file.Close();
            return value;
        }
        public static void WriteFile(string text,string fileName)
        {
            using (StreamWriter w = File.AppendText(fileName))
            {
                w.WriteLine(text);
            }
        }
        public static string GetTempFileName(string ext)
        {
            string fileName = null;
            string tmpPath = GetTempPath();
            while (true)
            {
                fileName = MakeFileName(tmpPath, sysLibs.UniqueString()) + ext;
                if (!FileExist(fileName)) break;
            }
            return fileName;
        }
        public static string GetApplicationFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
    }
}


