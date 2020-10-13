using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleButtonByInputError : MonoBehaviour
{
	[SerializeField]
	ParametrizedInputField parametrizedInputField;

	Button btn;

	private void OnValidate()
	{
		btn = this.GetComponent<Button>();
	}

	private void Awake()
	{
		parametrizedInputField.OnStateChanged += OnStateChangedHandler;
	}

	private void OnStateChangedHandler(INPUT_FIELD_STATES state)
	{
		btn.interactable = state == INPUT_FIELD_STATES.NONE;
	}
}