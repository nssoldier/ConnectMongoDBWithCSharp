using System;
using MongoDB.Bson;

namespace Persistence
{
  public class User
  {
    public User() { }

    public User(ObjectId id)
    {
      _id = id;
    }

    public User(string name, string work)
    {
      this.name = name;
      this.work = work;
    }
    
    public ObjectId _id { get; set; }
    public string name { get; set; }
    public string work { get; set; }
    public int __v { get; set; }
  }
}
