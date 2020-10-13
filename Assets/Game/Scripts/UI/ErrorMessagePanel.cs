using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessagePanel : MonoBehaviour
{
	const string overflowTextError = "Your text is over the max length!";
	const string invalidTextError = "Your text contains invalid characters!";

	[SerializeField]
	ParametrizedInputField parametrizedInputField;

	[SerializeField]
	Image errorIcon;
    [SerializeField]
    TextMeshProUGUI errorText;

	private void Awake()
	{
		parametrizedInputField.OnStateChanged += OnStateChangedHandler;

		this.gameObject.SetActive(false);
	}

	private void OnStateChangedHandler(INPUT_FIELD_STATES newState)
	{
		bool hasError = newState != INPUT_FIELD_STATES.NONE;

		this.gameObject.SetActive(hasError);

		if (hasError)
			ShowErrorTextByType(newState);
	}

	private void ShowErrorTextByType(INPUT_FIELD_STATES state)
	{
		StringBuilder builder = new StringBuilder();

		if ((state & INPUT_FIELD_STATES.OVERFLOW) == INPUT_FIELD_STATES.OVERFLOW)
			builder.AppendLine(overflowTextError);

		if ((state & INPUT_FIELD_STATES.INVALID) == INPUT_FIELD_STATES.INVALID)
			builder.AppendLine(invalidTextError);

		errorText.text = builder.ToString();
	}
}