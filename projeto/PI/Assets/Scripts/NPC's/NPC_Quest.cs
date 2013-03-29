using UnityEngine;
using System.Collections;
using PI.General;
using System;

public class NPC_Quest : NPC_Mouse {
	
	public Texture2D questionMark;//TODO: make it came by the quest file [talk to gamedesigners]
	private Quest quest;//TODO: make it came in the quest file
	//private string questName;//TODO: make it came by the quest file
	//private string questDescription;//TODO: make it came by the quest file
	//private int questTime;//TODO: make it came by the quest file
	
	public int questId = 0;//TODO: script to test questID's
		
	void OnGUI(){
		if (talk) {
			GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 400, 300), quest.Name);
			
			GUI.Label (new Rect ( Screen.width / 2 - 100, Screen.height / 3, 100, 100), quest.Description);
			
			if (GUI.Button (new Rect ( Screen.width / 2 - 150, Screen.height / 2, 100, 20), "Accept")) {
				try
				{
					GamePlay.Instance.PlayerQuest = quest;
				}
				catch(Exception e)
				{
					PI.Data.XML.XMLBase.WriteErrorLog(e.Message);
				}
				talk = false;
			}
			
			if (GUI.Button (new Rect ( Screen.width / 2 + 50, Screen.height / 2, 100, 20), "Refuse")) {
				talk = false;
			}
		}
		
		if (canClick){
			GUI.Label (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), questionMark);
		}
	}
	
	void Start () {
		if (questId == 0)
			PI.Data.XML.XMLBase.WriteErrorLog("Quest ID was not implemented correctly: 0 found.");
		quest = GamePlay.Instance.QuestById((uint)questId);
	}
	
}
