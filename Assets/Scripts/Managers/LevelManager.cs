using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public enum GameState
{
	MENU,
	IN_PROGRESS,
	PAUSED,
	ENDED
}

public class LevelManager : MonoBehaviour
{
#region Variables
	[SerializeField]
	private GameObject				m_PauseMenu;
	[SerializeField]
	private List<PlayerController> 	m_PlayersList;
	private GameState				m_CurrentGameState;
	private float					m_GameTimer;
	private static LevelManager 	m_Instance;
#endregion

	#region Properties
	public static LevelManager Instance
	{
		get { return m_Instance; }
	}

	public List<PlayerController> pPlayersList
	{
		get { return m_PlayersList; }
	}

	public GameState pCurrentGameState
	{
		get { return m_CurrentGameState; }
	}
#endregion

	#region Monobehaviour functions
	private void Awake()
	{
		m_Instance = this;
		StartGame();
	}

	private void Start()
	{
		ShowPauseMenu(false);
		InvokeRepeating ("Countdown", 1.0f, 1.0f);
	}

	private void OnDestroy()
	{
		m_Instance = null;
	}
	#endregion

	#region Class specific functions
	public void StartGame()
	{
		Time.timeScale = 1;
		m_CurrentGameState = GameState.IN_PROGRESS;

		GameManager.pInstance.pGameEventSystem.TriggerEvent(GameEventsList.PlayerEvents.GAME_START, new GameStartEventArgs());
	}

	public void EndGame()
	{
		m_CurrentGameState = GameState.ENDED;
		GameManager.pInstance.pGameEventSystem.TriggerEvent(GameEventsList.PlayerEvents.GAME_END, new GameEndEventArgs());
		SceneManager.LoadScene("ResultScreen");
	}

	public void ShowPauseMenu(bool flag)
	{
		if(flag)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		m_PauseMenu.gameObject.SetActive(flag);
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	private void Countdown () 
	{
		Debug.Log("score:" + m_GameTimer);
		m_GameTimer += 1;
		if (pCurrentGameState == GameState.ENDED)
			CancelInvoke ("Countdown");
	}

	#endregion
}