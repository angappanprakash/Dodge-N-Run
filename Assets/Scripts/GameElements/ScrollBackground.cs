using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
#region Variables
	private Rigidbody2D mRigidbody2D;
	[SerializeField]
	private float		mScrollSpeed = -1.5f;
#endregion

#region Monobehaviour functions
	void Start () 
	{
		mRigidbody2D = GetComponent<Rigidbody2D>();
		mRigidbody2D.velocity = new Vector2(mScrollSpeed, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//stop when game over
		//mRigidbody2D.velocity = Vector2.zero;
	}
#endregion
}
