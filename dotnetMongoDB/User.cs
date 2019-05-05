using System;
using MongoDB.Bson;
// using MongoDB.Bson.Serialization.Attributes;

namespace dotnetMongoDB
{
  public class User
  {
    public User() { }

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