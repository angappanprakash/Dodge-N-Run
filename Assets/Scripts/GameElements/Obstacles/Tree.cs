using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Obstacle
{
#region Variables
#endregion

#region Properties
#endregion

#region Monobehaviour functions
	protected override void Awake()
	{
		base.Awake();
		mObstacleType = ObstalceType.TREE;
	}
#endregion

#region Class specific functions
#endregion
}
