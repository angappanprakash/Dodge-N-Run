using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour 
{
	[SerializeField]
	private int 		mPoolSize = 5;
	[SerializeField]
	private Obstacle 	mObstaclePrefab;
	[SerializeField]
	private float 		mSpawnInterval = 4.0f;

	private Obstacle[] 	mObstaclesList;
	private Vector2 	mSpawnPosition = new Vector2(-15.0f, -25.0f);
	private float 		mTimeSinceLastSpawned = 0;
	private float 		mSpawnXOffSet = 10.0f;
	private float 		mSpawnYOffSet = -3.0f;
	private int			mCurrentIndex = 0;

	// Use this for initialization
	void Start () 
	{
		mObstaclesList = new Obstacle[mPoolSize];

		for(int i = 0; i< mPoolSize; i++)
		{
			mObstaclesList[i] = Instantiate(mObstaclePrefab, mSpawnPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		mTimeSinceLastSpawned += Time.deltaTime;
		if(LevelManager.Instance.pCurrentGameState == GameState.IN_PROGRESS && mTimeSinceLastSpawned >= mSpawnInterval)
		{
			mTimeSinceLastSpawned = 0;
			mObstaclesList[mCurrentIndex].transform.position = new Vector2(mSpawnXOffSet, mSpawnYOffSet);
			mCurrentIndex++;
			if(mCurrentIndex >= mPoolSize)
				mCurrentIndex = 0;
		}
	}
}
