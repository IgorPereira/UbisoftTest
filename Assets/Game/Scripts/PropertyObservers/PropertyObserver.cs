using System;
using UnityEngine;

namespace UbisoftTest
{
	public class PropertyObserver<T> : MonoBehaviour where T : IEquatable<T>
	{
		private ObservableProperty<T> observedProperty;
		public ObservableProperty<T> ObservedProperty
		{
			get { return observedProperty; }
			set
			{
				if (observedProperty == value) return;

				if (observedProperty != null)
				{
					observedProperty.OnPropertyChanged -= OnPropertyChangedHandler;
					observedProperty.OnPropertyChangedWithValue -= OnPropertyChangedWithValueHandler;
				}

				observedProperty = value;

				if (observedProperty != null)
				{
					observedProperty.OnPropertyChanged += OnPropertyChangedHandler;
					observedProperty.OnPropertyChangedWithValue += OnPropertyChangedWithValueHandler;

					OnPropertyChangedHandler();
					OnPropertyChangedWithValueHandler(observedProperty.Value);
				}
			}
		}

		protected virtual void OnPropertyChangedHandler() { }
		protected virtual void OnPropertyChangedWithValueHandler(T newValue) { }
	}
}