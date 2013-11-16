using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public GameObject nadando;
	public GameObject boiando;
    public GameObject naPorta;
    public GameObject capivara;
	
	void Update(){

        nadando.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Nada);
        boiando.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia);
        naPorta.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Porta);
        capivara.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Capivara);

	}
}
