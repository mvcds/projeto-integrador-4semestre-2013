using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PI.Data.XML;
using System;


	public class GamePlay {
		
		#region Singleton's Definition	
		
		private static GamePlay instance;
		
		private GamePlay()
		{
			string errors = "";
			int element;
			
			//*Quests
			element = 1;
			foreach(object q in questControl.ListAll())
			{
				Quest quest = (Quest) q;
				
				foreach(Quest gQuest in Quests)
				{
					if (quest.ID == gQuest.ID)
						errors += "Quest ID #" + quest.ID +  " is defined again at element " + element + "\n";
				}
				
				Quests.Add(quest);
				element++;
			}
			//*/
			QuestById(1).MakeAvailable();
						
			XMLBase.WriteErrorLog(errors);
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
		
		//TODO: implement it, loading all that was informed at game saving
		public static void Load()
		{
			throw new NotImplementedException();
		}
		
		//TODO: implement it, saving all needed information to continue the game
		public static void Save()
		{
			throw new NotImplementedException();
		}
		
		//TODO: implement game events/progression
		/*
		 * Mission System
		 * Events
		 * ...
		 */
		
		//TODO: break it on QuestControl
		//TODO: refactor it
		//private Quest playerQuest;
		//public Quest PlayerQuest { get; set; }
		private Quest playerQuest;
		private PI.Data.XML.QuestXML questControl = new PI.Data.XML.QuestXML();		
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
		
		public enum QuestError
		{
			NotDeclared = -1,
			NotAvailable,
			OtherInProgress,
			Done
		}
		
		public string Write(QuestError e)
		{
			switch (e)
			{
				case QuestError.NotDeclared:
					break;
				case QuestError.NotAvailable:
				case QuestError.Done:
					break;
				case QuestError.OtherInProgress:
					break;
			}
			return e.ToString();
		}
		
		public Quest PlayerQuest{
			get
			{
				return playerQuest;
			}
			private set
			{				
				if (!value.IsAvailable())
					throw new Exception(Write(QuestError.NotAvailable));
				
				if (value.IsDone())
					throw new Exception(Write(QuestError.Done));					
					
				bool exists = false;
				foreach (Quest quest in Quests)
				{					
					if (quest.IsInProgress())
						throw new Exception(Write(QuestError.OtherInProgress));
					if (value.ID == quest.ID)
						exists = true;
				}
				
				if (!exists)
					throw new Exception(Write(QuestError.NotDeclared));
					
			
				playerQuest.PutInProgress();
				playerQuest = value;
			}
		}
		
	
		public void setQuest(uint id)
		{
			playerQuest = QuestById(id);
			QuestById(id).PutInProgress();
		}
		
		public Quest QuestById(uint id)
		{
			foreach (Quest quest in Quests)
			{			
				if (quest.ID == id)
					return quest;
			}	
			XMLBase.WriteErrorLog("Quest #" + id + ": " + Write(QuestError.NotDeclared));
			return null;
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
		public const int NPC_DISTANCE = 3;
		
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