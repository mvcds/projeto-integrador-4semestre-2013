using UnityEngine;
using System.Collections;

public class Rank {
    
    public Rank(int duck = 0, float dist = 0)
    {
        Ducks = duck;
        Distance = dist;
    }
    
    public int Ducks
    {
        get;
        private set;
    }

    public void AddDuck()
    {
        Ducks++;
    }

    public float Distance
    {
        get;
        set;
    }
	
    //TODO: Near Missings?
}

public class RankPosition
{
    public RankPosition(string profile, Rank ranking, string level = null)
    {
        Profile = profile;
		Level = level;
        Ranking = ranking;
    }

    public string Profile
    {
        get;
        private set;
    }
	
    public string Level
    {
        get;
        private set;
    }

    public Rank Ranking
    {
        get;
        private set;
    }
}
