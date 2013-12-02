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
	
    public float ValueBy(Director.RankType type)
    {
        switch (type)
        {
            case  Director.RankType.Duck:
                return Ducks;
            case Director.RankType.Distance:
                return Distance;
            case Director.RankType.Average:
                return (Distance * 3 + Ducks)/4;
        }
        throw new System.Exception("Type not declared");
    }
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
