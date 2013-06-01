using UnityEngine;
using System.Collections;
using System;

public class NPC_Quest : MonoBehaviour {
	
	private Texture2D hoverMark;//TODO: make it came by the quest file [talk to gamedesigners]
	private Transform player;
	private Quest quest;//TODO: make it came in the quest file	
	protected bool canClick;
	protected bool talk;
	public float area = 1;
	public AudioSource fala;
	public AudioSource refuse;
	public int questId = 0;//TODO: script to test questID's
	
	void OnGUI(){
		
		if (talk) {
			if (GamePlay.Instance.QuestById((uint)questId).IsAvailable()){
				GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 400, 300), quest.Name);
				
				GUI.Label (new Rect ( Screen.width / 2 - 100, Screen.height / 3, 300, 100), quest.Description);
				
				
				if (GUI.Button (new Rect ( Screen.width / 2 - 150, Screen.height / 2, 100, 20), "Aceitar")) {
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
				
				if (GUI.Button (new Rect ( Screen.width / 2 + 50, Screen.height / 2, 100, 20), "Recusar")) {
					talk = false;
					refuse.Play ();
				}
				
			} else if (GamePlay.Instance.QuestById((uint)questId).IsDone()){
				
				GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 200, 100), "Obrigado!");
				
				if (GUI.Button (new Rect ( Screen.width / 2 - 130, Screen.height / 3 - 100, 60, 30), "OK")) {
					talk = false;
				}
				
			} else {
				
				GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 200, 100), "Mais rapido!");
				
				if (GUI.Button (new Rect ( Screen.width / 2 - 130, Screen.height / 3 - 100, 60, 30), "OK")) {
					talk = false;
				}
			}
		}
		
		// Drawing Hover Mark
		if (canClick){
			if (!GamePlay.Instance.QuestById((uint)questId).IsAvailable()){
				hoverMark = (Texture2D)Resources.Load("Images/Icons/talk_mark");
			} else {
				hoverMark = (Texture2D)Resources.Load("Images/Icons/question_mark");
			}
			GUI.Label (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), hoverMark);
		}
	}
	
	void Start () {
		player = GameObject.Find("Player").transform;
		hoverMark = (Texture2D)Resources.Load("question_mark");
		
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
			fala.Play();
		}
	}
	
	void OnMouseExit(){
		canClick = false;
	}
	
	}
	

