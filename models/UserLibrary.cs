using System.Collections.Generic;

namespace UserLogin.models
{
  public class UserLibrary
  {
    private List<User> Users;

    public User Login(string username, string password)
    {
      User myuser = Users.Find(user => user.UserName == username);
      if (myuser != null && myuser.CheckPassword(password))
      {
        myuser.LoggedIn = true;
        return myuser;
      }
      return null;
    }

    public User Register(string username, string email, string password)
    {
      User prevUser = Users.Find(user => user.UserName == username);
      if (prevUser != null)
      {
        return null;
      }
      User newUser = new User(username, email, password, true);
      Users.Add(newUser);
      return newUser;
    }

    public void Logout(string username)
    {
      User myuser = Users.Find(user => user.UserName == username);
      if (myuser == null)
      {
        System.Console.WriteLine("\nLOGOUT: COULD NOT FIND USER ACCOUNT");
        return;
      }
      myuser.LoggedIn = false;
    }


    public UserLibrary()
    {
      Users = new List<User>();
    }
  }
}