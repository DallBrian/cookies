using AutoCookies.PageObjects;
using AutoCookies.Utilities;
using OpenQA.Selenium;

namespace AutoCookies.Pages
{
    public class MainCookiePage : IDisplayable
    {
        private readonly IWebDriver driver;

        public static MainCookiePage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Properties.Url);
            return new MainCookiePage(driver).WaitForDisplayed();
        }

        private MainCookiePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ChangeLanguageModal ChangeLanguageModal => new(driver);

        public BaseElement BigCookie => new(driver, By.Id("bigCookie"));

        public CookiesTitle CookiesTitle => new(driver);

        public BaseElement Shimmer => new(driver, By.ClassName("shimmer"));

        public BaseElement OptionsButton => new(driver, By.Id("prefsButton"));

        public Store Store => new(driver);

        public bool IsDisplayed()
        {
	        return BigCookie.IsDisplayed() && CookiesTitle.IsDisplayed();
        }
    }
}
