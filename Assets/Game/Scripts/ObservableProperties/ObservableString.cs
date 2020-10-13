using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableString : ObservableProperty<string>
{
	public ObservableString(string startValue) : base(startValue)
	{

	}
}