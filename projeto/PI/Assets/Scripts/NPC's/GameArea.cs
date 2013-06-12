using UnityEngine;
using System.Collections;

public class GameArea : MonoBehaviour {
	
	
	private bool triggered;
	public int id;
	public AudioSource som;
	
	void OnTriggerEnter(Collider c){
		if (c.name == "Player"){			
			CameraFade.StartAlphaFade( Color.white, false, 1f, 0f, () => {
				switch(id){
					case 0:
						GameObject.Find("Player").transform.position = GameObject.Find("SpawnPointEntradaFarmacia").transform.position;
						GameObject.Find("Main Camera").transform.position = GameObject.Find("SpawnPointEntradaFarmacia").transform.position;						
					break;					
					case 1:
						GameObject.Find("Player").transform.position = GameObject.Find("SpawnPointSaidaFarmacia").transform.position;
						GameObject.Find("Main Camera").transform.position = GameObject.Find("SpawnPointSaidaFarmacia").transform.position;
					break;
				}
				som.Play();	
				CameraFade.StartAlphaFade( Color.clear, false, 1f, 0f, () => {
				});
			});
		}
		triggered = true;
	}
	
	void OnTriggerExit(Collider c){
		if (c.name == "Player" ){
		}
	}
}
