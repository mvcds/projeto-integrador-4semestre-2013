using UnityEngine;
using System.Collections;

public class VictoryMenu : Menu
{
	protected override bool canShow
	{
		get
		{
			return Director.Instance.isVictory;
		}
	}
}
