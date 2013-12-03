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

    private const string DEFAULT_PROFILE_NAME = "ZE";

    public void LoadProfile(string name = DEFAULT_PROFILE_NAME)
    {
        //TODO: unblockedLevels = RecoverLevels(name); 
        //Fix if the first level is missing
        if (!unblockedLevels.ContainsKey(DEFAULT_LEVEL_NAME))
            unblockedLevels.Add(DEFAULT_LEVEL_NAME, LevelStatus.First);            		
    }

    public bool canSkipDialog(SpeachEvent.Trigger on)
    {
        string level = Application.loadedLevelName;

        if (unblockedLevels.ContainsKey(level))
        {
            if (unblockedLevels[level] == LevelStatus.First)
                return false;
            else if (unblockedLevels[level] == LevelStatus.Played && on == SpeachEvent.Trigger.PhaseStarting)
                return true;
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
	
	private Rank _rank;
	
    public Rank GameRank
    {
        get
		{
			if (_rank == null)
				_rank = new Rank();
			
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
        ShowingRank,
        Victory,
        GameOver,
        Exiting,
		Ending
    }

    private enum LevelStatus
    {
        First,
        Played,
        FirstWin,
        Win
    }

    private DateTime gameStart;
    GameStatus _status = GameStatus.None;
    public const string DEFAULT_LEVEL_NAME = "FASE-1-FECHADA";

    public void LoadLevel(string level)
    {
        if (!unblockedLevels.ContainsKey(level))
            unblockedLevels.Add(level, LevelStatus.First);
        
        try
        {
            Application.LoadLevel(level);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public void ResetLevel()
    {
        LoadLevel(Application.loadedLevelName);
        GameRank = new Rank();
    }

    public string Status
    {
        get
        {
            return _status.ToString();
        }
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
    
    public bool isEnding
    {
        get
        {
            return (_status == GameStatus.Ending);
        }
    }

    public bool isShowingRank
    {
        get
        {
            return (_status == GameStatus.ShowingRank);
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
        gameStart = DateTime.Now;
    }

    public void Pause()
    {
        _status = GameStatus.Pause;
    }

    public void GameOver(bool victory)
    {
        bool write = false;
        newPosition = new Dictionary<RankType, int>();
        
        foreach (RankType type in Types)
        {
            if (!newPosition.ContainsKey(type))
                newPosition.Add(type, GetNewPosition(type, GameRank));

            if (newPosition[type] < RANK_LIMIT)
                write = true;
        }
        
        if (victory)
        {
            WinLevelAsFirstTime();
            KeepVictoryAfterWrite(write, GameStatus.Ending);
        }
        else
            KeepVictoryAfterWrite(write, GameStatus.GameOver);
    }

    private void KeepVictoryAfterWrite(bool writing, GameStatus status)
    {
        if (writing)
        {
            _seeingRank = status;
            _status = GameStatus.RankWrite;
        }
        else
            _status = status;
    }

    public void WinLevelAsFirstTime()
    {
        string level = Application.loadedLevelName;
        if (!unblockedLevels.ContainsKey(level))
            unblockedLevels.Add(level, LevelStatus.FirstWin);
        else if (unblockedLevels[level] == LevelStatus.Played)
            unblockedLevels[level] = LevelStatus.FirstWin;
    }
	
	public void Victory()
	{
        if (_status == GameStatus.Ending)
        {
            _status = GameStatus.Victory;
            unblockedLevels[Application.loadedLevelName] = LevelStatus.Win;
        }
        else
            throw new System.Exception("To set a victory, first call gameover as victory");
    }

    public void Start()
    {
        _status = GameStatus.Starting;
        GameRank = new Rank();
    }

    public string StatusOfThisLevel()
    {
        string level = Application.loadedLevelName;
        if (!unblockedLevels.ContainsKey(level))
            return "None";
        else
            return unblockedLevels[level].ToString();
    }

    public double GameDuration
    {
        get
        {
            return (DateTime.Now - gameStart).TotalSeconds;
        }
    }

    #endregion

    #region Shop

    #endregion

    #region Rank 

    public const int RANK_LIMIT = 5;

    public enum RankType
    {
        Duck,
        Distance
        ,Average
    }
    
    private void DefaultTypes(ref List<RankType> types)
    {
        types.Add(RankType.Duck);
        types.Add(RankType.Distance);
    }

    public List<RankType> Types = new List<RankType>();
    private Dictionary<RankType, List<RankPosition>> RankByType = new Dictionary<RankType, List<RankPosition>>();
    private Dictionary<RankType, int> newPosition;

	public List<RankPosition> RecoverRankInLevel(RankType type)
	{
		string level = Application.loadedLevelName;
		List<RankPosition> result = new List<RankPosition>();

        FixRank(ref RankByType);

		foreach(RankPosition p in RankByType[type])
		{
			if (p.Level == level || p.Level == null)
			{
				result.Add(p);
				
				if (result.Count >= RANK_LIMIT)
					break;
			}
		}
		
		return result;
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
            result.Add(new RankPosition(DEFAULT_PROFILE_NAME, r, null));

        return result;
    }
		
	private void FixRank(ref Dictionary<RankType, List<RankPosition>> list)
	{
        DefaultTypes(ref Types);

        //*Initializing rank by type
        foreach (RankType type in Types)
        {
            if (!list.ContainsKey(type))
                list.Add(type, DefaultList(type));
        }
        //*/

		//*Size
        foreach (RankType type in Types)
			list[type] = list[type].Take(RANK_LIMIT).ToList();
		//*/
			
		//*Type
        foreach (RankType type in Types)
        {			
            switch (type)
            {
                case RankType.Duck:
                    list[type] = list[type].OrderByDescending(p => p.Ranking.Ducks).ToList();
                    break;
                case RankType.Distance:
                    list[type] = list[type].OrderByDescending(p => p.Ranking.Distance).ToList();
                    break;
                case RankType.Average:
                    list[type] = list[type].OrderByDescending(p => (p.Ranking.Ducks + p.Ranking.Distance * 3) / 4).ToList();
                    break;
            }
        }
		//*/
	}
	//*/

    private GameStatus _seeingRank = GameStatus.None;

    public void ShowRank()
    {
        _seeingRank = _status;
        _status = GameStatus.ShowingRank;
    }

    public void HideRank()
    {
        _status = _seeingRank;
        _seeingRank = GameStatus.None;
    }

    public void WriteRank(string profile, Rank newRank)
    {
        foreach (RankType type in newPosition.Keys)
        {
            RankPosition position = new RankPosition(profile, newRank, Application.loadedLevelName);
            
            RankByType[type].Add(position);
            Debug.Log(type.ToString() + ": #" + (newPosition[type] + 1) + " " + newRank.ValueBy(type));
        }
        _status = GameStatus.ShowingRank;
    }

    public int GetNewPosition(RankType type, Rank newRank)
    {
        int i;
        for (i = 0; i < RANK_LIMIT; i++)
        {
            Rank rank = RankByType[type][i].Ranking;

            if (newRank.ValueBy(type) > rank.ValueBy(type))
                return i;
        }

        return i;
    }
        
    #endregion

    #region Achiv

    #endregion
}