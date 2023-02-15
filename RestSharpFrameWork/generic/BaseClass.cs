﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
[assembly: Parallelize(Workers = 5, Scope = ExecutionScope.MethodLevel)]


namespace RestSharpFrameWork.generic
{
    [TestClass]
    public class BaseClass
    {
        
        public string dataBaseConnection = "Driver={MySQL ODBC 8.0 Unicode Driver};Server=localhost:3306;Database=projects;User=root;Password=root;";
        public OdbcCommand command;
        public OdbcConnection connection;

        
        ExcelUtility excelUtility=new ExcelUtility();
        ODBCValidation oDBCValidation = new ODBCValidation();
        RestSharpUtils restSharpUtils = new RestSharpUtils();
        Utilitys utilitys= new Utilitys();
        Validation validation= new Validation();

        [AssemblyInitialize]
        public static void AssemblyInitilizer(TestContext context)
        {

        }

        [ClassInitialize]
        public static void DataBase(TestContext context)
        {

        }

        [TestInitialize]
        public void OpeningDataBase()
        {
            connection = new OdbcConnection(dataBaseConnection);
            connection.Open();

        }

        [TestCleanup]
        public void ClosingDataBase()
        {
            connection.Close();

        }
    }
        

    }

