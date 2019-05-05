using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Persistence;

namespace DAL
{
  public class UserDal
  {
    private MongoClient connection = DBHelper.GetConnection();
    private DBHelper dbHelper = new DBHelper();

    public bool addUser(User user)
    {
      bool result = false;

			try
      {
        IMongoDatabase database = dbHelper.GetDatabase(connection, "graphql");
        var coll = database.GetCollection<User>("users");
        coll.InsertOneAsync(user).Wait();
        result = true;
      }
      catch
      {

        throw;
      }

      return result;
    }
    public bool removeUser(string id)
    {
      bool result = false;

			try
      {
        IMongoDatabase database = dbHelper.GetDatabase(connection, "graphql");
        var coll = database.GetCollection<User>("users");
        coll.DeleteOneAsync(a => a._id == new ObjectId(id)).Wait();
        result = true;
      }
      catch
      {

        throw;
      }

      return result;
    }

    public List<User> getAllUser()
    {
      List<User> users = null;
      try
      {
        IMongoDatabase database = dbHelper.GetDatabase(connection, "graphql");
        var coll = database.GetCollection<User>("users");
        users = coll.Find(b => true).ToListAsync().Result;
      }
      catch
      {

        throw;
      }


      return users;
    }
  }
}
