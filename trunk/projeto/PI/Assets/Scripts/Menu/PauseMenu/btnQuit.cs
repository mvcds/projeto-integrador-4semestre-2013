using UnityEngine;
using System.Collections;

public class btnQuit : Button {
		
	protected override void Action ()
    {
        //Director.Instance.Run();
        base.Action();
		Application.LoadLevel("2-Menu");
	}
	
}
