using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
// using MongoDB.Bson.Serialization;
namespace dotnetMongoDB
{
  class Program
  {
    static void Main(string[] args)
    {
      var client = new MongoClient();
      // client.
      var db = client.GetDatabase("graphql");
      // db.CreateCollection("Loz");
      var collection = db.GetCollection<BsonDocument>("users");
      var users = collection.Find(b => true).ToListAsync().Result;
      // var doc = new BsonDocument
      // {
      //   {"name","ta van uoc"},
      //   {"work","ngu lol"}
      // };
      // collection.InsertOneAsync(new User("Hoang giao chu3","king")).Wait();

      Console.WriteLine("Users: ");
      foreach (var item in users)
      {
        Console.WriteLine($"id: {item.GetValue("_id")}, name: {item.GetValue("name").ToString().ToUpper()}, work: {(item.GetValue("work") != null ? item.GetValue("work").ToString().ToUpper():item.GetValue("work").ToString())}");
      }
    }
  }
}
