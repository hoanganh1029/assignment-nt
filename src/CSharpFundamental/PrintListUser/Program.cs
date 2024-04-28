using System.Text;

namespace Sample;
class Program
{    
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Sample...");

        var allUsers = CreateListUser();

        Console.WriteLine("List of members who is Male");
        var usersIsMale = GetUserIsMale(allUsers);
        PrintUsers(usersIsMale);

        Console.WriteLine("List of members who is Male");
        var oldestUser = GetOldestUser(allUsers);
        PrintUser(oldestUser);

        /*
            TODO: Do something
        */

        Console.WriteLine("List of members by age");
        var (users2k, userGreaterThan2k, userLessThan2k) = GetUsersByAge(allUsers);
        PrintUsers(users2k);
        PrintUsers(userGreaterThan2k);
        PrintUsers(userLessThan2k);
    }
    
    static List<User> CreateListUser()
    {
        var user = new User{Name = "X", Age = 10};
        Console.WriteLine(user.Name);
        return new List<User>();
    }
    
    static List<User> GetUserIsMale(List<User> users){
        return default;
    }

    static User GetOldestUser(List<User> users){
        return default;
    }

    static List<User> GetUserWithFullName(List<User> users){
        return default;
    }

    static (List<User> users2k, List<User> userGreaterThan2k, List<User> userLessThan2k) GetUsersByAge(List<User> users){
        return (new List<User>(), new List<User>(), new List<User>());
    }

    static string PrintUsers(List<User> users){
        var s = new StringBuilder();
        if (users != null){
            foreach (User user in users){
                s.Append(PrintUser(user));
            }
        }        
        return s.ToString();
    }

    static string PrintUser(User user){
        return string.Empty;
    }
}
