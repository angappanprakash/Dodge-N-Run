using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManagerDelegates
{
	public delegate void OnSfxStarts(AudioSource audioSource);
}

public class AudioManager : MonoBehaviour
{
	#region Variables
	public static event AudioManagerDelegates.OnSfxStarts   _onSfxStarted;

	public AudioSource          _bgMusicChannel;
	public AudioClip            _bgInGame;
	public List<AudioSource>    _sfxChannels;

	private const float         mMusicFadeSpeed = 2.0f;
	private float               mBgVolume;
	private static AudioManager	mInstance;
	#endregion

	#region Properties
	public static AudioManager pInstance
	{
		get { return mInstance; }
	}
	#endregion

	#region Monobehaviour functions
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	private void OnDestroy()
	{
		mInstance = null;
	}
	#endregion

	#region Class specific functions
	public void Init()
	{
		mInstance = this;
		UpdateSFXVolume(PlayerData.pInstance.pSFXVolume);
		UpdateMusicVolume(PlayerData.pInstance.pMusicVolume);
	}

	public void PlayInGameBGM()
	{
		_bgMusicChannel.clip = _bgInGame;

		_bgMusicChannel.Play();
	}

	private void Update()
	{
		if (_bgMusicChannel.isPlaying)
		{
			if (_bgMusicChannel.volume < mBgVolume)
			{
				_bgMusicChannel.volume += Time.deltaTime * mMusicFadeSpeed;
			}
			else
			{
				_bgMusicChannel.volume = mBgVolume;
			}
		}
	}

	public void PlaySound(AudioClip clip, bool isLoop = false)
	{
		for (int i = 0; i < _sfxChannels.Count; i++)
		{
			if (!_sfxChannels[i].isPlaying)
			{
				_sfxChannels[i].clip = clip;
				_sfxChannels[i].loop = isLoop;
				_sfxChannels[i].Play();
				if (_onSfxStarted != null && _sfxChannels[i].loop == true)
				{
					_onSfxStarted(_sfxChannels[i]);
				}
				break;
			}
		}
	}

	public void StopChannel(AudioSource audioSource)
	{
		if (audioSource != null)
		{
			audioSource.Stop();
		}
	}

	public void UpdateMusicVolume(float volume)
	{   
		volume = volume > 0? 1: 0;

		//TEMP FIX: reducing the volume of bgm since we couldnt hear sfx's clearly.
		_bgMusicChannel.volume = volume/1.5f;
		mBgVolume = _bgMusicChannel.volume;
	}

	public void UpdateSFXVolume(float volume)
	{
		volume = volume > 0? 1: 0;
		for (int i = 0; i < _sfxChannels.Count; i++)
		{
			_sfxChannels[i].volume = volume;
		}
	}

	public void ResetAudio()
	{
		if(_bgMusicChannel.isPlaying)
			_bgMusicChannel.clip = null;
		for (int i = 0; i < _sfxChannels.Count; i++)
		{
			if(_sfxChannels[i].isPlaying)
				_sfxChannels[i].clip = null;
		}
	}
	#endregion
}
