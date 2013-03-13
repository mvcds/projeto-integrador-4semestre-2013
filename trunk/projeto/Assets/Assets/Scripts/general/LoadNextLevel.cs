using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {
	private bool stageCleared;
	
	void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), "Fase: " + (Application.loadedLevel + 1) );
		
		if(stageCleared){
			GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 3 - 150, 400, 300), "Stage Clear");

			if (GUI.Button (new Rect ( Screen.width /2 - 50, Screen.height / 2, 100, 20), "Next Level")) {
				Application.LoadLevel(Application.loadedLevel  + 1);
			}

		}
    }
	
	void OnCollisionEnter(Collision c){
		if (c.collider.name == "Player" ){
			stageCleared = true;
			// TRANCAR O MOVIMENTO DO PERSONAGEM 
		}
	}	
}
