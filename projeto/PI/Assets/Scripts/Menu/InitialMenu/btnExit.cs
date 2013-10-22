using UnityEngine;
using System.Collections;

public class btnExit : Button {
	
	protected override void Action ()
    {
        Director.Instance.LoadLevel("2-Menu");
	}
	
}
