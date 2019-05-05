using System;
using System.Collections.Generic;
using Persistence;
using MySql.Data.MySqlClient;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DAL
{
  public class EmployeeDal
  {
    private MySqlConnection connectionSql;
    private MySqlDataReader reader;
    private string query;
    private MongoClient connectionNoSql = DBHelperMongoDB.GetConnection();
    private DBHelperMongoDB dbHelper = new DBHelperMongoDB();

    public EmployeeDal()
    {
      connectionSql = DBHelperMySql.OpenConnection();
    }
    public List<Employee> GetEmployeeWithLimit(int limit)
    {
      if (connectionSql == null)
      {
        connectionSql = DBHelperMySql.OpenConnection();
      }
      if (connectionSql.State == System.Data.ConnectionState.Closed)
      {
        connectionSql.Open();
      }

      query = @"select * from employees limit " + limit + ";";
      MySqlCommand command = new MySqlCommand(query, connectionSql);
      List<Employee> employees = null;
      using (reader = command.ExecuteReader())
      {
        employees = new List<Employee>();
        while (reader.Read())
        {
          Employee employee = GetEmployee(reader);
          TitleDal titleDal = new TitleDal();
          employee.Titles = titleDal.GetTitlesByEmpNo((int?)employee.EmpNo);
          employees.Add(employee);
        }
      }
      connectionSql.Close();
      return employees;
    }
    public Employee GetEmployeeByEmpNo(int? EmpNo)
    {
      if (EmpNo == null)
      {
        return null;
      }
      if (connectionSql == null)
      {
        connectionSql = DBHelperMySql.OpenConnection();
      }
      if (connectionSql.State == System.Data.ConnectionState.Closed)
      {
        connectionSql.Open();
      }

      query = @"select * from employees where emp_no = " + EmpNo + ";";
      MySqlCommand command = new MySqlCommand(query, connectionSql);
      Employee employee = null;
      using (reader = command.ExecuteReader())
      {
        if (reader.Read())
        {
          employee = GetEmployee(reader);
          TitleDal titleDal = new TitleDal();
          employee.Titles = titleDal.GetTitlesByEmpNo(EmpNo);
        }
      }
      connectionSql.Close();
      return employee;
    }
    public bool addEmployee(Employee employee)
    {
      bool result = false;

      try
      {
        IMongoDatabase database = dbHelper.GetDatabase(connectionNoSql, "graphql");
        try
        {
          database.CreateCollection("employees");
        }
        catch (System.Exception)
        {

          throw;
        }
        var coll = database.GetCollection<Employee>("employees");
        coll.InsertOneAsync(employee).Wait();
        result = true;
      }
      catch
      {

        throw;
      }

      return result;
    }
    public Employee GetEmployee(MySqlDataReader reader)
    {
      int empNo = reader.GetInt32("emp_no");
      string firstName = reader.GetString("first_name");
      string lastName = reader.GetString("last_name");
      char gender = reader.GetChar("gender");
      DateTime birthDate = reader.GetDateTime("birth_date");
      DateTime hireDate = reader.GetDateTime("hire_date");

      Employee employee = new Employee(empNo, birthDate, firstName, lastName, gender, hireDate);

      return employee;
    }
  }
}