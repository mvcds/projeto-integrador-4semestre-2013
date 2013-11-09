using UnityEngine;
using System.Collections;

public class VictoryMenu : Menu
{
	protected override bool canShow
	{
		get
		{
			bool gameover = Director.Instance.isVictory;
			/*if (gameover && Debug.isDebugBuild)
					Director.Instance.ResetLevel();*/
			return gameover;
		}
	}
}
