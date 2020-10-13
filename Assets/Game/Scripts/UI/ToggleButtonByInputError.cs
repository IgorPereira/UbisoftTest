using UnityEngine;
using UnityEngine.UI;

namespace UbisoftTest
{
	[RequireComponent(typeof(Button))]
	public class ToggleButtonByInputError : MonoBehaviour
	{
		[SerializeField]
		private ParametrizedInputField parametrizedInputField;

		private Button btn;

		private void OnValidate()
		{
			btn = GetComponent<Button>();
		}

		private void Awake()
		{
			parametrizedInputField.InputState.OnPropertyChangedWithValue += OnStateChangedHandler;
		}

		private void OnStateChangedHandler(INPUT_FIELD_STATES state)
		{
			btn.interactable = state == INPUT_FIELD_STATES.NONE;
		}
	}
}