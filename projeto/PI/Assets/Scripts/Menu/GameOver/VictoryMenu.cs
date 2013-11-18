using UnityEngine;
using System.Collections;

public class VictoryMenu : Menu
{
    public Font font;

    [SerializeField]
    private Rect lDuck = new Rect(0, 0, 100, 100),
        lDistance = new Rect(0, 0, 100, 100),
        lTime = new Rect(0, 0, 100, 100);
    [SerializeField]
    private Rect lDuckText, lDistanceText, lTimeText;

    public Texture tDuck, tDistance, tDuration;

    private int seconds;

	protected override bool canShow
	{
		get
		{
			return Director.Instance.isVictory;
		}
	}
    
    protected override void Show()
    {
        base.Show();

        Rect ducks = Fit(lDuck),
            distances = Fit(lDistance),
            duration = Fit(lTime);
        
        GUI.DrawTexture(ducks, tDuck);
        GUI.DrawTexture(duration, tDuration);
        GUI.DrawTexture(distances, tDistance);

        Rect ducksT = Fit(lDuckText),
            distancesT = Fit(lDistanceText),
            durationT = Fit(lTimeText);

        GUIStyle myStyle = new GUIStyle();
        myStyle.font = font;
        myStyle.normal.textColor = Color.white;
        myStyle.alignment = TextAnchor.MiddleLeft;
        myStyle.fontSize = 40;

        GUI.Label(ducksT, Director.Instance.GameRank.Ducks.ToString(), myStyle);
        GUI.Label(distancesT, ((int)Director.Instance.GameRank.Distance).ToString() + " M", myStyle);
        GUI.Label(durationT, ((int)Director.Instance.GameDuration).ToString() + " s", myStyle);
    }

    protected override void FixPosition()
    {
        base.FixPosition();

        FixRect(ref lDuck);
        FixRect(ref lDistance);
        FixRect(ref lTime);

        FixRect(ref lDuckText);
        FixRect(ref lDistanceText);
        FixRect(ref lTimeText);
    }
}
