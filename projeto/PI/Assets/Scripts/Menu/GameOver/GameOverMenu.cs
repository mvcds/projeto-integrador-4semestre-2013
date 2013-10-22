using UnityEngine;
using System.Collections;

public class GameOverMenu : Menu
{

	protected override bool canShow
	{
		get
		{
			return Director.Instance.isGameOver;
		}
	}
}
