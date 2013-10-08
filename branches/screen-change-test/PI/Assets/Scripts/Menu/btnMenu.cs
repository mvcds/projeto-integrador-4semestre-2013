using UnityEngine;
using System.Collections;
using System;

public class btnMenu : Button {
	
	
	
	protected override void Action(){
		//Debug.Log("No action has been implementes");
		Application.LoadLevel("Menu");
	}
}
