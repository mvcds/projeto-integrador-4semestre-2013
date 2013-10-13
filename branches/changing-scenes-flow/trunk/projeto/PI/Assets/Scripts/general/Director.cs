using System;
using UnityEngine;
using System.Collections.Generic;

public class Director
{
    #region Singleton

    private Director()
    {
    }

    private static Director _instance = null;

    public static Director Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Director();
            return _instance;
        }
    }

    #endregion
    
    #region Splash Screen

    public bool wasSplashShown
    {
        get;
        private set;
    }

    public void FinishSplash()
    {
        wasSplashShown = true;
    }

    #endregion

    #region Profile Screen
    
    public bool UseProfile
    {
        get
        {
            return false;
        }
    }

    List<string> unblockedLevels = new List<string>();

    private const string DEFAULT_PROFILE_NAME = "CAP";

    public void LoadProfile(string name = DEFAULT_PROFILE_NAME)
    {
        //unblockedLevels = RecoverLevels(name);
        if (!unblockedLevels.Contains(DEFAULT_LEVEL_NAME))
            unblockedLevels.Add(DEFAULT_LEVEL_NAME);
    }

    #endregion

    #region Menu Screen
    
    #endregion

    #region Game Screen

    private enum GameStatus
    {
        Start,
        Run,
        Pause,
        RankWrite,
        Victory,
        GameOver,
        Exiting
    }

    GameStatus _status;
    public const string DEFAULT_LEVEL_NAME = "LanesTeste";

    public void RunLevel(string level)
    {
        _status = GameStatus.Start;
        Application.LoadLevel(level);
    }

    public bool isStarting
    {
        get
        {
            return (_status == GameStatus.Start);
        }
    }

    public bool isRunning
    {
        get
        {
            return (_status == GameStatus.Run);
        }
    }

    public bool isPaused
    {
        get
        {
            return (_status == GameStatus.Pause);
        }
    }

    public bool isWriting
    {
        get
        {
            return (_status == GameStatus.RankWrite);
        }
    }

    public bool isVictory
    {
        get
        {
            return (_status == GameStatus.Victory);
        }
    }

    public bool isGameOver 
    {
        get
        {
            return (_status == GameStatus.GameOver);
        }
    }

    #endregion

    #region Shop Screen

    #endregion

    #region Rank Screen

    #endregion

    #region Achiv Screen

    #endregion
}
