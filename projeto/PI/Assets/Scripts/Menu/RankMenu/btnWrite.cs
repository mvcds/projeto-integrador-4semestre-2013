using UnityEngine;
using System.Collections;

public class btnWrite : Button
{
    GUIStyle MyFont
    {
        get
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.normal.textColor = Color.black;
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = 21;

            return myStyle;
        }
    }

    protected override void Action()
    {
        base.Action();
        Director.Instance.WriteRank(btnLetra.Profile, Director.Instance.GameRank);
        _myMenu.SetAble(false);
    }
    
    void Update()
    {
        Fix();

        if (_myMenu != null)
        {
            if (true)
            {
                if (_myMenu.buttons.Length == WriteMenu.LETTERS + WriteMenu.EXTRA)
                {
                    _myMenu.buttons[_myMenu.buttons.Length - 1] = this;
                    //_myMenu = null;
                }
            }
        }
        else
            _revertShown = (btnLetra.Profile == "");
    }

    protected override void Draw()
    {
        base.Draw();
		/*
        Rect r = new Rect(place_size.x.FitOnWidth(), place_size.y.FitOnHeight(),
                place_size.width.FitOnWidth(), place_size.height.FitOnHeight());*/
		Rect r = new Rect(Screen.width * 0.35f, Screen.height * 0.08f, 300, 200);

        GUI.Label(r, btnLetra.Profile, MyFont);
    }
}
