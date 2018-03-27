using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData
{
#region Variables
	private float               mSFXVolume;
	private float               mMusicVolume;
	private bool                mFirstTimeLaunch;

	private const float         DEFAULT_SFX_VOLUME = 1.0f;
	private const float         DEFAULT_MUSIC_VOLUME = 1.0f;

	private const string        SFX_VOLUME_KEY = "SFXVolume";
	private const string        MUSIC_VOLUME_KEY = "MusicVolume";

	private const string        FIRST_TIME_LAUNCH = "FirstTimeLauched";
	private static PlayerData   mInstance;
#endregion

#region Properties
	public float pSFXVolume
	{
		get {   return mSFXVolume;  }
	}

	public float pMusicVolume
	{
		get { return mMusicVolume;  }
	}
	public bool pFirstTimeLaunch
	{
		get { return mFirstTimeLaunch; }
	}

	public static PlayerData pInstance
	{
		get { return mInstance; }
	}
#endregion

#region Class specific functions
	public static void Init()
	{
		mInstance = new PlayerData();
	}

	private PlayerData()
	{
		if (PlayerPrefs.HasKey(SFX_VOLUME_KEY))
		{
			mSFXVolume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY);
		}
		else
		{
			UpdateSFXVolume(DEFAULT_SFX_VOLUME);
		}

		if (PlayerPrefs.HasKey(MUSIC_VOLUME_KEY))
		{
			mMusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
		}
		else
		{
			UpdateMusicVolume(DEFAULT_MUSIC_VOLUME);
		}

		if (PlayerPrefs.HasKey(FIRST_TIME_LAUNCH))
		{
			mFirstTimeLaunch = (PlayerPrefs.GetInt(FIRST_TIME_LAUNCH) == 1) ? true : false ;
		}
		else
		{
			SetFirstTimeLauched(false);
		}
	}

	public void UpdateSFXVolume(float sfxVolume)
	{
		mSFXVolume = sfxVolume;
//		if(AudioManager.pInstance)
//			AudioManager.pInstance.UpdateSFXVolume(mSFXVolume);
		PlayerPrefs.SetFloat(SFX_VOLUME_KEY, mSFXVolume);
		PlayerPrefs.Save();
	}

	public void UpdateMusicVolume(float musicVolume)
	{
		mMusicVolume = musicVolume;
//		if(AudioManager.pInstance)
//			AudioManager.pInstance.UpdateMusicVolume(mMusicVolume);
		PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, mMusicVolume);
		PlayerPrefs.Save();
	}

	public void SetFirstTimeLauched(bool isFirstTimeLaunched)
	{
		mFirstTimeLaunch = isFirstTimeLaunched;
		PlayerPrefs.SetInt(FIRST_TIME_LAUNCH, mFirstTimeLaunch? 1 : 0);
		PlayerPrefs.Save();
	}
#endregion
}