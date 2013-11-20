using UnityEngine;
using System.Collections;

public class btnVoltar : Button {
	
	protected override void Action ()
    {
        base.Action();

        _myMenu._bgMenu = null;
        _myMenu.SetAble();
	}
	
}
