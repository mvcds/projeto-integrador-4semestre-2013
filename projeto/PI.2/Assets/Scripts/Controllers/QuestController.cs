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
			//TODO: read XML
			Quest quest1 = new Quest(1, "Test", "test", true);
			Quest quest2 = new Quest(2, "Test2", "test2", true);
			Quest quest3 = new Quest(3, "Test3", "test3", true);
			
			Quests.Add(quest1);
			Quests.Add(quest2);			
			Quests.Add(quest3);
		}
		
		public void Start(uint id)
		{
			//TODO: prevento from beggining if there's another quest running
			QuestByID(id).Start();
		}	
		
		public void Complete(uint id)
		{			
			QuestByID(id).End(true);
		}
		
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
