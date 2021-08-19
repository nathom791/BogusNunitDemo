using OpenQA.Selenium;

namespace DemoQATests
{
    public class AlertsFramesAndWindowsPageObjects : UtilityMethods
    {
        #region New Tabs

        public IWebElement NewTabButton => FindById("tabButton");
        public IWebElement NewWindowButton => FindById("windowButton");
        public IWebElement MessageWindowButton => FindById("messageWindowButton");
        public IWebElement Heading => FindById("sampleHeading");
        public IWebElement Body => FindByTagName("body");

        #endregion New Tabs

        #region Alerts

        public IWebElement AlertButton => FindById("alertButton");
        public IWebElement DelayedAlertButton => FindById("timerAlertButton");
        public IWebElement ConfirmAlertButton => FindById("confirmButton");
        public IWebElement PromptAlertButton => FindById("promtButton");
        public IWebElement ConfirmResult => FindById("confirmResult");
        public IWebElement PromptResult => FindById("promptResult");

        public void SendName(string name)
        {
            var alert = driver.SwitchTo().Alert();
            alert.SendKeys(name);
            alert.Accept();
        }

        #endregion Alerts

        #region iFrames

        public IWebElement FrameHeading => FindById("sampleHeading");
        public IWebElement FrameBody => FindByTagName("body");

        #endregion iFrames

        #region Modals

        public IWebElement ShowSmallModal => FindById("showSmallModal");
        public IWebElement ShowLargeModal => FindById("showLargeModal");
        public IWebElement CloseSmallModal => FindById("closeSmallModal");
        public IWebElement CloseLargeModal => FindById("closeLargeModal");
        public IWebElement ModalBody => FindByClassName("modal-body");

        #endregion Modals
    }
}