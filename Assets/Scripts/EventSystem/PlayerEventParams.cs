using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventParams
{
    public PlayerController _player;
}

public class PlayerDeathEventArgs : PlayerEventParams
{
    public PlayerDeathEventArgs(PlayerController player)
    {
		_player = player;
    }
}

public class CollideWithObstacleEventArgs : PlayerEventParams
{
    public Obstacle _obstacleObject;

    public void CollideWithFlagEventArgs(PlayerController player, Obstacle obstacle)
    {
		_player = player;
		_obstacleObject = obstacle;
    }
}

public class GameStartEventArgs : PlayerEventParams
{
    public GameStartEventArgs()
    {

    }
}

public class GamePausedEventArgs : PlayerEventParams
{
    public GamePausedEventArgs()
    {

    }
}

public class GameResumedEventArgs : PlayerEventParams
{
    public GameResumedEventArgs()
    {

    }
}

public class GameEndEventArgs : PlayerEventParams
{
    public GameEndEventArgs()
    {

    }
}

public class ScoreUpdateEventArgs : PlayerEventParams
{
    public int NewScore;
    public ScoreUpdateEventArgs(int newScore)
    {
       NewScore = newScore;
    }
}