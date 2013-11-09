using UnityEngine;
using System.Collections;

public class btnMenu : Button
{
		
	protected override void Action ()
    {
		Director.Instance.LoadLevel("2-Menu");
	}
	
}
