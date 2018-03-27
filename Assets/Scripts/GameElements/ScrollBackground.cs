using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
#region Variables
	[SerializeField]
	private float		mScrollSpeed;

	private Rigidbody2D mRigidbody2D;
#endregion

#region Monobehaviour functions
	private void OnEnable()
	{
		LevelManager._onGameStarted += LevelManager__onGameStarted;
	}

	private void OnDisable()
	{
		LevelManager._onGameStarted -= LevelManager__onGameStarted;
	}

	void LevelManager__onGameStarted ()
	{
		mRigidbody2D.velocity = new Vector2(mScrollSpeed, 0.0f);
	}

	void Start () 
	{
		mRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		if(LevelManager.Instance.pCurrentGameState == GameState.ENDED)
			mRigidbody2D.velocity = Vector2.zero;
	}
#endregion
}
