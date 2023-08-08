using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace RestSharpFrameWork.generic
{

    public struct PathsConsts
    {
        public static string baseDirectory = Directory.GetCurrentDirectory();
        public static string subBaseDirectory=Directory.GetParent(baseDirectory).FullName;
        public static string currentDirectory=Directory.GetParent(subBaseDirectory).FullName;
        
        public static string connectionString= "Driver={MySQL ODBC 8.1 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
        public static string excelPath = currentDirectory+"\\Resources\\Data.xlsx";
        public static string csvPath = currentDirectory + "\\RestSharpFrameWork\\Resources\\Data.csv";

    }
}
