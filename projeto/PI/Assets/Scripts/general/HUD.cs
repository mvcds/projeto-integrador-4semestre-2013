using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Texture2D star;
	private int vida = 400;
	public GUIStyle customBox;
	public GUIStyle customBox2;
	private int min = 5;
	private int secs = 0;
	
	
	// Use this for initialization
	void Start () {
	   
	}
	
	void OnGUI(){
		
		
		GUI.Box (new Rect (Screen.width - 810, 10, 100, 20), "" + Time.time);
		//GUI.skin = mySkin;
		GUI.Box (new Rect (Screen.width - 409, 10, vida, 50), "", customBox);
		GUI.Box (new Rect (Screen.width - 410, 10, 400, 50), "", customBox2);
		//GUI.skin = null;
		
		GUI.Label (new Rect (Screen.width - 810, 10, 100, 100), star);
		GUI.Label (new Rect (Screen.width - 710, 10, 100, 100), star);
		GUI.Label (new Rect (Screen.width - 610, 10, 100, 100), star);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (vida >= 0){
			vida--;
		}
		
		// Tempo
		secs --;
		if (secs < 0){
			min--;
			if (min < 0){
				//GAMEOVER
			}
			secs = 59;
		}
	}
}
