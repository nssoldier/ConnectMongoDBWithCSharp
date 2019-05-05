using System;
using System.Collections.Generic;
using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
  public class TitleDal
  {
    private MySqlConnection connection;
    private MySqlDataReader reader;
    private string query;

    public TitleDal()
    {
      connection = DBHelperMySql.OpenConnection();
    }

    public List<Title> GetTitlesByEmpNo(int? EmpNo)
    {
      if (EmpNo == null)
      {
        return null;
      }
      if (connection == null)
      {
        connection = DBHelperMySql.OpenConnection();
      }
      if (connection.State == System.Data.ConnectionState.Closed)
      {
        connection.Open();
      }

      query = @"select * from titles where emp_no = " + EmpNo + ";";
      MySqlCommand command = new MySqlCommand(query, connection);
      List<Title> titles = null;
      using (reader = command.ExecuteReader())
      {
      titles = new List<Title>();
        while (reader.Read())
        {
          titles.Add(GetTitle(reader));
        }
      }

      connection.Close();

      return titles;
    }
    public Title GetTitle(MySqlDataReader reader)
    {
      string empTitle = reader.GetString("title");
      DateTime fromDate = reader.GetDateTime("from_date");
      DateTime toDate = reader.GetDateTime("to_date");
      Title title = new Title(fromDate,empTitle,toDate);
      return title;
    }
  }
}