namespace UserLogin.models
{
  public class User
  {
    public string UserName { get; private set; }
    private string Password;
    private string Email;

    public bool LoggedIn { get; set; }

    public bool CheckPassword(string password)
    {
      if (password == Password) { return true; }
      return false;
    }


    public User(string username, string email, string password, bool loggedin)
    {
      UserName = username;
      Email = email;
      Password = password;
      LoggedIn = loggedin;
    }
  }
}