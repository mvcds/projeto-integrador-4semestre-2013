using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Texture2D star;
	private int vida = 400;
	public GUIStyle customBox;
	public GUIStyle customBox2;
		
	// Use this for initialization
	void Start () {
	   
	}
	
	void OnGUI(){
		// QUEST
		if (GamePlay.Instance.PlayerQuest != null){
			GUI.Box (new Rect (Screen.width - 810, 10, 100, 20), GamePlay.Instance.PlayerQuest.Timer.getTempo());
			GUI.Box (new Rect (Screen.width - 200, Screen.height / 2, 200, 50), GamePlay.Instance.PlayerQuest.Name);
			GUI.Label (new Rect ( Screen.width - 180, Screen.height / 2 + 20, 100, 100), GamePlay.Instance.PlayerQuest.Description);
		} else {
			GUI.Box (new Rect (Screen.width - 810, 10, 100, 20), "00 : 00");
		}
		
		// HEALTH BAR
		GUI.Box (new Rect (Screen.width - 409, 10, vida, 50), "", customBox);
		GUI.Box (new Rect (Screen.width - 410, 10, 400, 50), "", customBox2);
		
		// STARS
		GUI.Label (new Rect (Screen.width - 810, 10, 100, 100), star);
		GUI.Label (new Rect (Screen.width - 710, 10, 100, 100), star);
		GUI.Label (new Rect (Screen.width - 610, 10, 100, 100), star);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (vida >= 0){
			vida--;
		}
		
		
		// QUEST
		if (GamePlay.Instance.PlayerQuest != null){
			if (GamePlay.Instance.PlayerQuest.Timer.checkTime()){
		    	GamePlay.Instance.PlayerQuest = null;
			}
		}
	}
}
