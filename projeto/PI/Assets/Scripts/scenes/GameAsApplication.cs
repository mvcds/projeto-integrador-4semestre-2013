using UnityEngine;
using System.Collections;
using System;

public class GameAsApplication : MonoBehaviour {
	
	#region Constants
	
	public enum GameStatus
	{
		NotInitialized = -1,
		Initialized,
		Quiting
	}
	
	#endregion
	
	#region Proprieties
	
	static private GameStatus _gameStatus = GameStatus.NotInitialized;
	
	static public GameStatus Status
	{
		get
		{
			return _gameStatus;
		}
		private set
		{
			_gameStatus = value;
		}
	}
	
	public Texture[] splashImages;
	public float[] splashDuration;
	
	private int now = 0;	
	DateTime hora = DateTime.Now;
	
	#endregion
	
	#region Use
	
	void Awake () 
	{
		DontDestroyOnLoad(this);
	}
	
	void Update()
	{
		if (Status == GameStatus.NotInitialized)
		{			
			TimeSpan diferenca = DateTime.Now - hora;
			if (diferenca.TotalMilliseconds > splashDuration[now])
			{
				if (now + 1 >= splashImages.Length)
				{
					Status = GameStatus.Initialized;
				}
				now++;
				hora = DateTime.Now;
			}
			
			if (Input.anyKey)
				Status = GameStatus.Initialized;
		}
	}
	
	void OnGUI()
	{	
		if (Status == GameStatus.NotInitialized)
		{
			try
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), splashImages[now]);
			}
			catch{}
		}
	}
	
	static public void Quit()
	{
		Status = GameStatus.Quiting;
		Application.Quit();
	}
	
	#endregion;
}
