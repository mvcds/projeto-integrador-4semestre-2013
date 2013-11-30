using UnityEngine;

//[RequireComponent(typeof(ObjMovement))]
public class PowerUp : MonoBehaviour {
	
	public PlayerStatus.PowerUp powerUpID;		
		
	void OnTriggerEnter(Collider other)
	{
		Destroy(transform.gameObject);
		PlayerStatus.gotPowerUp(powerUpID);
    }
}
