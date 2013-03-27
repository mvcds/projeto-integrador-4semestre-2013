using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PI.Data.XML;

namespace PI.General
{
	public class GamePlay {
		
		#region Singleton's Definition	
		private static GamePlay instance;
		
		private GamePlay()
		{
			playerQuest = new Quest(-1, "Teste", "Teste de XML");
			//TODO: load game(?)
			//TODO: load quests		
			//PI.Data.XML.Quest.Insert(null);
			questControl.Create();
			//throw new UnityException("teste");
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
		
		//TODO: refactor it
		private Quest playerQuest;
		public Quest PlayerQuest { get; set; }
		
		private PI.Data.XML.Quest questControl = new PI.Data.XML.Quest();
		
		private List<Quest> questList;
		
		public List<Quest> Quests
		{
			get
			{				
				return questList;
			}
			private set
			{
				questList = value;
			}
		}	
			
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
}