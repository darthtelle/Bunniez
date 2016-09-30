using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIModalPanel : MonoBehaviour 
{
	[SerializeField]
	private Text m_QuestionText;

	[SerializeField]
	private Image m_IconImage;

	[SerializeField]
	private Button m_YesButton;

	[SerializeField]
	private Button m_NoButton;

	[SerializeField]
	private Button m_CancelButton;

	[SerializeField]
	private Button[] m_ButtonList;

	[SerializeField]
	private GameObject m_ModalPanelObject;


	// TODO: See how to use UnityActions https://unity3d.com/learn/tutorials/modules/intermediate/live-training-archive/modal-window
	// TODO: Make singleton.

	public void DisplayModalPanel(string questionString, UnityAction yesEvent, UnityAction noEvent, UnityAction cancelEvent)
	{
		m_ModalPanelObject.SetActive(true);

		m_YesButton.onClick.RemoveAllListeners();
		m_YesButton.onClick.AddListener(yesEvent);
		m_YesButton.onClick.AddListener(ClosePanel);

		m_NoButton.onClick.RemoveAllListeners();
		m_NoButton.onClick.AddListener(noEvent);
		m_NoButton.onClick.AddListener(ClosePanel);

		m_CancelButton.onClick.RemoveAllListeners();
		m_CancelButton.onClick.AddListener(cancelEvent);
		m_CancelButton.onClick.AddListener(ClosePanel);

		m_QuestionText.text = questionString;
		m_IconImage.gameObject.SetActive(false);
		m_YesButton.gameObject.SetActive(true);
		m_NoButton.gameObject.SetActive(true);
		m_CancelButton.gameObject.SetActive(true);
	}

	private void ClosePanel()
	{
		m_ModalPanelObject.SetActive(false);
	}
}
