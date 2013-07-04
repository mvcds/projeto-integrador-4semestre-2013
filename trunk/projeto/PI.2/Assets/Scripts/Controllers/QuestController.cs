using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace PI.Backend
{
	public class QuestController {
		
		#region Proprieties
		private List<Quest> _quests = new List<Quest>();
			
		private List<Quest> Quests
		{
			get
			{
				return _quests;
			}
			set
			{
				List<Quest> dummy = value;
				string errors = "";
				
				for(int i = 0; i < dummy.Count; i++)
				{
					int count = 0;
					for(int j = i+1; j < dummy.Count; j++)
					{
						if (dummy[i].ID == dummy[j].ID)
							count++;
					}
					if (count > 0)
						errors += "Quest#" + dummy[i].ID + " is defined " + count + " times since the point #" + i +".\n";
				}			
				if (errors != "")
					throw new Exception(errors);
				_quests = value;
			}
		}
		
		public uint SmallestID
		{
			get
			{
				uint min = Quests[0].ID;
				foreach (Quest quest in Quests)
				{
					if (quest.ID < min)
						min = quest.ID;
				}
				return min;
			}
		}
		
		public uint BiggestID
		{
			get
			{
				uint max = Quests[0].ID;
				foreach (Quest quest in Quests)
				{
					if (quest.ID > max)
						max = quest.ID;
				}
				return max;
			}
		}
		#endregion		
		
		#region Methods		
		protected internal QuestController()	
		{
			QuestReader xml = new QuestReader();
			foreach(Quest quest in xml.ListAll())
			{
				Quests.Add(quest);
			}
		}
		
		public void Start(uint id)
		{
			//TODO: prevent from beggining if there's another quest running
			QuestByID(id).Start();
		}	
		
		//TODO: method below should work only with running quest
		public void Complete(uint id)
		{			
			QuestByID(id).End(true);
		}
		
		//TODO: method below should work only with running quest
		public void Failure(uint id)
		{			
			QuestByID(id).End(false);
		}
		
		public Quest QuestByID(uint id)
		{
			foreach (Quest quest in Quests)
			{
				if (quest.ID == id)
				{
					return quest;
				}
			}
			throw new Exception("Quest#" + id + " has not been found.");;
		}	
		#endregion
	}
}
