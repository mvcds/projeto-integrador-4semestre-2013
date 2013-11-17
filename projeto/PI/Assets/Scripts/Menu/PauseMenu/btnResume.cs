using UnityEngine;
using System.Collections;

public class btnResume : Button {
		
	protected override void Action ()
    {
        Resume();
	}

    public void Resume()
    {
        base.Action();
        Director.Instance.Run();
    }
	
}
