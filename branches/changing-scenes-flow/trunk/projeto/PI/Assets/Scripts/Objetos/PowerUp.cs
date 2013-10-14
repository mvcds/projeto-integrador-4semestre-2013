using UnityEngine;

//[RequireComponent(typeof(ObjMovement))]
public class PowerUp : MonoBehaviour {
	
	public int powerUpID;		
		
	void OnTriggerEnter(Collider other)
	{
		Destroy(transform.gameObject);
		PlayerStatus.gotPowerUp(powerUpID);
    }
}
