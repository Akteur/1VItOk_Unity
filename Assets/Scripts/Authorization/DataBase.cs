using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private const string fileName = "Players.bytes";
    private static string path;
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;
    private void Awake()
    {
        Directory.CreateDirectory(Application.dataPath + "/DataBase");
        DBPath = GetDatabasePath();
        BaseExist();             
    }
    private void Start()
    {        
        TableExist();
    }
    static DataBase()
    {
        
    }
    private static string GetDatabasePath()
    {
        path = Application.dataPath + "/DataBase/" + fileName;
        return path;
    }
    private static void OpenConnection()
    {
        connection = new SqliteConnection("Data Source=" + DBPath);
        command = new SqliteCommand(connection);
        connection.Open();
    }
    public static void CloseConnection()
    {
        connection.Close();
        command.Dispose();
    }
    public void ExecuteQueryWithoutAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public void ExecuteQueryWithoutAnswer(string query, string paramName1, string paramValue1)
    {
        OpenConnection();
        command.CommandText = query;
        command.Parameters.AddWithValue("@" + paramName1, paramValue1);
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public void ExecuteQueryWithoutAnswer(string query, string paramName1,
        string paramName2, string paramValue1, string paramValue2)
    {
        OpenConnection();
        command.CommandText = query;
        command.Parameters.AddWithValue("@" + paramName1, paramValue1);
        command.Parameters.AddWithValue("@" + paramName2, paramValue2);
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public void ExecuteQueryWithoutAnswer(string query, string paramName1,
        string paramName2, string paramName3, string paramValue1, string paramValue2, string paramValue3)
    {
        OpenConnection();
        command.CommandText = query;
        command.Parameters.AddWithValue("@" + paramName1, paramValue1);
        command.Parameters.AddWithValue("@" + paramName2, paramValue2);
        command.Parameters.AddWithValue("@" + paramName3, paramValue3);
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public void ExecuteQueryWithoutAnswer(string query, string paramName1,
    string paramName2, string paramName3, string paramName4, 
    string paramValue1, string paramValue2, string paramValue3, string paramValue4)
    {
        OpenConnection();
        command.CommandText = query;
        command.Parameters.AddWithValue("@" + paramName1, paramValue1);
        command.Parameters.AddWithValue("@" + paramName2, paramValue2);
        command.Parameters.AddWithValue("@" + paramName3, paramValue3);
        command.Parameters.AddWithValue("@" + paramName4, paramValue4);
        command.ExecuteNonQuery();
        CloseConnection();
    }
    public string ExecuteQueryWithAnswer(string query)
    {
        OpenConnection();
        command.CommandText = query;
        var answer = command.ExecuteScalar();
        CloseConnection();

        if (answer != null) return answer.ToString();
        else return null;
    }
    public string ExecuteQueryWithAnswer(string query, string paramName1, string paramValue1)
    {
        OpenConnection();
        command.CommandText = query;
        command.Parameters.AddWithValue("@" + paramName1, paramValue1);
        var answer = command.ExecuteScalar();
        CloseConnection();

        if (answer != null) return answer.ToString();
        else return null;
    }
    public string ExecuteQueryWithAnswer(string query, string paramName1,
        string paramName2, string paramValue1, string paramValue2)
    {
        OpenConnection();
        command.CommandText = query;
        command.Parameters.AddWithValue("@" + paramName1, paramValue1);
        command.Parameters.AddWithValue("@" + paramName2, paramValue2);
        var answer = command.ExecuteScalar();
        CloseConnection();

        if (answer != null) return answer.ToString();
        else return null;
    }
    public string ExecuteQueryWithAnswer(string query, string paramName1,
        string paramName2, string paramName3, string paramValue1, string paramValue2, string paramValue3)
    {
        OpenConnection();
        command.CommandText = query;
        command.Parameters.AddWithValue("@" + paramName1, paramValue1);
        command.Parameters.AddWithValue("@" + paramName2, paramValue2);
        command.Parameters.AddWithValue("@" + paramName3, paramValue3);
        var answer = command.ExecuteScalar();
        CloseConnection();

        if (answer != null) return answer.ToString();
        else return null;
    }
    public DataTable GetTable(string query)
    {
        OpenConnection();

        SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);

        DataSet DS = new DataSet();
        adapter.Fill(DS);
        adapter.Dispose();

        CloseConnection();

        return DS.Tables[0];
    }
    public void TableExist()
    {
        string playersQuery = "create table if not exists Player " +
            "( id INTEGER NOT NULL UNIQUE, name TEXT UNIQUE, password TEXT, PRIMARY KEY( id ) )";
        ExecuteQueryWithoutAnswer(playersQuery);
        string buildingQuery = "CREATE TABLE Building " +
            "(Id INTEGER NOT NULL UNIQUE, PlayerId INTEGER NOT NULL, minutes INTEGER, seconds INTEGER,	PRIMARY KEY(Id))";
        ExecuteQueryWithoutAnswer(buildingQuery);

    }
    public void BaseExist()
    {
        if (File.Exists(DBPath)) return;
        else File.Create(DBPath);
    }
}