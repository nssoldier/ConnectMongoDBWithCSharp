using System;
using MongoDB.Driver;
namespace DAL
{
  public class DBHelper
  {
    public static MongoClient GetConnection()
    {
      return new MongoClient();
    }
    public IMongoDatabase GetDatabase(MongoClient connection,string databaseName)
    {
      return connection.GetDatabase(databaseName);
    }
  }
}
