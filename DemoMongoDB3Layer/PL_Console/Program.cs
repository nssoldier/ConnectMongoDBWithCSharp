using System;
using BL;
using Persistence;
using System.Collections.Generic;
namespace PL_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      UserBL userBl = new UserBL();
      List<User> users = userBl.getAllUsers();
      foreach (var item in users)
      {
        Console.WriteLine($"id: {item._id}, name: {item.name.ToUpper()}, work: {(item.work != null ? item.work.ToUpper() : item.work)}");
      }
      Console.WriteLine("Remove record with id: ");
      string id = Console.ReadLine();
      userBl.removeUser("5cceea705fcad12460afd1e3");
      Console.ReadLine();
      users = userBl.getAllUsers();
      foreach (var item in users)
      {
        Console.WriteLine($"id: {item._id}, name: {item.name.ToUpper()}, work: {(item.work != null ? item.work.ToUpper() : item.work)}");
      }
      Console.WriteLine("Add record with:\nname: ");
      string name = Console.ReadLine();
      Console.WriteLine("work: ");
      string work = Console.ReadLine();
      userBl.addUser(new User(name, work));
      Console.ReadLine();
      users = userBl.getAllUsers();
      foreach (var item in users)
      {
        Console.WriteLine($"id: {item._id}, name: {item.name.ToUpper()}, work: {(item.work != null ? item.work.ToUpper() : item.work)}");
      }
    }
  }
}
