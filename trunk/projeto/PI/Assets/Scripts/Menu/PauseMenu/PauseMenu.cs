using UnityEngine;
using System.Collections;

public class PauseMenu : Menu 
{
	protected override bool canShow
	{
		get
		{
			return Director.Instance.isPaused;
		}
	}
}
