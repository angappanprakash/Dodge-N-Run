using UnityEngine;
using System.Collections;

public enum ObstalceType
{
	TREE = 0,
	WOODEN_LOG,
	ROCK,
	NONE = -1
}

public class Obstacle : MonoBehaviour
{
#region Variables
	protected ObstalceType mObstacleType;
#endregion

#region Properties
#endregion

#region Monobehaviour functions
	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			PlayerController player = collision.gameObject.GetComponent<PlayerController>();
			player.SetState(PlayerState.DEAD);
			//Destroy(gameObject);
		}
	}

	protected virtual void OnTriggerEnter2D(Collider2D collider)
	{
	}
#endregion

#region Class specific functions
#endregion
}
