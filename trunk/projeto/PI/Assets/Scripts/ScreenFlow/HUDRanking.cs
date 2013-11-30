using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDRanking : MonoBehaviour {
	
	private int x = (int) (Screen.width * 0.2f);
	private int y = (int) (Screen.height * 0.3f);
	
	private int paddingY = (int) (Screen.height * 0.1f);
	private int boxWidth = (int) (Screen.width * 0.6f);
	private int boxHeight = (int) (Screen.height * 0.08f);

    private List<RankPosition> ranks;
	
	private string title = "RANKING";
	
	GUIStyle MyFont
    {
        get
        {
            GUIStyle myStyle = GUI.skin.GetStyle("box");
            myStyle.normal.textColor = Color.white;
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = 30;
			
			return myStyle;
        }
    }
	
	//Temporário
	void Start () 
    {
        ranks = Director.Instance.RankInLevel(Director.RankType.Distance);
	}
	
	void OnGUI()
    {
        if (ranks == null)
            return;

		GUI.Box(new Rect(x + ((boxWidth - boxWidth * 0.75f) / 2), y + (paddingY * -2), boxWidth * 0.75f, boxHeight), title, MyFont);

        //TODO: nome?
        for(int i = 0; i < ranks.Count; i++)
        {
            Rank rank = ranks[i].Ranking;
            string text = "#" + (i+1) + " " + ranks[i].Profile + " Ducks: " + rank.Ducks + " Distance: " + rank.Distance;
            GUI.Box(new Rect(x, y + (paddingY * i), boxWidth, boxHeight), text, MyFont);
        }
	}
}
