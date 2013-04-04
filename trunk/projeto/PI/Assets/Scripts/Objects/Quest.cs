using UnityEngine;
using System.Collections.Generic;
using System;

namespace PI.General
{
	public class Quest {
		
		#region Particularities
		
		public enum QuestSituation
		{
			Disabled = -1,
			Available,
			InProgress,
			Done
		}
		
		#endregion
		
		#region Proprieties
		
		private static uint count = 0;
		private uint? questID = null;
		private string questName = null;
		private string description = null;
		private bool? refusable = null;
		//TODO: add behaviour to set when timer expires
		private QuestTimer timer;
		private QuestSituation situation;
		//TODO: add needed quests to be available
		//TODO: add requirements to be able to get in progress
		
		public uint ID
		{
			get
			{
				return (uint)questID;
			}
			private set
			{
				if (value == null)
					throw new Exception("Valor nulo assinalado");
				questID = value;
			}
		}
		
		public string Name
		{ 
			get
			{
				return questName;
			}
			private set
			{
				if (value == null)
					throw new Exception("Valor nulo assinalado");
				questName = value;
			} 
		}
		
		public string Description
		{ 
			get
			{
				return description;
			}
			private set
			{
				if (value == null)
					throw new Exception("Valor nulo assinalado");
				description = value;
			}
		}
		
		public bool Refusable
		{
			get
			{
				return (bool)refusable;
			}
			private set
			{
				if (value == null)
					throw new Exception("Valor nulo assinalado");
				refusable = value;
			}
		}
		
		public QuestTimer Timer
		{
			get
			{
				return timer;
			}
			private set
			{
				timer = value;
			}
		}	
		
		public QuestSituation Situation
		{
			get
			{
				return situation;
			}
			private set
			{
				if (value == null)
					throw new Exception("Valor nulo assinalado");
				situation = value;
			}
		}
		
		static public uint Count
		{
			get
			{
				return count;
			}
			private set
			{
				count++;
			}
		}
		
		#endregion
		
		#region Methods
		
		public Quest()
		{
		}
		
		public Quest(uint id, string name, string description){
			StandardQuest(id, name, description);
			this.Timer = null;
		}
		
		public Quest(uint id, string name, string description, int seconds){
			StandardQuest(id, name, description);
			this.Timer = new QuestTimer(seconds);
		}
		
		private void StandardQuest(uint id, string name, string description)
		{		
			count++;
			this.Situation = QuestSituation.Disabled;
			
			this.ID = id;
			this.Name = name;
			this.Description = description;
		}
		
		public void SetAttr(uint id, string name, string description, int? seconds)
		{
			StandardQuest(id, name, description);
			if (seconds != null)
				this.Timer = new QuestTimer((int)seconds);			
		}
		
		public bool MakeAvailable()
		{
			//TODO: check if all its needed quests are in the needed situation
			if (Situation == QuestSituation.Disabled)
			{
				Situation = QuestSituation.Available;
				return true;
			}
			return false;
		}
		
		public bool IsAvailable()
		{	
			return (Situation == QuestSituation.Available);
		}
		
		public bool IsInProgress()
		{	
			return (Situation == QuestSituation.InProgress);
		}
		
		public bool IsDone()
		{
			return (Situation == QuestSituation.Done);
		}
		
		#endregion
	}
}
