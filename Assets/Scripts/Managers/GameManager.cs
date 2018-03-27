using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Collections;

public enum GameState
{
	MENU,
	PLAYING,
	PAUSED,
	GAME_OVER,
	NONE = -1
}

public class GameManager : MonoBehaviour
{
#region Variables
	public AudioManager         _audioManager;

	private LevelManager		mLevelManager;
	private GameState			mGameState;
	private static GameManager 	mInstance;
#endregion

#region Properties
	public GameState pGameState
	{
		get { return mGameState; }
	}

	public LevelManager pLevelManager
	{
		get { return mLevelManager; }
	}

	public static GameManager pInstance
	{
		get { return mInstance; }
	}
#endregion

#region Monobehaviour functions
	protected void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}

	protected void Start()
	{
		Application.targetFrameRate = 60;
		mGameState = GameState.MENU;
		PlayerData.Init();
	}

	protected void Update()
	{
		if(mInstance == null)
		{
			mInstance = this;
			Init();
		}
	}

	protected void OnDestroy()
	{
		mInstance = null;
	}

	private void OnApplicationQuit()
	{
		QuitGame();
	}
#endregion

#region Class specific functions
	private void Init()
	{
		_audioManager.Init();
	}

	public void StartGame()
	{
		Time.timeScale = 1;
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		mGameState = GameState.PAUSED;
		AudioListener.pause = true;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		mGameState = GameState.PLAYING;
		AudioListener.pause = false;
	}

	public void ResetCurrentLevel()
	{
		StartGame();
		AudioListener.pause = false;
	}

	public void QuitCurrentLevel()
	{
		Time.timeScale = 1;
		mGameState = GameState.MENU;
	}

	public void GameOver()
	{
		mGameState = GameState.GAME_OVER;
	}

	public void QuitGame()
	{
	}
#endregion
}
