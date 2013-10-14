using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Font font;
	
	private Texture lifeBar;
	private Texture heartEmpty;
	private Texture heartFull;
	private Texture duckBar;
		
	
	// Use this for initialization
	void Start ()
    {
		lifeBar = (Texture)Resources.Load("Images/HUD/LifeBar/tela_jogo_life");
		heartEmpty = (Texture)Resources.Load("Images/HUD/LifeBar/vida_vazio");
		heartFull = (Texture)Resources.Load("Images/HUD/LifeBar/vida_cheio");
		
		duckBar = (Texture)Resources.Load("Images/HUD/tela_jogo_pato");		
	}
	
	void OnGUI(){
		if (!Director.Instance.isRunning)
			return;
			
		if (PlayerStatus.duration > 0)
			GUI.Box(new Rect(10, 10, 120, 25), "PowerUp: " + (int)(PlayerStatus.duration + 1) + " / " + PlayerStatus.maxDuration);
		GUI.Box(new Rect(Screen.width / 2 - 60, 10, 120, 25), "Velocidade: " + (int)MainScript.gameVelocity);
		GUI.Box(new Rect(10, Screen.height - 35, 200, 25), "Distancia Percorrida: " + (int) Director.Instance.GameRank.Distance);
		
		// Ducks
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = font;
		myStyle.fontSize = 40;
		myStyle.alignment = TextAnchor.MiddleRight;
		myStyle.normal.textColor = Color.white;	
					
		drawImage(0, Screen.height * 0.05f, duckBar);
        GUI.Label(new Rect(-280, Screen.height * 0.07f, 500, 50), "" + Director.Instance.GameRank.Ducks, myStyle);
				
		// Life Bar
		drawImage(Screen.width - (lifeBar.width), Screen.height * 0.05f, lifeBar);
		drawHeart(1);
		drawHeart(2);
		drawHeart(3);
			
	}
	
	void drawHeart(int position){
		if (PlayerStatus.vida >= position)
			drawImage(Screen.width - (lifeBar.width / 2) - 180 + (position * 80), Screen.height * 0.05f, heartFull);
		else
			drawImage(Screen.width - (lifeBar.width / 2) - 180 + (position * 80), Screen.height * 0.05f, heartEmpty);	
	}
	
	void drawImage(float x, float y, Texture texture){
		GUI.DrawTexture (new Rect (x, y, texture.width, texture.height), texture);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
