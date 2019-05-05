using System;
using System.Collections.Generic;
using MongoDB.Bson;
namespace Persistence
{
  public class Employee
  {
		public Employee(){}
    public Employee(DateTime birthDate, string firstName, string lastName, char gender, DateTime hireDate)
    {
      BirthDate = birthDate;
      FirstName = firstName;
      LastName = lastName;
      Gender = gender;
      HireDate = hireDate;
    }

    public Employee(int empNo, DateTime birthDate, string firstName, string lastName, char gender, DateTime hireDate)
    {
      EmpNo = empNo;
      BirthDate = birthDate;
      FirstName = firstName;
      LastName = lastName;
      Gender = gender;
      HireDate = hireDate;
    }

    public int EmpNo { set; get; }
    public DateTime BirthDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public char Gender { get; set; }
    public DateTime HireDate { get; set; }
    public List<Title> Titles { get; set; }
  }
}
