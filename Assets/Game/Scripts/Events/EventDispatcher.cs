using System;
using System.Collections.Generic;
using System.Linq;

namespace UbisoftTest
{
	public class EventDispatcher<TType, TParams>
		where TType : struct, IConvertible, IComparable, IFormattable
		where TParams : EventArgs
	{
		public delegate void OnEventDispatched(TParams e);
		public static Dictionary<TType, OnEventDispatched> eventsPerType = new Dictionary<TType, OnEventDispatched>();

		public static void AddListener(OnEventDispatched eventListener, TType type)
		{
			if (eventsPerType.ContainsKey(type) && HasListener(eventListener, type))
			{
				eventsPerType[type] += eventListener;
			}
			else
			{
				eventsPerType.Add(type, eventListener);
			}
		}

		private static bool HasListener(OnEventDispatched eventListener, TType type)
		{
			Delegate[] invocationList = eventsPerType[type].GetInvocationList();
			Delegate existing = invocationList.First(listener => listener == (Delegate)eventListener);

			return existing != null;
		}

		public static void RemoveListener(OnEventDispatched eventListener, TType type)
		{
			if (eventsPerType.TryGetValue(type, out OnEventDispatched notification))
			{
				notification -= eventListener;
			}
		}

		public static void RaiseEvent(TType type, TParams args)
		{
			if (eventsPerType.TryGetValue(type, out OnEventDispatched notification))
			{
				notification.Invoke(args);
			}
		}
	}
}