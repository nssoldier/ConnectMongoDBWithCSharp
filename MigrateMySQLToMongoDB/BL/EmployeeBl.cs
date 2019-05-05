using System;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace BL
{
  public class EmployeeBl
  {
    EmployeeDal employeeDal = new EmployeeDal();
    public Employee GetEmployeeByEmpNo(int? EmpNo)
    {
      return employeeDal.GetEmployeeByEmpNo(EmpNo);
    }
    public List<Employee> GetEmployeeWithLimit(int limit)
    {
      return employeeDal.GetEmployeeWithLimit(limit);
    }
    public bool addEmployee(Employee employee)
    {
      return employeeDal.addEmployee(employee);
    }
  }
}
