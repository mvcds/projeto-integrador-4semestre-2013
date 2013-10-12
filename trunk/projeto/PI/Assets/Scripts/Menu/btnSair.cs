using UnityEngine;
using System.Collections;
using System;

public class btnSair : Button {
	
	
	
	protected override void Action(){
		
		Application.Quit();
		Debug.Log("No action has been implementes");
	}
}
