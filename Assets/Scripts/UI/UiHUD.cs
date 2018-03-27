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
		GameManager.pInstance.pGameEventSystem.SubscribeEvent(GameEventsList.PlayerEvents.SCORE_UPDATE, OnScoreUpdate);
	}

	void OnDisable()
	{
		GameManager.pInstance.pGameEventSystem.UnsubscribeEvent(GameEventsList.PlayerEvents.SCORE_UPDATE, OnScoreUpdate);
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
