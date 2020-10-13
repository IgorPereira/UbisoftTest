using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StringTextObserver : PropertyObserver<string>
{
	TextMeshProUGUI txtValue;

	private void OnValidate()
	{
		txtValue = this.GetComponent<TextMeshProUGUI>();
	}

	protected override void OnPropertyChangedWithValueHandler(string newValue)
	{
		base.OnPropertyChangedWithValueHandler(newValue);

		txtValue.text = newValue;
	}
}