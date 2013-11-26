using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(ObjMovement))]
public class Obstacle : MonoBehaviour {
	
	private bool som = true;
		
	void OnTriggerEnter(Collider other)
	{
        Destroy(transform.gameObject);
		PlayerStatus.gotHit();
    }
	
	void Update()
	{
		GameObject player = GameObject.Find("Player");
		
		if (gameObject.name.Equals("Cachorro"))
		{
			// Cachorro
			if (Vector3.Distance( transform.position, player.transform.position) < 20){
				if (som){
					AudioProx.playCachorro();
					som = false;
				} else {
					AudioProx.setVolumeCachorro(1 - (Vector3.Distance( transform.position, player.transform.position) / 20));
				}
			}
			
		} else if (gameObject.name.Equals("Caminhao")) {
			
			// Caminhao
			if (Vector3.Distance( transform.position, player.transform.position) < 20){
				if (som){
					AudioProx.playCaminhao();
					som = false;
				} else {
					AudioProx.setVolumeCaminhao(1 - (Vector3.Distance( transform.position, player.transform.position) / 20));
				}
			}
			
		} else if (gameObject.name.Equals("Carro1")) {
			
			// Carro1
			if (Vector3.Distance( transform.position, player.transform.position) < 20){
				if (som){
					AudioProx.playCarro1();
					som = false;
				} else {
					AudioProx.setVolumeCarro1(1 - (Vector3.Distance( transform.position, player.transform.position) / 20));
				}
			}
			
		} else if (gameObject.name.Equals("Carro2")) {
			
			// Carro2
			if (Vector3.Distance( transform.position, player.transform.position) < 20){
				if (som){
					AudioProx.playCarro2();
					som = false;
				} else {
					AudioProx.setVolumeCarro2(1 - (Vector3.Distance( transform.position, player.transform.position) / 20));
				}
			}
			
		} else if (gameObject.name.Equals("Portao")) {
			
			// Portao
			if (Vector3.Distance( transform.position, player.transform.position) < 20){
				if (som){
					AudioProx.playPortao();
					som = false;
				} else {
					AudioProx.setVolumePortao(1 - (Vector3.Distance( transform.position, player.transform.position) / 20));
				}
			}
		}
	}
}
