using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameController {
	
	#region Constants
	
	private GameController()
	{
	}
		
	public enum GameStatus
	{
		StartMenu = -1,
		OnStartingPhase,
		Running
	}
	
	#endregion
	
	#region Proprieties
			
	static private GameStatus _status = GameStatus.StartMenu;
	
	static public GameStatus Status
	{
		get
		{
			return _status;
		}
		set
		{
			_status = value;
		}
	}
	
	static public bool isRunning
	{
		get
		{
			//if (Debug.isDebugBuild)
				//return true;
			return (Status == GameStatus.Running);
		}
	}
	
	static public bool isStarting
	{
		get
		{
			return (Status == GameStatus.OnStartingPhase);
		}
	}
	
	#endregion
	
	#region Use
	
	public static void LoadLevel(string phase)
	{
		Status = GameStatus.OnStartingPhase;
		Application.LoadLevel(phase);
	}
	
	public static void RunLevel()
	{
		Status = GameStatus.Running;
	}
		
	#endregion
}