using System.Collections.ObjectModel;
using System.Drawing;
using AutoCookies.Utilities;
using OpenQA.Selenium;

namespace AutoCookies.Pages
{
    public class BaseElement : IWebElement, IDisplayable
	{
		private readonly IWebDriver? driver;
		private readonly IWebElement? parent;
		private readonly By by;

		public BaseElement(IWebDriver driver, By by)
		{
			this.driver = driver;
			this.by = by;
		}

		public BaseElement(IWebElement parent, By by)
		{
			this.parent = parent;
			this.by = by;
		}

		public IWebElement? Element
		{
			get
			{
				IWebElement? _element = default;
				try
				{
					_element = driver?.FindElement(by) ?? parent?.FindElement(by);
				}
				catch (NoSuchElementException)
				{
					//ignore not found
				}

				return _element;
			}
		}

		public bool HasClass(string className)
		{
			try
			{
				return GetDomAttribute("class").Split(' ').Contains(className);
			}
			catch
			{
				return false;
			}
		}

		public void ClickIgnoreException()
		{
			try
			{
				Click();
			}
			catch
			{
				//ignore
			}
		}

		public bool IsDisplayed()
		{
			try
			{

				return Element?.Displayed ?? false;
			}
			catch
			{
				return false;
			}
		}

		#region IWebElement Implementation

		public IWebElement? FindElement(By by)
		{
			return Element?.FindElement(by) ?? default;
		}

		public ReadOnlyCollection<IWebElement> FindElements(By by)
		{
			return Element.FindElements(by);
		}

		public void Clear()
		{
			Element.Clear();
		}

		public void SendKeys(string text)
		{
			Element.SendKeys(text);
		}

		public void Submit()
		{
			Element.Submit();
		}

		public void Click()
		{
			Element.Click();
		}

		public string GetAttribute(string attributeName)
		{
			return Element.GetAttribute(attributeName);
		}

		public string GetDomAttribute(string attributeName)
		{
			return Element.GetDomAttribute(attributeName);
		}

		public string GetDomProperty(string propertyName)
		{
			return Element.GetDomProperty(propertyName);
		}

		public string GetCssValue(string propertyName)
		{
			return Element.GetCssValue(propertyName);
		}

		public ISearchContext GetShadowRoot()
		{
			return Element.GetShadowRoot();
		}

		public string TagName => Element.TagName;

		public string Text => Element.Text;

		public bool Enabled => Element.Enabled;

		public bool Selected => Element.Selected;

		public Point Location => Element.Location;

		public Size Size => Element.Size;

		public bool Displayed => Element?.Displayed ?? false;

		#endregion
	}
}