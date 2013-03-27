using UnityEngine;
using System.Collections.Generic;


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
	
	private static int count = 0;
	private int questID;
	private string questName;
	private string description;
	//TODO: add behaviour to set when timer expires
	private QuestTimer timer;
	private QuestSituation situation;
	//TODO: add needed quests to be available
	//TODO: add requirements to be able to get in progress
	
	public int ID
	{
		get
		{
			return questID;
		}
		private set
		{
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
			description = value;
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
	
	private QuestSituation Situation
	{
		get
		{
			return situation;
		}
		set
		{
			situation = value;
		}
	}
	
	static public int Count
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
	
	public Quest(int id, string name, string description){
		StandardQuest(id, name, description);
		this.Timer = null;
	}
	
	public Quest(int id, string name, string description, int seconds){
		StandardQuest(id, name, description);
		this.Timer = new QuestTimer(seconds);
	}
	
	private void StandardQuest(int id, string name, string description)
	{		
		count++;
		this.Situation = QuestSituation.Disabled;
		
		this.ID = id;
		this.Name = name;
		this.Description = description;
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
