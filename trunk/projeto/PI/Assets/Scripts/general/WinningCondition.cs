using UnityEngine;
using System.Collections;
using System;

public class WinningCondition : MonoBehaviour {

    public enum Unit
    {
        Duck
        , Distance/*
        , Time
        , Hit
        , GotPowerUp
        , GotCapivara
        , GotBoia
        , GotPorta
        , KeepPowerUp
        , KeepCapivara
        , KeepBoia
        , KeepPorta
        , LosePowerUp
        , LoseCapivara
        , LoseBoia
        , LosePorta*/
    }

    public enum Condition
    {
        Less,
        LessEqual,
        Equal,
        More,
        MoreEqual,
        Diferent
    }
    
    public bool hasWon
    {
        get;
        private set;
    }

    public Unit unit;
    public Condition condition;
    public float value;
    public string msg = "Just do it!";

    /// <summary>
    /// Se depois de ter alcançado a condição ela for perdida, o jogo acaba
    /// </summary>
    public bool failable;
    
	// Use this for initialization
	void Start () {
        hasWon = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasWon)
            hasWon = Test;
        else if (failable)
        {
            if (!Test)
                Director.Instance.GameOver(false);
        }
	}

    bool Test
    {
        get
        {
            switch (condition)
            {
                case Condition.Diferent:
                    return (getUnitValue != value);
                case Condition.Equal:
                    return (getUnitValue == value);
                case Condition.Less:
                    return (getUnitValue < value);
                case Condition.LessEqual:
                    return (getUnitValue <= value);
                case Condition.More:
                    return (getUnitValue > value);
                case Condition.MoreEqual:
                    return (getUnitValue >= value);
            }
            throw new Exception("Test against what?");
        }
    }

    float getUnitValue
    {
        get
        {
            switch (unit)
            {
                case Unit.Distance:
                    return Director.Instance.GameRank.Distance;
                case Unit.Duck:
                    return Director.Instance.GameRank.Ducks;
                /*case Unit.Time:
                    return 0;*/
            }
            throw new Exception("Get Value of?");
        }
    }
}
