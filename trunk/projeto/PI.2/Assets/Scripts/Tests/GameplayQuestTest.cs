using UnityEngine;
using System.Collections;
using PI.Backend;
using System;

public class GameplayQuestTest : MonoBehaviour {	
	
	#region Definitions
	public enum End {
		None,
		Success,
		Fail
	}	
	#endregion
	
	#region Proprieties	
	public string alias = "Name of the quest test";
	public bool run = false;
	public int id = 0;
	public bool makeAvailable = true;
	public bool start = true;
	private bool achieved = false;
	private bool finalMessage = false;
	public PI.Backend.Quest.Status goal = PI.Backend.Quest.Status.Done;
	public End end = End.None;
	public GameplayQuestTest next = null;
		
	bool CanRun
	{
		get
		{
			return (run && !achieved && !finalMessage);
		}
	}
	#endregion
	

	#region Methods
	void Update () {	
		if (!CanRun)
		{
			if (achieved && !finalMessage)
			{
				Debug.Log("\"" + alias + "\" (" + Gameplay.Instance.Quests.QuestByID((uint) id).Name + ") has been achieved as " + Gameplay.Instance.Quests.QuestByID((uint) id).Situation);
				finalMessage = true;
			}
			return;
		}
		if (id <= 0)
		{
			id = 0;
			throw new Exception("Testing a quest asks for an ID bigger than 0");
		}	
		Quest quest = Gameplay.Instance.Quests.QuestByID((uint) id);
		
		if (makeAvailable)
		{
			if (quest.isInSituation(Quest.Status.Disabled))
				quest.MakeAvailable();
		}
		if (start)
		{
			if (!quest.isInSituation(Quest.Status.InProgress))
				quest.Start();
		}
		
		if (end != End.None)
		{
			if (end == End.Success)
			{
				if (!quest.isInSituation(Quest.Status.Done))					
					quest.End(end == End.Success);
			}
			else 
				quest.End(end == End.Success);
		}
		
		achieved = (quest.isInSituation(goal));
		if (achieved)
		{
			if (next != null)
				next.run = true;
		}
	}
	#endregion
}
