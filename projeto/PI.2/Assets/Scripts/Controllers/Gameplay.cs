using System.Collections;
using System;

namespace PI.Backend
{
	public class Gameplay {
		
		#region Proprieties
		private QuestController _quests = null;
		public QuestController Quests
		{
			get
			{
				return _quests;
			}
			private set
			{
				_quests = value;
			}
		}
		#endregion
		
		#region Singleton's Definition
		private static Gameplay _instance;
		
		private Gameplay()
		{
			Quests = new QuestController();
		}
		
		public static Gameplay Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Gameplay();
				}
				return _instance;
			}
		}
		#endregion
		
		#region Game Progression
		public void Load()
		{
			throw new NotImplementedException();
		}
		
		public void Save()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}