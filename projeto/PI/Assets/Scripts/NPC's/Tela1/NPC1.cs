using UnityEngine;
using System.Collections;

public class NPC1 : MonoBehaviour {
	
	public Texture2D questionMark;
	public Transform player;
	private Quest quest;
	bool canClick;
	bool talk;
	public string questName;
	public string questDescription;
	public int questTime;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseOver(){
		// Distancia
		if (Vector3.Distance( transform.position, player.transform.position) < 3){
			canClick = true;
			
			// Clique
			if (Input.GetMouseButton(0)){
				talk = true;
			}
			
		} else {
			canClick = false;
		}
	}
	
	void OnMouseExit(){
		canClick = false;
	}
	
	void OnGUI(){
		
		if (talk){
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 400, 300), questName);
			
			GUI.Label (new Rect ( Screen.width / 2 - 100, Screen.height / 3, 100, 100), questDescription);
			
			if (GUI.Button (new Rect ( Screen.width / 2 - 150, Screen.height / 2, 100, 20), "Accept")) {
				GamePlay.Instance.PlayerQuest = new Quest (questName, questDescription, questTime);
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
}
