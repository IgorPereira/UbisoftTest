using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

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
	public event Action<INPUT_FIELD_STATES> OnStateChanged;

	[SerializeField]
	int maxLength = 16;
	[SerializeField]
	string invalidCharacters = "!;:";

	string regexPattern;

    TMP_InputField inputField;

	INPUT_FIELD_STATES inputState;

	private void OnValidate()
	{
		inputField = this.GetComponent<TMP_InputField>();
	}

	private void Awake()
	{
		inputField.onValueChanged.AddListener(OnValueChangedHandler);

		regexPattern = string.Format(@"[{0}]",invalidCharacters);
	}

	private void OnValueChangedHandler(string newValue)
	{
		INPUT_FIELD_STATES newState = inputState;
		newState = CheckForOverflow(newValue, newState);
		newState = CheckForInvalid(newValue, newState);

		if (newState != inputState)
		{
			inputState = newState;
			OnStateChanged?.Invoke(inputState);
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
