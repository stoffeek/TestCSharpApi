

namespace WebApp;
    public class UtilsTest(Xlog Console)
    {
        // The following lines are needed to get 
        // output to the Console to work in xUnit tests!
        // (also needs the using Xunit.Abstractions)
        // Note: You need to use the following command line command 
        // dotnet test --logger "console;verbosity=detailed"
        // for the logging to work

        [Theory]
        [InlineData("")]            //Too short/empty
        [InlineData("Va123!")]     // Too short
        [InlineData("Valid1234")]  // Without special character
        [InlineData("valid123!")]  // Without upper case
        [InlineData("VALID123!")]  // Without lower case    
        [InlineData("Validaaaa!")] // Without digit       
        public void PassIsNotStrongEnough(string toTest)
        {
            // Testar ett ogiltigt lösenord (för kort)
            bool result = Utils.IsPasswordStrongEnough(toTest);
            Assert.False(result, "Lösenordet är inte tillräckligt starkt");
        }
    

        [Fact]
        public void FilteredBadwords()
        {
            Utils.LoadBadWords(Path.Combine("json", "badwords.json"));
           
            string text = "This is sum text with anus and maybe asshole";
            string expectedCensoredText = "This is sum text with *** and maybe ***";  // Säkerställ att detta är korrekt
            string actualCensoredText = Utils.RemoveBadWord(text,"***");

            Console.WriteLine("Orginal text -" + text);
            Console.WriteLine("Censored text - " + actualCensoredText);
            Console.WriteLine("Expected outcome - " + expectedCensoredText);

            Assert.Equal(expectedCensoredText, actualCensoredText);

        }

    [Fact]
    // A simple initial example
    public void TestSumInt()
    {
        Assert.Equal(12, Utils.SumInts(7, 5));
        Assert.Equal(-3, Utils.SumInts(6, -9));
    }

    [Fact]
    public void TestCreateMockUsers()
    {
        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);
        // Get all users from the database
        Arr usersInDb = SQLQuery("SELECT email FROM users");
        Arr emailsInDb = usersInDb.Map(user => user.email);
        // Only keep the mock users not already in db
        Arr mockUsersNotInDb = mockUsers.Filter(
            mockUser => !emailsInDb.Contains(mockUser.email)
        );
        // Get the result of running the method in our code
        var result = Utils.CreateMockUsers();
        // Assert that the CreateMockUsers only return
        // newly created users in the db
        Console.WriteLine($"The test expected that {mockUsersNotInDb.Length} users should be added.");
        Console.WriteLine($"And {result.Length} users were added.");
        Console.WriteLine("The test also asserts that the users added " +
            "are equivalent (the same) to the expected users!");
        Assert.Equivalent(mockUsersNotInDb, result);
        Console.WriteLine("The test passedds!");
    }

 
       [Fact]
    public void TestCountDomainsFromUserEmails()
    {
        // Mock data setup: skapa en lista med användare med olika e-postdomäner
        var mockUsers = new List<dynamic>
        {
            new { email = "user1@example.com" },
            new { email = "user2@example.com" },
            new { email = "user3@test.com" },
            new { email = "user4@test.com" },
            new { email = "user5@test.com" }
        };

        // Mock SQLQuery metoden
        Func<string, List<dynamic>> mockSqlQuery = (string sql) => {
            Console.WriteLine($"Executing SQL: {sql}");
            return mockUsers;
        };

        // Använd den mockade SQLQuery i stället för den verkliga
        var result = Utils.CountDomainsFromUserEmails(mockSqlQuery);

        // Förväntat resultat
        var expected = new Dictionary<string, int>
        {
            { "example.com", 2 },
            { "test.com", 3 }
        };

        // Jämför resultatet med det förväntade resultatet
        Assert.Equal(expected, result);
        Console.WriteLine("Test passed. The domain counts are as expected.");
    }

    [Fact]
    public void TestRemoveMockUsers()
    {
        // Create mock users first to ensure there are users to remove
        Utils.CreateMockUsers();

        // Read all mock users from the JSON file
        var read = File.ReadAllText(FilePath("json", "mock-users.json"));
        Arr mockUsers = JSON.Parse(read);

        // Remove mock users
        var result = Utils.RemoveMockUsers();

        // Assert that the RemoveMockUsers method only returns users that were in the mock file
        Console.WriteLine($"The test expected that {mockUsers.Length} users should be removed.");
        Console.WriteLine($"And {result.Length} users were removed.");
        Console.WriteLine("The test also asserts that the users removed " +
            "are equivalent (the same) to the expected users!");

        Assert.Equivalent(mockUsers, result);
        Console.WriteLine("The test passed!");
    }
}


 