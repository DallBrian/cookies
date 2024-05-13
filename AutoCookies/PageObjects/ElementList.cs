using AutoCookies.Pages;
using System.Collections;

namespace AutoCookies.PageObjects
{
	public class ElementList<T> : IReadOnlyList<T> where T : BaseElement
	{
		private IReadOnlyList<T> _elements;

		public ElementList(int count, params object[] args)
		{
			var list = new List<T>();
			for (var i = 0; i <= count; i++)
			{
				var argsWithIndex = args.Append(i).ToArray();
				var t = Activator.CreateInstance(typeof(T), argsWithIndex) as T;
				list.Add(t);
			}

			_elements = list;
		}
		
		#region Implementation of IEnumerable

		public IEnumerator<T> GetEnumerator()
		{
			return _elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_elements).GetEnumerator();
		}

		#endregion

		#region Implementation of IReadOnlyCollection<out T>

		public int Count => _elements.Count;

		#endregion

		#region Implementation of IReadOnlyList<out T>

		public T this[int index] => _elements[index];

		#endregion
	}
}
