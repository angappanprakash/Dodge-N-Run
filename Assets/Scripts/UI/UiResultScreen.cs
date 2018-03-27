using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiResultScreen: MonoBehaviour 
{
	#region Variables
	[SerializeField]
	private Text                	m_TxtHighScore;
	[SerializeField]
	private Text                	m_TxtScore;

	[SerializeField]
	private Button                	m_BtnRestart;
	[SerializeField]
	private Button                	m_BtnMainMenu;
	#endregion

	#region Properties
	#endregion

	#region Monobehaviour functions
	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
		m_TxtHighScore.text = PlayerData.pInstance.pHighScore.ToString();
		m_TxtScore.text = PlayerData.pInstance.pScore.ToString();
	}

	private void Update()
	{
	}
	#endregion

	#region Class specific functions
	public void OnClickRestart()
	{
		SceneManager.LoadScene("Game");
	}

	public void OnClickMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
	#endregion
}