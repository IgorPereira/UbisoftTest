using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UbisoftTest
{
	public class MainScreen : MonoBehaviour
	{
		[SerializeField]
		private StringTextObserver currentValueObserver;
		[SerializeField]
		private TMP_InputField newValueInput;

		[SerializeField]
		private Button saveBtn;
		[SerializeField]
		private Button loadBtn;
		[SerializeField]
		private Button resetBtn;

		private void Awake()
		{
			currentValueObserver.ObservedProperty = GameSession.Instance.TextValue;

			saveBtn.onClick.AddListener(OnSaveBtnClickHandler);
			loadBtn.onClick.AddListener(OnLoadBtnClickHandler);
			resetBtn.onClick.AddListener(OnResetBtnClickHandler);
		}

		private void OnSaveBtnClickHandler()
		{
			GameSession.Instance.TextValue.Value = newValueInput.text;
			GameSession.Instance.SaveSession();
		}

		private void OnLoadBtnClickHandler()
		{
			GameSession.Instance.LoadSession();
		}

		private void OnResetBtnClickHandler()
		{
			//NOTE: In this case, since I did not get from the explanation if it should reset and save or just reset, I've added the option to autosave in the reset function
			GameSession.Instance.ResetSession(false);
		}
	}
}