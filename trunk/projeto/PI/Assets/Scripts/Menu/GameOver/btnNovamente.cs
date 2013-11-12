using UnityEngine;
using System.Collections;

public class btnNovamente : Button {
	
	protected override void Action ()
    {
        base.Action();
		Director.Instance.ResetLevel();
	}
	
}
