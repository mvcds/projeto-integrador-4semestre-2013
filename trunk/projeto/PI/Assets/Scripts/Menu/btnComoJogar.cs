using UnityEngine;
using System.Collections;
using System;

public class btnComoJogar : Button {
	protected override void Action(){
		Application.LoadLevel("Controles");
	}
}
