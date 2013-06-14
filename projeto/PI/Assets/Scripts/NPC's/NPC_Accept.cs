using UnityEngine;
using System.Collections;
using System;

 public class NPC_Accept : MonoBehaviour {
	
	private Texture2D hoverMark;//TODO: make it came by the quest file [talk to gamedesigners]
	private Transform player;
	protected bool canClick;
	protected bool talk;
	public int npcID;
	public float area = 1;
	public AudioSource som;
	public AudioSource complete;
	
	void Start(){
		player = GameObject.Find("Player").transform;
		hoverMark = (Texture2D)Resources.Load("Images/Icons/question_mark");
	}
	
	void OnMouseOver()
	{
		//Distance
		if (GamePlay.Instance.QuestById((uint)npcID).IsInProgress())
		{
			canClick = (Vector3.Distance(transform.position, player.transform.position) < GamePlay.NPC_DISTANCE * area);
			if (canClick && Input.GetMouseButton(0)) {
				som.Play();
				talk = true;
			}
		}
	}
	
	void OnMouseExit(){
		canClick = false;
	}
		
	void OnGUI(){
		if (talk && GamePlay.Instance.QuestById((uint)npcID).IsInProgress()) {
			GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 400, 300), GamePlay.Instance.QuestById((uint)npcID).Name + " Completada!");
			
			//GUI.Label (new Rect ( Screen.width / 2 - 100, Screen.height / 3, 100, 100), quest.Description);
						
			if (GUI.Button (new Rect ( Screen.width / 2 - 150, Screen.height / 2, 100, 20), "Ok")) {
				GamePlay.Instance.QuestById((uint)npcID).Complete();
				complete.Play();				
				talk = false;
			}
			
		}
		
		if (canClick && GamePlay.Instance.QuestById((uint)npcID).IsInProgress()){
			GUI.Label (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), hoverMark);
		}
	}
}