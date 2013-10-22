using UnityEngine;
using System.Collections;

public class btnNovamente : Button {
	
	protected override void Action ()
	{
		Director.Instance.ResetLevel();
	}
	
}
