using OpenQA.Selenium;

namespace AutoCookies.Pages
{
    public class ChangeLanguageModal : BaseElement
    {
        public ChangeLanguageModal(IWebDriver driver) : base(driver, By.Id("promptContentChangeLanguage"))
        {
        }

        public BaseElement EnglishElement => new(this, By.Id("langSelect-EN"));
        
    }
}
