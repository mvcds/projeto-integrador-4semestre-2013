using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlay {
	
	#region Singleton's Definition	
	private static GamePlay instance;
	
	private GamePlay()
	{
		playerQuest = null;
	}
	
	/// <summary>
	/// Just a little trick to assure there's just one GamePlay class running in a game session
	/// </summary>
	/// <value>
	/// The instance.
	/// </value>
	public static GamePlay Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new  GamePlay();	
			}
			return instance;			
		}
	}	
	#endregion
			
	#region Game Events & Progression
	//TODO: implement game events/progression
	/*
	 * Mission System
	 * Events
	 * ...
	 */
	private Quest playerQuest;
	public Quest PlayerQuest { get; set; }
		
	#endregion
	
	#region Game Settings
	//TODO: implement game settings
	/*
	 * Sound Effects
	 * Music
	 * Difficulty
	 * ...
	 */
	#endregion
	
	#region Game Inventory
	//TODO: implement game inventory
	/*
	 * Modifications
	 * Costs
	 * ...
	 */
	#endregion
	
	#region Game Screens
	//TODO: implement game screens
	/*
	 * Splash
	 * Main Menu
	 * Game per si
	 * Credits Screen
	 * Etc
	 */
	#endregion
}

