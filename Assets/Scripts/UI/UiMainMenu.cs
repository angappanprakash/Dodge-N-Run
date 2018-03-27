using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiMainMenu : MonoBehaviour 
{
#region Variables
	[SerializeField]
	private Button                	m_BtnPlay;
	[SerializeField]
	private Button                	m_BtnQuit;
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
	}

	private void Update()
	{
	}
#endregion

#region Class specific functions
	public void OnClickPlay()
	{
		SceneManager.LoadScene("Game");
	}

	public void OnClickQuit()
	{
		Application.Quit();
	}
#endregion
}