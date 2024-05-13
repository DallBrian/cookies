using AutoCookies.Pages;
using OpenQA.Selenium;

namespace AutoCookies.PageObjects
{
	public class Store : BaseElement
	{
		//Total number of products within the dom
		public static int TotalProducts = 19;

		public Store(IWebDriver driver) : base(driver, By.Id("store"))
		{
		}

		private BaseElement UpgradesContainer => new BaseElement(this, By.Id("upgrades"));

		public Upgrade FirstUpgrade => new(UpgradesContainer, 0);

		public IReadOnlyList<Upgrade> Upgrades => new ElementList<Upgrade>(1, UpgradesContainer);

		public IReadOnlyList<Product> Products => new ElementList<Product>(TotalProducts, this);
	}

	public class Upgrade : BaseElement
	{
		public Upgrade(IWebElement parent, int index) : base(parent, By.Id($"upgrade{index}"))
		{
		}

		public bool CanBuy => HasClass("enabled");

		public string UniqueId => GetAttribute("data-id");
	}

	public class Product : BaseElement
	{
		public Product(IWebElement parent, int index) : base(parent, By.Id($"product{index}"))
		{
		}

		private BaseElement OwnedElement => new(this, By.ClassName("owned"));

		public bool CanBuy => HasClass("enabled");

		public int Owned
		{
			get
			{
				var text = OwnedElement.Text;
				return string.IsNullOrEmpty(text) ? 0 : int.Parse(text);
			}
		}
	}
}
