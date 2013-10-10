using UnityEngine;

//[RequireComponent(typeof(ObjMovement))]
public class Obstacle : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
        Destroy(transform.gameObject);
		PlayerStatus.gotHit();
    }
}
