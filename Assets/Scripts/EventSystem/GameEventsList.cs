using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsList
{
    public enum PlayerEvents
    {
		GAME_START = 0,
		GAME_PAUSED,
		GAME_RESUMED,
		GAME_END,
		SCORE_UPDATE,
        DEAD_EVENT,
		ON_COLLIDE_WITH_OBSTACLE,
		ON_COLLIDE_WITH_COLLECTBLES,
		NONE = -1
    }
}
