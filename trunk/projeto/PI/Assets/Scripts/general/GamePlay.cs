using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PI.Data.XML;
using System;

namespace PI.General
{
	public class GamePlay {
		
		#region Singleton's Definition	
		private static GamePlay instance;
		
		private GamePlay()
		{
			string errors = "";
			int element;
			
			//*Quests
			element = 0;
			foreach(object q in questControl.ListAll())
			{
				Quest quest = (Quest) q;
				
				foreach(Quest gQuest in Quests)
				{
					if (quest.ID == gQuest.ID)
						errors += "Quest ID #" + quest.ID +  " is defined again at element " + element + "\n";
				}
				
				Quests.Add(quest);
			}
			//*/
			
			XMLBase.WriteLog(errors);
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
		private List<Quest> questList = new List<Quest>();
		
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