using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHUD : MonoBehaviour 
{
	[SerializeField]
	private Text			m_TxtScore;
	[SerializeField]
	private Button  		m_BtnPause;

	// Use this for initialization
	void Start () 
	{
	}

	void OnEnable()
	{
		LevelManager._onScoreUpdate += LevelManager__onScoreUpdate;
	}

	void LevelManager__onScoreUpdate ()
	{
		m_TxtScore.text = LevelManager.Instance.pGameTimer.ToString();
	}

	void OnDisable()
	{
		LevelManager._onScoreUpdate -= LevelManager__onScoreUpdate;
	}

	private void OnScoreUpdate(PlayerEventParams eventArgs)
	{
		ScoreUpdateEventArgs scoreUpdateEventParams = (ScoreUpdateEventArgs)eventArgs;
		int score = scoreUpdateEventParams.NewScore;
		m_TxtScore.text = score.ToString();
	}

	public void OnClickPause()
	{
		LevelManager.Instance.ShowPauseMenu(true);
	}
}
