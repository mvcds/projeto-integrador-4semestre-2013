using UnityEngine;
using System.Collections;

public class btnBegin : Button {
	
    [SerializeField]
    private string TestScene = Director.DEFAULT_LEVEL_NAME;

	protected override void Action ()
    {
        //TODO: select level
        base.Action();
        if (!Debug.isDebugBuild)
            Director.Instance.LoadLevel(Director.DEFAULT_LEVEL_NAME);
        else
            Director.Instance.LoadLevel(TestScene);
	}
	
}
