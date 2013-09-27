using UnityEngine;
using System.Collections;
using System;

public class GameAsApplication : MonoBehaviour {
	
	#region Constants
	
	private enum ApplicationStatus
	{
		NotInitialized = -1,
		Initialized,
		Quiting
	}
	
	public enum GameStatus
	{
		StartMenu = -1,
		Running
	}
	
	#endregion
	
	#region Proprieties
	
	static private ApplicationStatus _gameStatus = ApplicationStatus.NotInitialized;
	
	static private ApplicationStatus AppStatus
	{
		get
		{
			return _gameStatus;
		}
		set
		{
			_gameStatus = value;
		}
	}
		
	static private GameStatus _status = GameStatus.StartMenu;
	
	static private GameStatus Status
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
	
	static public bool hasBegun
	{
		get
		{
			return (AppStatus == ApplicationStatus.Initialized);
		}
	}
	
	static public bool isRunning
	{
		get
		{
			if (Debug.isDebugBuild)
				return true;
			return (Status == GameStatus.Running);
		}
	}
	
	public Texture[] splashImages;
	public float[] splashDuration;
	
	private int pseudoFrame = 0;	
	DateTime now = DateTime.Now;
	
	#endregion
	
	#region Use
	
	void Awake () 
	{
		DontDestroyOnLoad(this);
	}
	
	void Update()
	{
		if (AppStatus == ApplicationStatus.NotInitialized)
			ShowSplash();
		else if (AppStatus == ApplicationStatus.Quiting)
			Quiting();
	}
	
	void ShowSplash()
	{
		TimeSpan diferenca = DateTime.Now - now;
		if (diferenca.TotalMilliseconds > splashDuration[pseudoFrame])
		{
			if (pseudoFrame + 1 >= splashImages.Length)
			{
				AppStatus = ApplicationStatus.Initialized;
			}
			pseudoFrame++;
			now = DateTime.Now;
		}
		
		if (Input.anyKey)
			AppStatus = ApplicationStatus.Initialized;
	}
	
	void OnGUI()
	{	
		if (AppStatus == ApplicationStatus.NotInitialized)
		{
			try
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), splashImages[pseudoFrame]);
			}
			catch{}
		}
		else if (AppStatus == ApplicationStatus.Initialized)
		{
			switch (Status)
			{
				case GameStatus.StartMenu:
					//Show initial menu		
					break;
				default:
					Debug.Log("Not implemented");
				break;
			}
		}
	}
	
	static public void Quit()
	{
		AppStatus = ApplicationStatus.Quiting;
	}
	
	static private void Quiting()
	{
		Application.Quit();
	}
	
	#endregion;
}
