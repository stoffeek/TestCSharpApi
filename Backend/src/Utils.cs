using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System.Dynamic;

namespace WebApp;
public static class Utils
{
    public static bool IsPasswordStrongEnough(string password)
    {
        // Kontrollera att lösenordet är minst 8 tecken långt
        if (password.Length < 8)
            return false;

        // Kontrollera att lösenordet innehåller liten bokstav
        if (!Regex.IsMatch(password, @"[a-z]"))
            return false;

        // Kontrollera att lösenordet innehåller stor bokstav
        if (!Regex.IsMatch(password, @"[A-Z]"))
            return false;

        // Kontrollera att lösenordet innehåller en siffra
        if (!Regex.IsMatch(password, @"\d"))
            return false;

        // Kontrollera att lösenordet innehåller ett specialtecken
        if (!Regex.IsMatch(password, @"[^a-zA-Z\d]"))
            return false;

        return true;

    }
    public static HashSet<string> BadWords { get;private set; }

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
            var badwordz = new Regex("\\b" + Regex.Escape(word) + "\\b", RegexOptions.IgnoreCase);
            input = badwordz.Replace(input, replacement);
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
                user["id"] = result["id"];
                successFullyWrittenUsers.Push(user);
            }
        }
        return successFullyWrittenUsers;
    }

     public static dynamic CountDomainsFromUserEmails(Func<string, List<dynamic>> sqlQuery)
    {
        // Hämta alla användare från databasen
        var usersInDb = sqlQuery("SELECT email FROM users");
        Console.WriteLine("Fetched users from database:");
        foreach (var user in usersInDb)
        {
            Console.WriteLine(user.email);
        }

        // Skapa en dictionary för att lagra domänräkningen
        var domainCount = new Dictionary<string, int>();

        foreach (var user in usersInDb)
        {
            string email = user.email;
            Console.WriteLine($"Processing email: {email}");

            // Extrahera domänen från e-postadressen
            var domain = email.Split('@')[1];
            Console.WriteLine($"Extracted domain: {domain}");

            // Om domänen redan finns i dictionaryn, öka räknaren, annars sätt räknaren till 1
            if (domainCount.ContainsKey(domain))
            {
                domainCount[domain]++;
            }
            else
            {
                domainCount[domain] = 1;
            }

            Console.WriteLine($"Updated domain count: {domain} = {domainCount[domain]}");
        }

        Console.WriteLine("Final domain counts:");
        foreach (var kvp in domainCount)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        // Konvertera dictionary till dynamiskt objekt (ExpandoObject)
        dynamic result = new ExpandoObject();
        var resultDict = (IDictionary<string, object>)result;
        foreach (var kvp in domainCount)
        {
            resultDict[kvp.Key] = kvp.Value;
        }

        return result;
    }    public static Arr RemoveMockUsers()
    {
        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        Arr successfullyRemovedUsers = Arr();

        foreach (var user in mockUsers)
        {
            var result = SQLQueryOne(
                @"DELETE FROM users WHERE email = $email RETURNING *",
                new { email = user.email }
            );

            // If the user was successfully removed, add to the list
            if (!result.HasKey("error"))
            {
                successfullyRemovedUsers.Push(user);
            }
        }

        return successfullyRemovedUsers;
    }



}



