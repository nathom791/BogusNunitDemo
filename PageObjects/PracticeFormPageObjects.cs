using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.IO;

namespace DemoQATests
{
    public class PracticeFormPageObjects : UtilityMethods
    {
        public GenerateTestData generateData = new GenerateTestData();

        public static IEnumerable<UserData> testCaseData()
        {
            string workingDirectory = Directory.GetCurrentDirectory();
            string filePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + @"/Resources/";
            var data = File.ReadAllText(filePath + "TestData.json");
            var userData = JsonConvert.DeserializeObject<IEnumerable<UserData>>(data);
            return userData;
        }

        public IWebElement FirstName()
        {
            FindById("firstName").Clear();
            return FindById("firstName");
        }

        public IWebElement LastName() => FindById("lastName");

        public IWebElement Email() => FindById("userEmail");

        //public void ClickGenderRadioBtn(string gender) => driver.FindElement(By.XPath("//input[@value='Female']")).Click()

        public void ClickGenderRadioBtn(string gender)
        {
            if (gender == "Male")
            {
                jsClickById("gender-radio-1");
            }
            else if (gender == "Female")
            {
                jsClickById("gender-radio-2");
            }
            else
            {
                jsClickById("gender-radio-3");
            }
        }

        public IWebElement MobileNumber() => FindById("userNumber");

        // in format of "DD month YYYY"
        public void SendDateOfBirth(string dateOfBirth)
        {
            FindById("dateOfBirthInput").Click();
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Build().Perform();
            FindById("dateOfBirthInput").SendKeys(dateOfBirth);
            actions.SendKeys(Keys.Escape).Build().Perform();
        }

        public void SendSubjects(string subject)
        {
            FindById("subjectsInput").SendKeys(subject);
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
        }

        //1 - sports, 2 - reading, 3 - music
        public void ClickHobbyCheckbox(int hobbyEnum) => jsClickById("hobbies-checkbox-" + hobbyEnum);

        public void UploadPicture(string filePath) => FindById("uploadPicture").SendKeys(filePath);

        public IWebElement Address() => FindById("currentAddress");

        public void SendStateDDL(string state)
        {
            Actions actions = new Actions(driver);
            FindById("currentAddress").Click();
            actions.SendKeys(Keys.Tab).SendKeys(state).Build().Perform();
            actions.SendKeys(Keys.Tab).Build().Perform();
        }

        public void SendCityDDL(string city)
        {
            FindById("react-select-4-input").SendKeys(city);
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Tab).Build().Perform();
        }

        public IWebElement SubmitBtn() => FindById("submit");

        public IWebElement CloseBtn()
        {
            WaitForElementDisplayedByClassName("modal-dialog");
            return FindById("closeLargeModal");
        }

        public List<string> Results()
        {
            List<string> resultsList = new List<string>();
            for (int i = 1; i < 11; i++)
            {
                resultsList.Add(driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/table/tbody/tr[" + i + "]/td[2]")).Text);
            }
            return resultsList;
        }
    }
}