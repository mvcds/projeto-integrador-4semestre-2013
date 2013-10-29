using UnityEngine;
using System.Collections;

public class LevelFim : MonoBehaviour {
	
	int level;
	
	public int distanceLevel1;
	public int ducksLevel2;
	
	// Use this for initialization
	void Start () {
		level = Application.loadedLevel;	
	}
	
	// Update is called once per frame
	void Update () {
		switch(level){
			
		case 1:
			
			if (Director.Instance.GameRank.Distance >= distanceLevel1){
				print ("Fim do Level: " + level);
				// Chamar tela de Vitória
				Application.LoadLevel(2);
			}
			break;
			
		case 2:
			
			if (Director.Instance.GameRank.Ducks >= ducksLevel2){
				print ("Fim do Level: " + level);
				// Chamar tela de Vitória
				Application.LoadLevel(3);
			}
			break;
			
		case 3:
			break;
			
		case 4:
			break;
		}
	}
}
