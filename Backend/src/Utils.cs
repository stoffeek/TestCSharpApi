using Newtonsoft.Json;

namespace WebApp;
public static class Utils
{
    public static HashSet<string> BadWords { get;private set; }

    static Utils()
    {
        
        LoadBadWords(Path.Combine("json","badwords.json"));

    }

    public static void LoadBadWords(string filepath)
    {
        var BwReadingList = File.ReadAllText(filepath);
        var data = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(BwReadingList);
        BadWords = new HashSet<string>(data["badwords"], StringComparer.OrdinalIgnoreCase);
    }

    public static string RemoveBadWord(string input , string replacement)
    {
        foreach(var word in BadWords)
        {
            var regex = new Regex("\\b" + Regex.Escape(word) + "\\b", RegexOptions.IgnoreCase);
            input = regex.Replace(input, replacement);
        }
        return input;
    }

    public static int SumInts(int a, int b)
    {
        return a + b;
    }

    public static Arr CreateMockUsers()
    {
        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        Arr successFullyWrittenUsers = Arr();
        foreach (var user in mockUsers)
        {
           // user.password = "12345678";
            var result = SQLQueryOne(
                @"INSERT INTO users(firstName,lastName,email,password)
                VALUES($firstName, $lastName, $email, $password)
            ", user);
            // If we get an error from the DB then we haven't added
            // the mock users, if not we have so add to the successful list
            if (!result.HasKey("error"))
            {
                // The specification says return the user list without password
                user.Delete("password");
                successFullyWrittenUsers.Push(user);
            }
        }
        return successFullyWrittenUsers;
    }

    

}