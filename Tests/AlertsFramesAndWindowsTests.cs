using NUnit.Framework;
using System;
using System.Threading;

namespace DemoQATests
{
    public class AlertsFramesAndWindowsTests : AlertsFramesAndWindowsPageObjects
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Navigate().GoToUrl("https://demoqa.com/browser-windows");
        }

        [Test]
        public void NewTabTest()
        {
            NewTabButton.Click();
            SwitchToNewTab();
            Assert.AreEqual("This is a sample page", Heading.Text);
            CloseTab();
        }

        //Test is flaky, need to investigate further. Perhaps wait for window handle?
        [Test]
        public void NewWindowTest()
        {
            NewWindowButton.Click();
            SwitchToNewTab();
            Assert.AreEqual("This is a sample page", Heading.Text);
            CloseTab();
        }

        //To do, can switch to the new window, but verifying the text is proving difficult
        //[Test]
        public void NewMessageTest()
        {
            MessageWindowButton.Click();
            SwitchToNewTab();
            var text = driver.PageSource;
            Assert.AreEqual("Knowledge increases by sharing but not by saving. Please share this website with your friends and in your organization.", FrameBody.Text);
            CloseTab();
        }

        [Test]
        public void AlertTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            AlertButton.Click();
            Assert.AreEqual("You clicked a button", driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();
        }

        //To do, the sleep here is to handle the feature. Ideally after sleeping the thread,
        // the test should behave same as AlertTest, but this is not the case
        //[Test]
        public void DelayedAlertTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            DelayedAlertButton.Click();
            Thread.Sleep(5000);
            Assert.AreEqual("This alert appeared after 5 seconds", driver.SwitchTo().Alert().Text);
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void ConfirmAlertTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            ConfirmAlertButton.Click();
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void DismissAlertTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            ConfirmAlertButton.Click();
            WaitForAlert();
            driver.SwitchTo().Alert().Dismiss();
            Assert.AreEqual("You selected Cancel", ConfirmResult.Text);
        }

        [Test]
        public void PromptAlertTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            PromptAlertButton.Click();
            SendName("Ted Nawmpson");

            Assert.AreEqual("You entered Ted Nawmpson", PromptResult.Text);
        }

        [Test]
        public void FrameFirstTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/frames");
            driver.SwitchTo().Frame("frame1");
            Assert.AreEqual("This is a sample page", FrameHeading.Text);
        }

        [Test]
        public void FrameSecondTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/frames");
            driver.SwitchTo().Frame("frame2");
            Assert.AreEqual("This is a sample page", FrameHeading.Text);
        }

        //To Do
        [Test]
        public void FrameNestedTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/nestedframes");
            driver.SwitchTo().Frame(1);
            Assert.IsTrue(FrameBody.Text.Contains("Parent frame"));
            driver.SwitchTo().Frame(0);
            Assert.IsTrue(FrameBody.Text.Contains("Child Iframe"));
        }

        [Test]
        public void ShowSmallModalTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");
            ShowSmallModal.Click();
            Assert.IsTrue(ModalBody.Text.Contains("This is a small modal. It has very less content"));
            CloseSmallModal.Click();
        }

        [Test]
        public void ShowLargeModalTest()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/modal-dialogs");
            ShowLargeModal.Click();
            Assert.IsTrue(ModalBody.Text.Contains("Lorem Ipsum is simply dummy text of the printing and typesetting industry"));
            CloseLargeModal.Click();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}