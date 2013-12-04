using UnityEngine;
using System.Collections;

public class credito : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
			Director.Instance.LoadLevel("2-Menu");
	}
}
