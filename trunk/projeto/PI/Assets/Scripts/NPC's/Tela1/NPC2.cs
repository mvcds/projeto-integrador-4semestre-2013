using UnityEngine;
using System.Collections;

public class NPC2 : MonoBehaviour {
	
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
				if (GamePlay.Instance.PlayerQuest.Name == "Quest1"){
					talk = true;
				}
				
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
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 3 - 50, 200, 100), "Quest Completa!");
		}
		
		if (canClick){
			GUI.Label (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 100), questionMark);
		}
	}
}
