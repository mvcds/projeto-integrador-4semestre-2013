using UnityEngine;
using System.Collections;

public class btnLetra : Button {

    private static string _profile = "";

    public static string Profile
    {
        get { return _profile; }
        private set { _profile = value; }
    }

    GUIStyle MyFont
    {
        get
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.normal.textColor = Color.black;
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = 18;

            return myStyle;
        }
    }
	
    private char _letra;
    private int _qt = 3;
    public const char ERASE = '<';

    void Start()
    {
        Init();
        _letra = (gameObject.name).ToCharArray()[0];
    }

    protected override void Action()
    {
        base.Action();

        if (_letra != ERASE)
        {
            if (Profile.Length < 3)
                Profile += _letra;
        }
        else
            Profile = Profile.Substring(0, Profile.Length - 1);
    }

    void Update()
    {
        Fix();

        if (_letra == ERASE)
            _revertShown = (Profile.Length <= 0);
    }

    static public void ResetName()
    {
        Profile = "";
    }

    protected override void Draw()
    {
        base.Draw();

        Rect letra = new Rect(place_size.x.FitOnWidth() - 2, place_size.y.FitOnHeight() + 3,
                place_size.width.FitOnWidth(), place_size.height.FitOnHeight());

        GUI.Label(letra, _letra.ToString(), MyFont);
    }
}
