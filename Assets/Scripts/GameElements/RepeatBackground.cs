using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour 
{
#region Variables	
	private BoxCollider2D mCollider;
	private float mHorizontalLength;
#endregion

#region Monobehaviour functions
	private void Start () 
	{
		mCollider =GetComponent<BoxCollider2D>();
		mHorizontalLength = mCollider.size.x;
	}

	private void Update () 
	{
		if(transform.position.x < - mHorizontalLength)
			Reposition();
	}
#endregion

	private void Reposition()
	{
		Vector2 groundOffSet = new Vector2(mHorizontalLength * 2.0f, 0);
		transform.position = (Vector2)transform.position + groundOffSet;
	}
}
