using UnityEngine;
using System.Collections;

public class HUDRanking : MonoBehaviour {
	
	private int x = (int) (Screen.width * 0.2f);
	private int y = (int) (Screen.height * 0.3f);
	
	private int paddingY = (int) (Screen.height * 0.1f);
	private int boxWidth = (int) (Screen.width * 0.6f);
	private int boxHeight = (int) (Screen.height * 0.08f);
	
	// Alterar Aqui
	
	private string title = "RANKING";
	private string r1 = "Name1   Ducks: " + Director.Instance.GameRank.Ducks + " Distance: " + Director.Instance.GameRank.Distance;
	private string r2 = "Name1   Ducks: " + Director.Instance.GameRank.Ducks + " Distance: " + Director.Instance.GameRank.Distance;
	private string r3 = "Name1   Ducks: " + Director.Instance.GameRank.Ducks + " Distance: " + Director.Instance.GameRank.Distance;
	private string r4 = "Name1   Ducks: " + Director.Instance.GameRank.Ducks + " Distance: " + Director.Instance.GameRank.Distance;
	private string r5 = "Name1   Ducks: " + Director.Instance.GameRank.Ducks + " Distance: " + Director.Instance.GameRank.Distance;
	
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
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnGUI(){
		
		GUI.Box(new Rect(x + ((boxWidth - boxWidth * 0.75f) / 2), y + (paddingY * -2), boxWidth * 0.75f, boxHeight), title, MyFont);
		
		GUI.Box(new Rect(x, y + (paddingY * 0), boxWidth, boxHeight), r1, MyFont);
		GUI.Box(new Rect(x, y + (paddingY * 1), boxWidth, boxHeight), r2, MyFont);
		GUI.Box(new Rect(x, y + (paddingY * 2), boxWidth, boxHeight), r3, MyFont);
		GUI.Box(new Rect(x, y + (paddingY * 3), boxWidth, boxHeight), r4, MyFont);
		GUI.Box(new Rect(x, y + (paddingY * 4), boxWidth, boxHeight), r5, MyFont);
		
	}
}
