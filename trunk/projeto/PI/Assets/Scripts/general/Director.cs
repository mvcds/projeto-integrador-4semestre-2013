using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

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
	
	private Rank _rank = new Rank();
	
    public Rank GameRank
    {
        get
		{
			return _rank;
		}
        private set
		{
			_rank = value;
		}
    }

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

        GameRank = new Rank();
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

    [Obsolete("Missing full implementation")]
    public void GameOver(bool victory = false)
    {
        if (victory)
        {
            //TODO
            //_status = GameStatus.RankWrite;
            _status = GameStatus.Victory;
        }
        else
            _status = GameStatus.GameOver;
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

    private const int RANK_LIMIT = 10;

    public enum RankType
    {
        Duck,
        Distance
        ,Average
    }

    private Dictionary<RankType, List<RankPosition>> _rankByType = new Dictionary<RankType, List<RankPosition>>();
    
    public Dictionary<RankType, List<RankPosition>> RankByType
    {
        get
        {
            FixRankByType(ref _rankByType);
            return _rankByType;
        }
        private set
        {
            FixRankByType(ref value);
            _rankByType = value;
        }
    }

    private List<RankPosition> DefaultList(RankType type)
    {
        List<Rank> list = new List<Rank>();
        List<RankPosition> result = new List<RankPosition>();

        for (int i = 0; i < RANK_LIMIT; i++)
        {
            if (type == RankType.Duck)
            {
                list.Add(
                    new Rank((i + 1) * RANK_LIMIT)
                 );
            }
            else if (type == RankType.Distance)
            {
                list.Add(
                    new Rank(0, (i + 1) * RANK_LIMIT)
                 );
            }
        }

        foreach (Rank r in list)
            result.Add(new RankPosition(DEFAULT_PROFILE_NAME, r));
       

        return result;
    }

    private void FixRankByType(ref Dictionary<RankType, List<RankPosition>> list)
    {
        //*Initializing rank
        if (!list.ContainsKey(RankType.Duck))
            list.Add(RankType.Duck, DefaultList(RankType.Duck));
        if (!list.ContainsKey(RankType.Distance))
            list.Add(RankType.Distance, DefaultList(RankType.Distance));
        //*/

        foreach (RankType type in list.Keys)
        {
            switch (type)
            {
                case RankType.Duck:
                    list[type] = list[type].OrderBy(p => p.Ranking.Ducks).ToList();
                    break;
                case RankType.Distance:
                    list[type] = list[type].OrderBy(p => p.Ranking.Distance).ToList();
                    break;
                case RankType.Average:
                    list[type] = list[type].OrderBy(p => (p.Ranking.Ducks + p.Ranking.Distance * 3) / 4).ToList();
                    break;
            }
            list[type] = list[type].Take(RANK_LIMIT).ToList();
        }
    }//*/
    
    #endregion

    #region Achiv

    #endregion
}
