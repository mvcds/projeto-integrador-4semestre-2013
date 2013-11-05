using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public GameObject nadando;
	public GameObject boiando;
	public GameObject naPorta;
	
	void Update(){
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			nadando.SetActiveRecursively(false);
			boiando.SetActiveRecursively(true);
			naPorta.SetActiveRecursively(false);
		}
		
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Porta){
			nadando.SetActiveRecursively(false);
			boiando.SetActiveRecursively(false);
			naPorta.SetActiveRecursively(true);
		}
		
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Nada){
			print("entrou");
			
			nadando.SetActiveRecursively(true);
			boiando.SetActiveRecursively(false);
			naPorta.SetActiveRecursively(false);
		}
	}
}
