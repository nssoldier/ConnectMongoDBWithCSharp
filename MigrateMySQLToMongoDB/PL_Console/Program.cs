using System;
using System.Collections.Generic;
using BL;
using Persistence;

namespace PL_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      EmployeeBl employeeBl = new EmployeeBl();
      Console.Write("Input emp_no: ");
      int emp_no = Convert.ToInt32(Console.ReadLine());
      Employee emp = employeeBl.GetEmployeeByEmpNo(emp_no);
      employeeBl.addEmployee(emp);
      //   Console.WriteLine("Output: {");
      //   Console.WriteLine($"first_name: '{emp.FirstName}',");
      //   Console.WriteLine($"last_name: '{emp.LastName}',");
      //   Console.WriteLine($"birth_date: '{emp.BirthDate.ToShortDateString()}',");
      //   Console.WriteLine($"gender: '{emp.Gender}',");
      //   Console.WriteLine($"hire_date: '{emp.HireDate.ToShortDateString()}',");
      //   Console.WriteLine($"titles: [");
      //   int x = 0;
      //   foreach (var item in emp.Titles)
      //   {
      //     if (x != 0)
      //     {
      //       Console.WriteLine(",");
      //     }
      //     x++;
      //     Console.Write("{ ");
      //     Console.Write($"title: '{item.EmpTitle}', ");
      //     Console.Write($"from_date: '{item.FromDate.ToShortDateString()}', ");
      //     Console.Write($"to_date: '{item.ToDate.ToShortDateString()}' " + "}");
      //   }
      //   Console.WriteLine("\n]}");
      // List<Employee> emps = employeeBl.GetEmployeeWithLimit(emp_no);
      // Console.WriteLine("[");
      // int a = 0;
      // foreach (var item in emps)
      // {
      //   if (a != 0)
      //   {
      //     Console.WriteLine(",");
      //   }
      //   a++;
      //   Console.WriteLine("{");
      //   Console.WriteLine($"first_name: '{item.FirstName}',");
      //   Console.WriteLine($"last_name: '{item.LastName}',");
      //   Console.WriteLine($"birth_date: '{item.BirthDate.ToShortDateString()}',");
      //   Console.WriteLine($"gender: '{item.Gender}',");
      //   Console.WriteLine($"hire_date: '{item.HireDate.ToShortDateString()}',");
      //   Console.WriteLine($"titles: [");
      //   int x = 0;
      //   foreach (var it in item.Titles)
      //   {
      //     if (x != 0)
      //     {
      //       Console.WriteLine(",");
      //     }
      //     x++;
      //     Console.Write("{ ");
      //     Console.Write($"title: '{it.EmpTitle}', ");
      //     Console.Write($"from_date: '{it.FromDate.ToShortDateString()}', ");
      //     Console.Write($"to_date: '{it.ToDate.ToShortDateString()}' " + "}");
      //   }
      //   Console.Write("\n]}");
      // }
      // Console.WriteLine("\n]");
    }
  }
}
