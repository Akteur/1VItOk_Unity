using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private const string fileName = "Players.bytes";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;
    private void Awake()
    {
        DBPath = GetDatabasePath();
        BaseExist();        
        BaseExist();        
    }
    private void Start()
    {
        TableExist();
    }
    static DataBase()
    {
        //DBPath = GetDatabasePath();
    }
    private static string GetDatabasePath()
    {
        return Path.Combine(Application.dataPath, fileName);
    }
    private static void UnpackDatabase(string toPath)
    {
        string fromPath = Path.Combine(Application.streamingAssetsPath, fileName);

        WWW reader = new WWW(fromPath);
        while (!reader.isDone) { }

        File.WriteAllBytes(toPath, reader.bytes);
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
        string query = "create table if not exists Player " +
            "( id INTEGER NOT NULL UNIQUE, name TEXT UNIQUE, password TEXT, PRIMARY KEY( id ) )";
        ExecuteQueryWithoutAnswer(query);
    }
    public void BaseExist()
    {
        if (File.Exists(DBPath)) return;
        else File.Create(DBPath);
    }
}