using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManagerDelegates
{
	public delegate void OnScoreUpdate();
}

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
	public static event LevelManagerDelegates.OnScoreUpdate	_onScoreUpdate;

	[SerializeField]
	private GameObject				mPauseMenu;
	[SerializeField]
	private List<PlayerController> 	mPlayersList;
	private GameState				mCurrentGameState;
	private int						mGameTimer;
	private int						mScore;
	private int						mHighScore;
	private static LevelManager 	mInstance;
#endregion

	#region Properties
	public static LevelManager Instance
	{
		get { return mInstance; }
	}

	public List<PlayerController> pPlayersList
	{
		get { return mPlayersList; }
	}

	public GameState pCurrentGameState
	{
		get { return mCurrentGameState; }
	}

	public int pGameTimer
	{
		get { return mGameTimer; }
	}

	public int pScore
	{
		get { return mScore; }
	}

	public int pHighScore
	{
		get { return mHighScore; }
	}

#endregion

	#region Monobehaviour functions
	private void Awake()
	{
		mScore = 0;
		mHighScore = 0;

		mHighScore = PlayerData.pInstance.pHighScore;
		mInstance = this;
	}

	private void Start()
	{
		ShowPauseMenu(false);
	}

	private void OnDestroy()
	{
		mInstance = null;
	}
	#endregion

	#region Class specific functions
	public void StartGame()
	{
		Time.timeScale = 1;
		mCurrentGameState = GameState.IN_PROGRESS;
		InvokeRepeating ("Countdown", 1.0f, 1.0f);
	}

	public void EndGame()
	{
		mCurrentGameState = GameState.ENDED;
		if(_onScoreUpdate != null)
			_onScoreUpdate();

		PlayerData.pInstance.UpdateHighScore(mScore);
		SceneManager.LoadScene("ResultScreen");
	}

	public void ShowPauseMenu(bool flag)
	{
		if(flag)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		mPauseMenu.gameObject.SetActive(flag);
	}

	public void LoadMainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadGame()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Game");
	}

	private void Countdown () 
	{
		//Debug.Log("score:" + mGameTimer);
		if(_onScoreUpdate != null)
			_onScoreUpdate();

		mGameTimer += 1;
		mScore = mGameTimer;
		PlayerData.pInstance.pScore = mScore;
		if (pCurrentGameState == GameState.ENDED)
			CancelInvoke ("Countdown");
	}

	#endregion
}