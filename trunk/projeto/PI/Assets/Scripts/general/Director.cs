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
    
    #region Splash

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

    #region Profile
    
    public bool UseProfile
    {
        get
        {
            return false;
        }
    }
    
    Dictionary<string, LevelStatus> unblockedLevels = new Dictionary<string, LevelStatus>();

    private const string DEFAULT_PROFILE_NAME = "CAP";

    public void LoadProfile(string name = DEFAULT_PROFILE_NAME)
    {
        //TODO: unblockedLevels = RecoverLevels(name); 
        //Fix if the first level is missing
        if (!unblockedLevels.ContainsKey(DEFAULT_LEVEL_NAME))
            unblockedLevels.Add(DEFAULT_LEVEL_NAME, LevelStatus.First);
    }

    [Obsolete("Not fully tested yet")]
    public bool canSkipDialog(SpeachEvent.Trigger on)
    {
        string level = Application.loadedLevelName;

        if (unblockedLevels.ContainsKey(level))
        {
            if (unblockedLevels[level] == LevelStatus.First)
                return false;
            else if (unblockedLevels[level] == LevelStatus.Played && on == SpeachEvent.Trigger.PhaseBeginning)
                return true;
            //Not tested below
            else if (unblockedLevels[level] == LevelStatus.FirstWin && on == SpeachEvent.Trigger.PhaseEnding)
                return false;

            return true;
        }

        return false;
    }

    #endregion

    #region Menu 
    
    #endregion

    #region Game

    private enum GameStatus
    {
        None,
        Starting,
        Run,
        Pause,
        RankWrite,
        Victory,
        GameOver,
        Exiting
    }

    private enum LevelStatus
    {
        First,
        Played,
        FirstWin,
        Win
    }

    GameStatus _status = GameStatus.None;
    public const string DEFAULT_LEVEL_NAME = "LanesTesteBlocos";

    public void LoadLevel(string level)
    {
        if (!unblockedLevels.ContainsKey(level))
            unblockedLevels.Add(level, LevelStatus.First);

        _status = GameStatus.Starting;

        Application.LoadLevel(level);
    }

    public void ResetLevel()
    {
        LoadLevel(Application.loadedLevelName);
    }

    public bool isStarting
    {
        get
        {
            return (_status == GameStatus.Starting);
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

    public bool canShowDialog
    {
        get
        {
            return (_status != GameStatus.None);
        }
    }

    public void Run()
    {
        string level = Application.loadedLevelName;

        if (!unblockedLevels.ContainsKey(level))
            unblockedLevels.Add(level, LevelStatus.Played);
        else if (unblockedLevels[level] == LevelStatus.First)
            unblockedLevels[level] = LevelStatus.Played;

        _status = GameStatus.Run;
    }

    public void Pause()
    {
        _status = GameStatus.Pause;
    }

    public string StatusOfThisLevel()
    {
        string level = Application.loadedLevelName;
        if (!unblockedLevels.ContainsKey(level))
            return "None";
        else
            return unblockedLevels[level].ToString();
    }

    #endregion

    #region Shop

    #endregion

    #region Rank 

    #endregion

    #region Achiv

    #endregion
}
