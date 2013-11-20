using UnityEngine;
using System.Collections;

public class btnHowPlay : Button {

    public Texture2D _controls = null;
    public Button back;
    
	protected override void Action ()
    {
        base.Action();

        _myMenu._bgMenu = _controls;
        _myMenu.SetAble(false);
	}
}
