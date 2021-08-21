using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace DemoQATests
{
    public class PracticeFormTests : PracticeFormPageObjects
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            generateData.Generate();
            //generateData.GenerateNaughty();
        }

        [SetUp]
        public void Setup()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
            WaitForElementDisplayedById("firstName");
        }

        private int i = 0;

        [TestCaseSource(nameof(testCaseData), new object[] { })]
        public void FormSubmissionTest(UserData userData)
        {
            //arrange
            var firstName = userData.FirstName;
            var lastName = userData.LastName;
            var email = userData.Email;
            var address = userData.Address;
            var state = userData.State;
            var gender = userData.Gender;
            var mobileNumber = userData.MobileNumber;
            string phone = mobileNumber.ToString();
            phone = Regex.Replace(phone, @"[^0-9]", "");

            //act
            FirstName().SendKeys(firstName);
            LastName().SendKeys(lastName);
            ClickGenderRadioBtn(gender);
            Email().SendKeys(email);
            MobileNumber().SendKeys(phone);
            SendDateOfBirth();
            UploadPicture(imagePath);
            Address().SendKeys(address);
            SendStateDDL(state);
            SendCityDDL("City");
            SubmitBtn().Click();
            FindByClassName("modal-title").Click();

            string resultsName = Results()[0].ToString();
            string resultsEmail = Results()[1].ToString();
            string resultsPhone = Results()[3].ToString();
            string resultsAddress = Results()[8].ToString();

            //assert
            Assert.That(resultsName.Contains(firstName) && resultsName.Contains(lastName), "Name did not contain {0) and {1}", resultsName);
            Assert.That(resultsEmail.Contains(email), "Email did not match {0}", email);
            Assert.That(resultsPhone.Contains(phone), "Phone did not match {0}", phone);
            Assert.That(resultsAddress.Contains(address), "Address did not match {0)", address);
            driver.Navigate().Refresh();
            i++;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}