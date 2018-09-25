using System;
using UserLogin.models;

namespace UserLogin
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      Console.WriteLine("Welcome to my user login exercise.  Please select an option.");
      bool playing = true;
      UserLibrary library = new UserLibrary();
      User user = new User("", "", "", false);
      string username = "";
      string email = "";
      string password = "";

      while (playing)
      {
        Console.WriteLine("1 - CREATE AN ACCOUNT");
        Console.WriteLine("2 - LOGIN");
        Console.WriteLine("3 - LOGOUT");
        Console.WriteLine("4 - EXIT APP");

        string choice = Console.ReadLine();

        switch (choice)
        {
          //REGISTER
          case "1":
            bool confirmed = false;
            while (!confirmed)
            {
              Console.Write("USERNAME: ");
              username = Console.ReadLine().ToLower();
              Console.Write("EMAIL: ");
              email = Console.ReadLine();
              Console.Write("PASSWORD: ");
              password = Console.ReadLine();
              Console.Write("CONFIRM PASSWORD: ");
              string confirmation = Console.ReadLine();
              if (password != confirmation)
              {
                Console.WriteLine("\nPASSWORDS DO NOT MATCH");
                continue;
              }
              user = library.Register(username, email, password);
              if (user == null)
              {
                Console.WriteLine("\nUserName already is use.  Please choose another.");
                continue;
              }
              confirmed = true;
              Console.WriteLine("\nYou have successfully registered.\n");
            }
            break;

          //LOGIN
          case "2":
            Console.Write("USERNAME: ");
            username = Console.ReadLine().ToLower();
            Console.Write("PASSWORD: ");
            password = Console.ReadLine();
            user = library.Login(username, password);
            if (user == null)
            {
              Console.WriteLine("\nINVALD CREDENTIALS\n");
            }
            else
            {
              Console.WriteLine("\nYou are logged in!\n");
            }
            break;
          //LOGOUT
          case "3":
            if (!user.LoggedIn)
            {
              Console.WriteLine("CANNOT LOG OUT -- YOU ARE NOT LOGGED IN.");
              continue;
            }
            library.Logout(user.UserName);
            Console.WriteLine("\nYOU ARE LOGGED OUT.");
            break;
          //EXIT APP
          case "4":
            playing = false;
            break;
          //INVALID OPTION
          default:
            Console.WriteLine("INVALID SELECTION.  PLEASE CHOOSE 1-4");
            break;
        }
      }
      Console.WriteLine("\nGOODBYE.");
    }
  }
}
