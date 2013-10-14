using UnityEngine;
using System.Collections;

public class btnBegin : Button {
		
	protected override void Action ()
    {
        //TODO: select level
        if (!Debug.isDebugBuild)
            Director.Instance.LoadLevel(Director.DEFAULT_LEVEL_NAME);
        else
            Director.Instance.LoadLevel("LanesTesteBlocos - Copia");
	}
	
}
