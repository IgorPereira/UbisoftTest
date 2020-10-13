using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UbisoftTest
{
	public class ErrorMessagePanel : MonoBehaviour
	{
		private const string overflowTextError = "Your text is over the max length!";
		private const string invalidTextError = "Your text contains invalid characters!";

		[SerializeField]
		private ParametrizedInputField parametrizedInputField;

		[SerializeField]
		private Image errorIcon;
		[SerializeField]
		private TextMeshProUGUI errorText;

		private void Awake()
		{
			parametrizedInputField.InputState.OnPropertyChangedWithValue += OnStateChangedHandler;

			gameObject.SetActive(false);
		}

		private void OnStateChangedHandler(INPUT_FIELD_STATES newState)
		{
			bool hasError = newState != INPUT_FIELD_STATES.NONE;

			gameObject.SetActive(hasError);

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
}