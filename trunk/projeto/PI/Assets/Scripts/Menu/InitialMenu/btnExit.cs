using UnityEngine;
using System.Collections;

public class btnExit : Button {
	
	protected override void Action ()
    {
        base.Action();
        Application.Quit();
	}
	
}
