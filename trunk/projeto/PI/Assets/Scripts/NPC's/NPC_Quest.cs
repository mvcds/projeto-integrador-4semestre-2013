using UnityEngine;
using System.Collections;
using System;

public class NPC_Quest : MonoBehaviour {
	
	public Texture2D questionMark;//TODO: make it came by the quest file [talk to gamedesigners]
	private Quest quest;//TODO: make it came in the quest file	
	protected bool canClick;
	protected bool talk;
	public Transform player;//TODO: dectect player automatically (no need to set player all time)
	public float area = 1;
	
	public int questId = 0;//TODO: script to test questID's
	
	void OnGUI(){
		if (talk) {
			GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 400, 300), quest.Name);
			
			GUI.Label (new Rect ( Screen.width / 2 - 100, Screen.height / 3, 100, 100), quest.Description);
			
			
			if (GUI.Button (new Rect ( Screen.width / 2 - 150, Screen.height / 2, 100, 20), "Accept")) {
				try
				{
					GamePlay.Instance.setQuest((uint)questId);
				}
				catch(Exception e)
				{
					PI.Data.XML.XMLBase.WriteErrorLog(e.Message);
				}
				talk = false;
			}
			
			//GamePlay.Instance.PlayerQuest.Complete();
			
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
	
	void OnMouseOver()
	{
		//Distance
		canClick = (Vector3.Distance(transform.position, player.transform.position) < GamePlay.NPC_DISTANCE * area);
		if (canClick && Input.GetMouseButton(0)) {
			talk = true;
		}
	}
	
	void OnMouseExit(){
		canClick = false;
	}
	
	}
	

