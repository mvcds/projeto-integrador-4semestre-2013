using UnityEngine;
using System.Collections;

public class Test_SampleEvent : SpeachEvent {
	public override void Action ()
	{
		GameController.RunLevel();		
	}
}
