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
	
	static public bool hasBegun
	{
		get
		{
			return (AppStatus == ApplicationStatus.Initialized);
		}
	}
	
	public Texture[] splashImages;
	public float[] splashDuration;
	
	private int pseudoFrame = 0;	
	DateTime now = DateTime.Now;
			
	#endregion
	
	#region Splash
	
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
	
	#endregion
	
	#region General
	
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
			switch (GameController.Status)
			{
				case GameController.GameStatus.StartMenu:
					InitialMenu();
					break;
				default:
					//Debug.Log("Not implemented");
				break;
			}
		}
		
		Debug.Log(GameController.Status);
	}
	
	void InitialMenu()
	{
		Rect test  = new Rect(0, 0, 100, 100);
		if (GUI.Button(test, "Click me"))
		{
			GameController.LoadLevel("LanesTeste");
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
