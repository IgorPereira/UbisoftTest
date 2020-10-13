using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

namespace UbisoftTest
{
	[Flags]
	public enum INPUT_FIELD_STATES
	{
		NONE = 0,
		OVERFLOW = 1,
		INVALID = 2
	}

	[RequireComponent(typeof(TMP_InputField))]
	public class ParametrizedInputField : MonoBehaviour
	{
		[SerializeField]
		private int maxLength = 16;
		[SerializeField]
		private string invalidCharacters = "!;:";

		private string regexPattern;

		private TMP_InputField inputField;

		public ObservableProperty<INPUT_FIELD_STATES> InputState { get; private set; }

		private void OnValidate()
		{
			inputField = this.GetComponent<TMP_InputField>();
			InputState = new ObservableProperty<INPUT_FIELD_STATES>();
		}

		private void Awake()
		{
			inputField.onValueChanged.AddListener(OnValueChangedHandler);

			regexPattern = string.Format(@"[{0}]", invalidCharacters);
		}

		private void OnValueChangedHandler(string newValue)
		{
			INPUT_FIELD_STATES newState = InputState.Value;
			newState = CheckForOverflow(newValue, newState);
			newState = CheckForInvalid(newValue, newState);

			if (newState != InputState.Value)
			{
				InputState.Value = newState;
			}
		}

		private INPUT_FIELD_STATES CheckForOverflow(string newValue, INPUT_FIELD_STATES state)
		{
			if (newValue.Length > maxLength)
				state |= INPUT_FIELD_STATES.OVERFLOW;
			else
				state &= ~INPUT_FIELD_STATES.OVERFLOW;

			return state;
		}

		private INPUT_FIELD_STATES CheckForInvalid(string newValue, INPUT_FIELD_STATES state)
		{
			bool hasInvalid = Regex.IsMatch(newValue, regexPattern);

			if (hasInvalid)
				state |= INPUT_FIELD_STATES.INVALID;
			else
				state &= ~INPUT_FIELD_STATES.INVALID;

			return state;
		}

	}
}