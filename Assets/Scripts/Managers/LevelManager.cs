using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManagerDelegates
{
	public delegate void OnScoreUpdate();
	public delegate void OnGameStarted();
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
	public static event LevelManagerDelegates.OnScoreUpdate	_onGameStarted;

	[SerializeField]
	private GameObject				mPauseMenu;
	[SerializeField]
	private GameObject				mFadeOutUI;
	[SerializeField]
	private GameObject				mTapToStartUI;

	[SerializeField]
	private List<PlayerController> 	mPlayersList;
	private GameState				mCurrentGameState;
	private int						mGameTimer;
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
#endregion

	#region Monobehaviour functions
	private void Awake()
	{
		mInstance = this;
	}

	private void Start()
	{
		ShowPauseMenu(false);
		mFadeOutUI.gameObject.SetActive(false);
		mTapToStartUI.gameObject.SetActive(true);
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
		if(_onGameStarted != null)
			_onGameStarted();
		mTapToStartUI.gameObject.SetActive(false);
		InvokeRepeating ("Countdown", 1.0f, 1.0f);
	}

	public void EndGame()
	{
		mCurrentGameState = GameState.ENDED;
		if(_onScoreUpdate != null)
			_onScoreUpdate();

		mFadeOutUI.gameObject.SetActive(true);
		PlayerData.pInstance.UpdateHighScore(mGameTimer);
		StartCoroutine("GameOverAfterDelay");
	}


	IEnumerator GameOverAfterDelay()
	{
		yield return new WaitForSeconds(2.0f);

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
		PlayerData.pInstance.pScore = mGameTimer;
		if (pCurrentGameState == GameState.ENDED)
			CancelInvoke ("Countdown");
	}

	#endregion
}