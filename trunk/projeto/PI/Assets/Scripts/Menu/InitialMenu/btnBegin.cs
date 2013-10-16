using UnityEngine;
using System.Collections;

public class btnBegin : Button {
		
	protected override void Action ()
    {
        //TODO: select level
        //Director.Instance.LoadLevel(Director.DEFAULT_LEVEL_NAME);
		Director.Instance.LoadLevel("lane_chao");
	}
	
}
