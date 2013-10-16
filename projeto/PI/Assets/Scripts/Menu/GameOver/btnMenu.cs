using UnityEngine;
using System.Collections;

public class btnMenu : Button
{
		
	protected override void Action ()
    {
        Application.LoadLevel("2-Menu");
	}
	
}
