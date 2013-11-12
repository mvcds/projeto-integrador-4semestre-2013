using UnityEngine;
using System.Collections;

public class btnResume : Button {
		
	protected override void Action ()
    {
        base.Action();
		Director.Instance.Run();
	}
	
}
