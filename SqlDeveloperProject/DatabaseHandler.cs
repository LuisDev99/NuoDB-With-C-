using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuoDb.Data.Client;
using NuoDb.Data.Client.EntityFramework;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;

namespace SqlDeveloperProject
{
    public class DatabaseHandler
    {

        //TODO: Implement GetConnection
        //TODO: Implement GetConnectionSchemas
        //TODO: Implement GetSchemaStringObjects
        //TODO: Implement GetSchemaTables
        //TODO: Implement GetSchemaFunctions
        //TODO: Implement GetSchemaViews
        //TODO: Implement GetSchemaProcedures
        //TODO: Implement GetTableColumns
        //TODO: Implement GetSchemaIndexes

        public static string userLogged = "";
        public static string userPassword = "";
        public static string currentSchema = "";

        NuoDbCommand command;
        NuoDbConnection connection;
        DbDataReader reader;
        NuoDbCommandBuilder commandBuilder;
        NuoDbDataAdapter adapter;


        string connectionString;
        string username;
        string password;

        public DatabaseHandler()
        {

        }

        public DatabaseHandler(string _username, string _password)
        {


        }

        public string AlterFunction(string alterCommand)
        {
            return GeneralAlterFunction(alterCommand);
        }

        public string AlterProcedure(string alterCommand)
        {
            return GeneralAlterFunction(alterCommand);
        }

        public string AlterUser(string alterCommand)
        {
            return GeneralAlterFunction(alterCommand);
        }

        public string AlterTrigger(string alterCommand)
        {
            return GeneralAlterFunction(alterCommand);
        }

        public bool CreateUser(string username, string password)
        {
            try
            {
                connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword + ";Schema=" + currentSchema;
                connection = new NuoDbConnection(connectionString);
                command = new NuoDbCommand("Create user " + username + " PASSWORD '" + password + "'; " +
                                            "GRANT system.dba to " + username + ";" +
                                            "Grant system.administrator to " + username + "; ", connection);
                connection.Open();
                reader = command.ExecuteReader();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string CreateTable(string ddl)
        {
            return GeneralCreateSQLFunction(ddl);
        }

        public string CreateFunction(string ddl)
        {
            return GeneralCreateSQLFunction(ddl);
        }

        public string CreateProcedure(string ddl)
        {
            return GeneralCreateSQLFunction(ddl);
        }

        public string CreateView(string ddl)
        {
            return GeneralCreateSQLFunction(ddl);
        }

        public string CreateTrigger(string ddl)
        {
            return GeneralCreateSQLFunction(ddl);
        }

        public string CreateIndex(string ddl)
        {
            return GeneralCreateSQLFunction(ddl);
        }

        public string DeleteTable(string tableName, string schema)
        {
            return GeneralDeleteSQLFunction("table", tableName, schema);
        }

        public string DeleteFunction(string functionName, string schema)
        {
            return GeneralDeleteSQLFunction("function", functionName, schema);
        }

        public string DeleteProcedure(string procedureName, string schema)
        {
            return GeneralDeleteSQLFunction("procedure", procedureName, schema);
        }

        public string DeleteView(string viewName, string schema)
        {
            return GeneralDeleteSQLFunction("view", viewName, schema);
        }

        public string DeleteTrigger(string triggerName, string schema)
        {
            return GeneralDeleteSQLFunction("trigger", triggerName, schema);
        }

        public string DeleteIndex(string indexName, string schema)
        {
            return GeneralDeleteSQLFunction("index", indexName, schema);
        }

        public bool Login(string username, string password)
        {
            try
            {
                connectionString = "Server=localhost;Database=test;User=" + username + ";Password=" + password;
                connection = new NuoDbConnection(connectionString);
                connection.Open();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<string> GetUsers()
        {
            return GeneralSelectSQLFunction("select * from SYSTEM.USERS");
        }

        public List<String> GetTableFields(string tablename)
        {
            return GeneralSelectSQLFunction("select Fields.field from System.Fields where Fields.Tablename = '"+tablename+"'");
        }

        public List<String> GetConnections()
        {

            return new List<string> { "Connection 1", "Connection 2", "Connection 3" };
        }

        public List<String> GetSchemaStringObjects(string schema)
        {

            return new List<string> { "Tables", "Functions", "Procedures", "Views", "Indexes" };
        }

        public List<String> GetConnectionSchemas(string connectionn)
        {
            return GeneralSelectSQLFunction("select SCHEMA from SYSTEM.SCHEMAS");
        }

        public List<String> GetSchemaTables(string schema)
        {
            return GeneralSelectSQLFunction("select TABLENAME from SYSTEM.TABLES where schema = '" + schema + "'");
        }

        public List<String> GetSchemaFunctions(string schema)
        {
            return GeneralSelectSQLFunction("select FUNCTIONNAME from SYSTEM.FUNCTIONS where schema = '" + schema + "'");
        }

        public List<String> GetSchemaViews(string schema)
        {
            return GeneralSelectSQLFunction("select viewname from SYSTEM.VIEW_TABLES where schema = '" + schema + "'");
        }

        public List<String> GetSchemaProcedures(string schema)
        {
            return GeneralSelectSQLFunction("select procedurename from SYSTEM.PROCEDURES where schema = '" + schema + "'");
        }

        public List<String> GetSchemaIndexes(string schema)
        {
            return GeneralSelectSQLFunction("select indexname from SYSTEM.INDEXES where schema = '" + schema + "'");
        }

        public List<String> GetTableColumns(string table, string schema)
        {

            return new List<String> { "column 1", "column 2" };
        }

        public string GetFunctionDDL(string functionName, string schema)
        {
            return GeneralSelectDDLFunction("FUNCTIONTEXT", "FUNCTIONS", "FUNCTIONNAME", functionName, schema);
        }

        public string GetProcedureDDL(string procedureName, string schema)
        {
            return GeneralSelectDDLFunction("PROCEDURETEXT", "PROCEDURES", "PROCEDURENAME", procedureName, schema);
        }

        public List<string> GetTableDDL(string tableName, string schema)
        {
            var listTableColumns = GeneralSelectSQLFunction("select Fields.field from System.Fields where Fields.Tablename = '" + tableName + "' and Fields.Schema = '" + schema + "'");
            var listTableColumnsDataType = GeneralSelectSQLFunction("select Datatypes.Name from System.Fields inner join System.Datatypes on Fields.Fieldid = Datatypes.id where Fields.Tablename = '" + tableName + "' and Fields.Schema = '" + schema + "'");

            List<String> resultingList = new List<string>();

            for(int i = 0; i < listTableColumns.Count; i++)
            {
                resultingList.Add(listTableColumns[i] + " -> [" + listTableColumnsDataType[i] + "]");
            }

            return resultingList;
        }

        public List<String> GetIndexFields(string indexName, string schema)
        {
            return GeneralSelectSQLFunction("select Indexfields.Field from System.Indexes inner join System.Indexfields on Indexes.Indexname = Indexfields.Indexname where Indexes.Indexname = '"+indexName+"' and Indexes.Schema = '"+schema+"'");
        }

        public DataTable GetTableData(string tableName, string schema)
        {

            connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword + ";Schema=" + currentSchema;

            connection = new NuoDbConnection(connectionString);
            command = new NuoDbCommand("select * from " + schema + "." + tableName, connection);
            connection.Open();

            adapter = new NuoDbDataAdapter(command);

            DataTable data = new DataTable();
            adapter.Fill(data);

            return data;

        }

        public DataTable GetViewData(string viewName)
        {

            connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword + ";Schema=" + currentSchema;

            connection = new NuoDbConnection(connectionString);
            command = new NuoDbCommand("select * from " + viewName, connection);
            connection.Open();

            adapter = new NuoDbDataAdapter(command);

            DataTable data = new DataTable();
            adapter.Fill(data);

            return data;

        }

        public string UpdateTableData(DataTable dataTable)
        {
            try
            {
                commandBuilder = new NuoDbCommandBuilder();
                commandBuilder.DataAdapter = adapter;
                adapter.Update(dataTable);
                return "Success";
            }
            catch (NuoDbSqlException e)
            {
                return e.Message;
            }
        }

        private string GeneralCreateSQLFunction(string ddl)
        {
            try
            {
                connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword;
                connection = new NuoDbConnection(connectionString);
                command = new NuoDbCommand(ddl, connection);
                connection.Open();
                reader = command.ExecuteReader();
                return "Success";
            }
            catch (NuoDbSqlException e)
            {
                return e.Message;
            }
        }

        private string GeneralDeleteSQLFunction(string objectType, string objectName, string schema)
        {
            try
            {
                connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword + ";Schema=" + schema;
                connection = new NuoDbConnection(connectionString);
                command = new NuoDbCommand("Drop " + objectType + " " + schema + "." + objectName, connection);
                connection.Open();
                reader = command.ExecuteReader();
                return "Success";
            }
            catch (NuoDbSqlException e)
            {
                return e.Message;
            }
        }

        private List<String> GeneralSelectSQLFunction(string sqlCommand)
        {
            List<String> list = new List<String>();
            connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword + ";";

            connection = new NuoDbConnection(connectionString);
            command = new NuoDbCommand(sqlCommand, connection);
            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }

            connection.Close();
            reader.Close();

            return list;

        }

        private string GeneralSelectDDLFunction(string objectTextName, string objectTable, string objectName, string name, string schema)
        {
            try
            {
                connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword;
                connection = new NuoDbConnection(connectionString);
                command = new NuoDbCommand("select " + objectTextName + " from SYSTEM. " + objectTable + " where " + objectName + " = '" + name + "' and SCHEMA = '" + schema + "'", connection);
                connection.Open();

                reader = command.ExecuteReader();
                string ddl = "";

                while (reader.Read())
                    ddl = reader[0].ToString();

                connection.Close();
                reader.Close();

                return ddl;
            }
            catch (NuoDbSqlException e)
            {
                return e.Message;
            }

        }

        private string GeneralAlterFunction(string alterCommand)
        {
            try
            {
                connectionString = "Server=localhost;Database=test;User=" + userLogged + ";Password=" + userPassword;
                connection = new NuoDbConnection(connectionString);
                command = new NuoDbCommand(alterCommand, connection);
                connection.Open();
                reader = command.ExecuteReader();
                return "Success";
            }
            catch (NuoDbSqlException e)
            {
                return e.Message;
            }
        }
    }
}























//string cs = "Server=localhost;Database=test;User=dba;Password=goalie;Schema=HOCKEY";
//connectionString = "Server=localhost;Database=test;User=" + username + ";Password=" + password + ";Schema=HOCKEY";

/*using (NuoDbConnection connection = new NuoDbConnection(connectionString))
{
    command = new NuoDbCommand("select * from HOCKEY", connection);
    connection.Open();
    reader = command.ExecuteReader();

    while (reader.Read())
    {
        Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
    }
    reader.Close();
}*/
