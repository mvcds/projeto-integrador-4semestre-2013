using UnityEngine;
using System.Collections;

public class btnBegin : Button {
		
	protected override void Action ()
	{
		GameController.LoadLevel("LanesTeste");
	}
	
}
