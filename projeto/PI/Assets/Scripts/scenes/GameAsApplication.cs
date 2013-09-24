using UnityEngine;
using System.Collections;
using System;

public class GameAsApplication : MonoBehaviour {
	
	#region Constants
	
	public enum ApplicationStatus
	{
		NotInitialized = -1,
		Initialized,
		Quiting
	}
	
	#endregion
	
	#region Proprieties
	
	static private ApplicationStatus _gameStatus = ApplicationStatus.NotInitialized;
	
	static public ApplicationStatus AppStatus
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
		else if (AppStatus == ApplicationStatus.Quiting)			
		{
			Quiting();
		}
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
	}
	
	static public void Quit()
	{
		AppStatus = ApplicationStatus.Quiting;
	}
	
	//TODO: implementing quiting
	private void Quiting()
	{
		throw new NotImplementedException();
		Application.Quit();
	}
	
	#endregion;
}
