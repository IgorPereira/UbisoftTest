using TMPro;
using UnityEngine;

namespace UbisoftTest
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class StringTextObserver : PropertyObserver<string>
	{
		private TextMeshProUGUI txtValue;

		private void OnValidate()
		{
			txtValue = GetComponent<TextMeshProUGUI>();
		}

		protected override void OnPropertyChangedWithValueHandler(string newValue)
		{
			base.OnPropertyChangedWithValueHandler(newValue);

			txtValue.text = newValue;
		}
	}
}