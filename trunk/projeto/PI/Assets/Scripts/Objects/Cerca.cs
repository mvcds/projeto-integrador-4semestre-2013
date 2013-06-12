using UnityEngine;
using System.Collections;

public class Cerca : MonoBehaviour {
	private QuestTimer timerDelay;
	public HUD controle;
	private int delay = 1;
	//private Transform player;
	
	public AudioSource som;
	
	// Use this for initialization
	void Start () {
		//player = GameObject.Find("Player").transform;
		timerDelay = new QuestTimer(delay);
		timerDelay.Run();
	}
	
	/*void Update(){
		if (!GamePlay.Instance.isPaused && Vector3.Distance(transform.position, player.transform.position) < 1){
			if (timerDelay.checkTime()){
				som.Play();
				timerDelay = new QuestTimer(delay);
				timerDelay.Run();
				GamePlay.Instance.applyDamage(10);
			}
		}
	}*/
	
	void OnTriggerStay(Collider c){
		if (GamePlay.Instance.isPaused)
			return;
		
		if (c.name == "Player" ){
			if (timerDelay.checkTime()){
				som.Play();
				timerDelay = new QuestTimer(delay);
				timerDelay.Run();
				GamePlay.Instance.applyDamage(10);
				
			}
		}
	}
}
