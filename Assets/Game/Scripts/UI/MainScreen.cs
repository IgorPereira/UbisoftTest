using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour
{
    [SerializeField]
    StringTextObserver currentValueObserver;
    [SerializeField]
    TMP_InputField newValueInput;

    [SerializeField]
    Button saveBtn;
    [SerializeField]
    Button loadBtn;
    [SerializeField]
    Button resetBtn;

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