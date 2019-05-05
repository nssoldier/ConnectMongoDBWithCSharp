using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace DAL
{
  // Using Singleton Design Pattern
  public class DBHelperMySql
  {
    private static string CONNECTION_STRING = "server=localhost;user id=root;password=24112111;port=3306;database=employees;SslMode=None;";

    public static MySqlConnection OpenDefaultConnection()
    {
      try
      {
        MySqlConnection connection = new MySqlConnection
        {
          ConnectionString = CONNECTION_STRING
        };
        connection.Open();

        return connection;
      }
      catch
      {
        return null;
      }
    }

    public static MySqlConnection OpenConnection()
    {
      try
      {
        string connectionString;

        FileStream fileStream = File.OpenRead("ConnectionString.txt");
        using (StreamReader reader = new StreamReader(fileStream))
        {
          connectionString = reader.ReadLine();
        }
        fileStream.Close();

        return OpenConnection(connectionString);
      }
      catch
      {
        return null;
      }
    }

    public static MySqlConnection OpenConnection(string connectionString)
    {
      try
      {
        MySqlConnection connection = new MySqlConnection
        {
          ConnectionString = connectionString
        };
        connection.Open();
        return connection;
      }
      catch
      {
        return null;
      }
    }
  }
}