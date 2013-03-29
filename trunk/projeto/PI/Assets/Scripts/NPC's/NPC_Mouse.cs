using UnityEngine;
using System.Collections;
using PI.General;

abstract public class NPC_Mouse : MonoBehaviour {
	
	protected bool canClick;
	protected bool talk;
	public Transform player;//TODO: dectect player automatically (no need to set player all time)
	public float area = 1;
		
	void OnMouseOver()
	{
		//Distance
		canClick = (Vector3.Distance(transform.position, player.transform.position) < GamePlay.NPC_DISTANCE * area);
		if (canClick && Input.GetMouseButton(0)) {
			talk = true;
		}
	}
	
	void OnMouseExit(){
		canClick = false;
	}
}
