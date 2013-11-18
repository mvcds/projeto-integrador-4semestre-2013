using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    
	public Font font;
	
	private Texture lifeBar;
	private Texture heartEmpty;
	private Texture heartFull;
	private Texture duckBar;
	
	private Texture powerUpBarraPorta;
	private Texture powerUpBarraBoia;
	private Texture powerUpBarraCapivara;
	private Texture powerUpFill;
	private Texture powerUpFillRed;
	
	// Use this for initialization
	void Start ()
    {
		lifeBar = (Texture)Resources.Load("Images/HUD/LifeBar/tela_jogo_life");
		heartEmpty = (Texture)Resources.Load("Images/HUD/LifeBar/vida_vazio");
		heartFull = (Texture)Resources.Load("Images/HUD/LifeBar/vida_cheio");
		
		duckBar = (Texture)Resources.Load("Images/HUD/tela_jogo_pato");	
		
		powerUpBarraBoia = (Texture)Resources.Load("Images/HUD/LifeBar/BarraBoia");
		powerUpBarraCapivara = (Texture)Resources.Load("Images/HUD/LifeBar/BarraCapivara");
		powerUpBarraPorta = (Texture)Resources.Load("Images/HUD/LifeBar/BarraPorta");
		powerUpFill = (Texture)Resources.Load("Images/HUD/LifeBar/greenBar");
		powerUpFillRed = (Texture)Resources.Load("Images/HUD/LifeBar/redBar");
	}
	
	void OnGUI(){
		if (!Director.Instance.isRunning)
			return;
			
		//if (PlayerStatus.duration > 0)
			//GUI.Box(new Rect(10, 10, 120, 25), "PowerUp: " + (int)(PlayerStatus.duration + 1) + " / " + PlayerStatus.maxDuration);
		GUI.Box(new Rect(Screen.width / 2 - 60, 10, 120, 25), "Velocidade: " + (int)MainScript.gameVelocity);
		GUI.Box(new Rect(Screen.width - 250, Screen.height - 60, 200, 25), "Distancia Percorrida: " + (int) Director.Instance.GameRank.Distance);
			
		// Folego
		if (MainScript.folego >= 2)
			GUI.DrawTexture (new Rect (50 + 40, Screen.height * 0.912f, (MainScript.folego / MainScript.Maxfolego) * powerUpFill.width, powerUpFill.height), powerUpFill);
		else 
			GUI.DrawTexture (new Rect (50 + 40, Screen.height * 0.912f, (MainScript.folego / MainScript.Maxfolego) * powerUpFill.width, powerUpFill.height), powerUpFillRed);
		drawImage(50, Screen.height * 0.9f, powerUpBarraBoia);
		
		// Ducks
        GUIStyle myStyle = new GUIStyle();
		myStyle.font = font;
		myStyle.normal.textColor = Color.white;
		myStyle.alignment = TextAnchor.MiddleRight;
		myStyle.fontSize = 40;
		
		drawImage(0, Screen.height * 0.05f, duckBar);
        //GUI.Label(new Rect(-280, Screen.height * 0.07f, 500, 50), "" + Director.Instance.GameRank.Ducks, myStyle);
		GUI.Label(new Rect(-280, Screen.height * 0.065f, 500, 50), "" + Director.Instance.GameRank.Ducks, myStyle);
		
		// PowerUp
		if (PlayerStatus.powerUp != PlayerStatus.PowerUp.Nada){
			
			GUI.DrawTexture (new Rect (50 + 40, Screen.height * 0.812f, (PlayerStatus.duration / PlayerStatus.maxDuration) * powerUpFill.width, powerUpFill.height), powerUpFill);
			
			//drawImage(50, Screen.height * 0.90f, powerUpFill);
			if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Capivara)
				drawImage(50, Screen.height * 0.80f, powerUpBarraCapivara);
			
			if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Porta)
				drawImage(50, Screen.height * 0.80f, powerUpBarraPorta);
			
			if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia)	
				drawImage(50, Screen.height * 0.80f, powerUpBarraBoia);
			
			
		}
		
		// Life Bar
		drawImage(Screen.width - (lifeBar.width), Screen.height * 0.05f, lifeBar);
		drawHeart(1);
		drawHeart(2);
		drawHeart(3);
			
	}
	
	void drawHeart(int position){
		if (PlayerStatus.vida >= position)
			drawImage(Screen.width - (lifeBar.width / 2) - 180 + (position * 80), Screen.height * 0.065f, heartFull);
		else
			drawImage(Screen.width - (lifeBar.width / 2) - 180 + (position * 80), Screen.height * 0.065f, heartEmpty);	
	}
	
	void drawImage(float x, float y, Texture texture){
		GUI.DrawTexture (new Rect (x, y, texture.width, texture.height), texture);
	}
	
}
