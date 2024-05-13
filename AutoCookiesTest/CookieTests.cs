using AutoCookies.Utilities;
using NUnit.Framework;

namespace AutoCookiesTest
{
    public class CookieTests : BaseTest
    {
        [TestCase(null)]
        [TestCase("Default")]
        public void Can_Click_Cookie(string? userProfile)
        {
            var page = Start(userProfile);

            //If we're not using a profile that's been used before the language modal should display
            if (userProfile is null)
                page.ChangeLanguageModal.EnglishElement.Click();

            page.CookiesTitle.WaitForDisplayed();
            Assert.That(page.CookiesTitle.Count, Is.EqualTo(0));

            page.BigCookie.Click();

            page.CookiesTitle.WaitFor(c => c.Count.Equals(1));
            Assert.That(page.CookiesTitle.Count, Is.EqualTo(1));
        }

        [TestCase("Default")]
		public void Can_Buy_Store_Products(string userProfile)
        {
	        var page = Start(userProfile);

            //Click the cookie until we can buy an upgrade
            var product = page.Store.Products[0];
	        while (!product.CanBuy)
	        {
                page.BigCookie.Click();
	        }

            //Click to buy the product and ensure it increases in value
            var initialValue = product.Owned;
            product.Click();
            Assert.That(product.Owned, Is.EqualTo(initialValue + 1));
        }

		[TestCase("Default")]
		public void Can_Buy_Store_Upgrades(string userProfile)
		{
			var page = Start(userProfile);

            //Click the cookie and buy products until an upgrade is available
            var upgrade = page.Store.Upgrades[0];
			while (!upgrade.CanBuy)
			{
                page.BigCookie.Click();
                page.Store.Products.FirstOrDefault(p => p.CanBuy)?.Click();
			}

			var intialId = upgrade.UniqueId;
            upgrade.Click();
            Assert.That(upgrade.UniqueId, Is.Not.EqualTo(intialId));
		}
    }
}