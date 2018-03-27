using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Collections;


public class GameManager : MonoBehaviour
{
#region Variables
	[SerializeField]
	private GameEventSystem 	mGameEventSystem;
	[SerializeField]
	private AudioManager        mAudioManager;
	[SerializeField]
	private UiPauseMenu 		mPauseMenu;

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

	public GameEventSystem pGameEventSystem
	{
		get	{ return mGameEventSystem; }
	}

	public static GameManager pInstance
	{
		get { return mInstance; }
	}
#endregion

#region Monobehaviour functions
	private void Awake()
	{
		mInstance = this;
		PlayerData.Init();
		mAudioManager.Init();
		mAudioManager.PlayInGameBGM();
		SceneManager.LoadScene("MainMenu");
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
		mInstance = null;
	}
#endregion

#region Class specific functions
#endregion
}
