using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiPauseMenu: MonoBehaviour 
{
	#region Variable
	[SerializeField]
	private Button                	m_BtnResume;
	[SerializeField]
	private Button                	m_BtnMainMenu;
	#endregion

	#region Properties
	#endregion

	#region Class specific functions
	public void OnClickResume()
	{
		LevelManager.Instance.ShowPauseMenu(false);
	}

	public void OnClickMainMenu()
	{
		LevelManager.Instance.LoadMainMenu();
	}
	#endregion
}