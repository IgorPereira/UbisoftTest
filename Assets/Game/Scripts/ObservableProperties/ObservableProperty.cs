using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ObservableProperty<T> where T : IEquatable<T>
{
	public event Action OnPropertyChanged;
	public event Action<T> OnPropertyChangedWithValue;

	private T _value;
	public T Value
	{
		get { return _value; }
		set
		{
			if (!_value.Equals(value))
			{
				_value = value;

				OnPropertyChanged?.Invoke();
				OnPropertyChangedWithValue?.Invoke(_value);
			}
		}
	}

	public ObservableProperty(T startValue)
	{
		_value = startValue;
	}

	public ObservableProperty()
	{
		_value = default;
	}
}