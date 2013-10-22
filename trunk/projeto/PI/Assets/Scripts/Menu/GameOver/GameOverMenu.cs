using UnityEngine;
using System.Collections;

public class GameOverMenu : Menu
{

	protected override bool canShow
	{
		get
		{
			bool gameover = Director.Instance.isGameOver;
			/*if (Debug.isDebugBuild)
				Director.Instance.ResetLevel();*/
			if (gameover && Debug.isDebugBuild)
					Director.Instance.ResetLevel();
			return gameover;
		}
	}
}
