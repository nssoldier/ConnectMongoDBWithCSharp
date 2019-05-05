using System;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace BL
{
  public class UserBL
  {
    UserDal userDal = new UserDal();

    public List<User> getAllUsers()
    {
      return userDal.getAllUser();
    }
    public bool addUser(User user)
    {
      return userDal.addUser(user);
    }
    public bool removeUser(string id)
    {
      return userDal.removeUser(id);
    }

  }
}
