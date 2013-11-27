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
    public const string DEFAULT_LEVEL_NAME = "FaseTeste1";

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
        if (victory)
        {
            SetWin();
            _status = GameStatus.Ending;
        }
        else
            _status = GameStatus.GameOver;
    }

    public void SetWin()
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

    private const int RANK_LIMIT = 10;

    public enum RankType
    {
        Duck,
        Distance
        ,Average
    }

    private Dictionary<RankType, List<RankPosition>> _rankByType = new Dictionary<RankType, List<RankPosition>>();
    	
	public List<RankPosition> RankInLevel(RankType type)
	{
		string level = Application.loadedLevelName;
		List<RankPosition> result = new List<RankPosition>();
		
		FixRank(ref _rankByType);
				
		foreach(RankPosition p in _rankByType[type])
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
        //*Initializing rank
        if (!list.ContainsKey(RankType.Duck))
            list.Add(RankType.Duck, DefaultList(RankType.Duck));
        if (!list.ContainsKey(RankType.Distance))
            list.Add(RankType.Distance, DefaultList(RankType.Distance));
        //*/
		
		//*Size
		foreach (RankType type in list.Keys)
			list[type] = list[type].Take(RANK_LIMIT).ToList();
		//*/
			
		//*Type
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
        }
		//*/
	}
	//*/
    
    #endregion

    #region Achiv

    #endregion
}