using Bogus;
using Newtonsoft.Json;
using System.IO;

namespace DemoQATests
{
    public class GenerateTestData
    {
        private int count = 100;

        public void Generate()
        {
            var gender = new[] { "Male", "Female", "Other" };
            var state = new[] { "NCR", "Uttar Pradesh", "Haryana", "Rajasthan" };
            var testUsers = new Faker<UserData>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.MobileNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(u => u.Address, f => f.Address.StreetAddress())
                .RuleFor(u => u.Gender, f => f.PickRandom(gender))
                .RuleFor(u => u.State, f => f.PickRandom(state));

            var user = testUsers.Generate(count);

            string workingDirectory = Directory.GetCurrentDirectory();
            string filePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"/Resources/TestData.json";

            var json = JsonConvert.SerializeObject(user.ToArray());
            File.WriteAllText(filePath, json);
        }

        public void GenerateNaughty()
        {
            var gender = new[] { "Male", "Female", "Other" };
            var state = new[] { "NCR", "Uttar Pradesh", "Haryana", "Rajasthan" };
            var testUsers = new Faker<UserData>()
                .RuleFor(u => u.FirstName, f => f.Naughty().ScriptInjection())
                .RuleFor(u => u.LastName, f => f.Naughty().ScriptInjection())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.MobileNumber, f => f.Phone.PhoneNumberFormat())
                .RuleFor(u => u.Address, f => f.Address.StreetAddress())
                .RuleFor(u => u.Gender, f => f.PickRandom(gender))
                .RuleFor(u => u.State, f => f.PickRandom(state));

            var user = testUsers.Generate(count);

            string workingDirectory = Directory.GetCurrentDirectory();
            string filePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"/Resources/TestData.json";

            var json = JsonConvert.SerializeObject(user.ToArray());
            File.WriteAllText(filePath, json);
        }
    }
}