using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum PlayerState
{
	SPAWN = 0,
	IDLE,
	RUNNING,
	JUMP,
	DEAD,
	NONE = -1
}

public class PlayerController : MonoBehaviour
{
#region Variables
	private const float JUMP_FORCE_MULITPLIER = 50.0f;
	[SerializeField]
	private float 		mJumpForce = 0;

	private PlayerState mCurrentState;
	private PlayerState mPrevState;
	private Rigidbody2D	mRigidBody;
	private PlayerData 	mPlayerData;
	private Animator	mAnimator;
	private float 		mStateTimer = 0;
	private bool		mIsGrounded = true;
	private bool 		mIsGameStarted;
#endregion

#region Properties
	public PlayerState pCurrentState
	{
		get { return mCurrentState; }
	}

	public Rigidbody2D pRigidBody
	{
		get { return mRigidBody; }
	}

	public PlayerData pPlayerData
	{
		get { return mPlayerData; }
	}
#endregion

#region Monobehaviour functions
	private void Awake()
	{
		mRigidBody = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		mIsGrounded = false;
		mCurrentState = PlayerState.SPAWN;
		mPrevState = PlayerState.NONE;
		mIsGameStarted = false;
		mAnimator = GetComponentInChildren<Animator>();
		if(mAnimator == null)
			Debug.LogError("Cannot find Animator component");

	}

	private void OnEnable()
	{
		mCurrentState = PlayerState.SPAWN;
		mPrevState = PlayerState.NONE;
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
		//Debug.Log("player id:"+m_PlayerIndex + " lifetime: " +m_Timer);
		ProcessMovement();
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Ground")
			mIsGrounded = true;
	}

	private void OnCollisionStay2D(Collision2D other)
	{
		if(other.gameObject.tag == "Ground")
			mIsGrounded = true;
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Ground")
			mIsGrounded = false;
	}

	private void OnDestroy()
	{
	}
#endregion

#region Class specific functions
	public void Init(PlayerData playerData)
	{
		mPlayerData = playerData;
	}

	private void ProcessMovement()
	{
		if(mCurrentState != PlayerState.DEAD && mIsGrounded)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(mIsGameStarted)
				{
					SetState(PlayerState.JUMP);
					mRigidBody.AddForce(Vector2.up * (mJumpForce * mRigidBody.mass * JUMP_FORCE_MULITPLIER));
				}
				else
				{
					mIsGameStarted = true;
					LevelManager.Instance.StartGame();
					SetState(PlayerState.RUNNING);
				}
			}
		}

		ProcessState();
	}

	public void SetState(PlayerState state)
	{
		if (mCurrentState == state)
			return;

		mPrevState = mCurrentState;
		mCurrentState = state;

		switch (mCurrentState)
		{
		case PlayerState.IDLE:
			mRigidBody.velocity = Vector3.zero;
			break;
		case PlayerState.RUNNING:
			break;
		case PlayerState.JUMP:
			mAnimator.SetBool("Run", false);
			mAnimator.SetTrigger("Jump");
			break;
		case PlayerState.DEAD:
			mRigidBody.velocity = Vector3.zero;
			mAnimator.SetBool("Run", false);
			mAnimator.SetTrigger("Fall");
			break;
		default:
			break;
		}
	}

	private void ProcessState()
	{
		mStateTimer = Mathf.Max(0, mStateTimer - Time.deltaTime);

		switch (mCurrentState)
		{
		case PlayerState.IDLE:
			mAnimator.SetBool("Idle", true);
			break;
		case PlayerState.RUNNING:
			mAnimator.SetBool("Run", true);
			break;
		case PlayerState.JUMP:
			mAnimator.SetBool("Run", false);
			break;
		default:
			break;
		}
	}

	public bool CanProcessState(PlayerState state)
	{
		bool canProcess = false;
		switch (state)
		{
		case PlayerState.RUNNING:
			canProcess = (mCurrentState == PlayerState.IDLE && mCurrentState != PlayerState.DEAD && mCurrentState != PlayerState.JUMP);
			break;
		}

		return canProcess;
	}
#endregion
}