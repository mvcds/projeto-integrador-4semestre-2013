using System.Collections;
using System;
using System.Collections.Generic;

namespace PI.Backend
{
	public class Quest: GameComponent {
		#region Definitions
		public enum Status {
			Disabled = -1,
			Available,
			InProgress,
			Done
		}	
		#endregion
		
		#region Proprieties	
		
		public string Description
		{
			get;
			private set;
		}
		
		public bool Refusable
		{
			get;
			private set;
		}
		
		//TODO: TIMER?
		public Status Situation
		{
			get;
			private set;
		}
		//TODO: list of requirements
		#endregion
		
		#region Methods
		//TODO: add timer here
		private void ConfigureQuest(uint id, string name, string description, bool canRefuse)
		{
			ID = id;
			Name = name;
			Description = description;
			Refusable = canRefuse;
			Situation = Status.Disabled;
		}
		
		protected internal Quest(uint id, string name, string description, bool canRefuse)
		{
			ConfigureQuest(id, name, description, canRefuse);
		}
				
		//TODO: add quest with another things
		
		public bool isInSituation(Status situation)
		{
			return (Situation == situation);
		}
		
		protected internal void MakeAvailable()
		{
			if (isInSituation(Status.Disabled))
			{
				Situation = Status.Available;
			}
			else
			{
				throw new Exception("Quest#" + ID + " is already available.");
			}
		}
		
		protected internal void Start()
		{
			if (isInSituation(Status.Available))
			{
				Situation = Status.InProgress;
			}
			else
			{
				throw new Exception("Quest#" + ID + " is not available.");
			}
		}
		
		protected internal void End(bool success)
		{
			if (isInSituation(Status.InProgress))
			{
				if (success)
				{
					Situation = Status.Done;					
				}
				else
				{
					Situation = Status.Available;
				}
				//TODO: remove quest
			}
			else
			{
				throw new Exception("Quest#" + ID + " is not being used.");
			}
		}
		#endregion
	}
}
