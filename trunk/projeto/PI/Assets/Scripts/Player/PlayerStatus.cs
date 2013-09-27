using UnityEngine;
using System.Collections;
	
public class PlayerStatus : MonoBehaviour {

	public enum PowerUp {
		Nada = -1,
		Boia,
		Porta,
		Geladeira,
		Capivara
	}
	
	public static PowerUp powerUp = PowerUp.Nada;
	public static int vida = 3;
	public static int maxVida = 3;
	public static int block = 0;
	
	private static float duration = 0;
	private static float maxDuration = 30;
	
	// Use this for initialization
	void Start () {
		reset ();
	}

	// Update is called once per frame
	void Update () {
		if (duration > 0){
			duration -= Time.deltaTime;
			
		} else {
			
			if (powerUp == PowerUp.Boia)
				MainScript.gameVelocity *= MainScript.floatSpeed;
			
			duration = 0;
			block = 0;
			powerUp = PowerUp.Nada;
		}
	}
	
	void OnGUI(){
		if (!GameAsApplication.isRunning)
			return;
			
		if (duration > 0)
			GUI.Box(new Rect(10, 10, 120, 25), "PowerUp: " + (int)(duration + 1) + " / " + maxDuration);
		GUI.Box(new Rect(Screen.width - 100, 10, 100, 25), "Vida: " + (int)vida + " / " + maxVida);
		GUI.Box(new Rect(Screen.width / 2 - 60, 10, 120, 25), "Velocidade: " + (int)MainScript.gameVelocity);
	}
	
	// Acertado por um obstáculo
	public static void gotHit(){
		if (block > 0){
			block --;
			if (block == 0){
				
				if (powerUp == PowerUp.Boia)
					MainScript.gameVelocity *= MainScript.floatSpeed;
				
				powerUp = PowerUp.Nada;
				duration = 0;
				
			}
		} else {
			vida--;
			if (vida < 1){
				gameOver();
			} else {
				hitAnimation();
			}
		}
	}
	
	public static void gotPowerUp(int pwerUp){
		
		// ----- BOIA -----
		if ((PowerUp)pwerUp == PowerUp.Boia && powerUp == PowerUp.Boia){
			// Se o powerUp que foi pego é a boia, e o atual tbm, faz nada
		} else if ((PowerUp)pwerUp == PowerUp.Boia && powerUp != PowerUp.Boia){
			// Se o PowerUp que foi pego é a boia, e o atual não for a boia, diminue a velocidade
			MainScript.gameVelocity /= MainScript.floatSpeed;
		} else if (powerUp == PowerUp.Boia){
			// Se o PowerUp que foi pego não é a boia, e o atual é a boia, volta para a velocidade normal
			MainScript.gameVelocity *= MainScript.floatSpeed;
		}
		
		powerUp = (PowerUp)pwerUp;
		
		// Blocks
		if (powerUp == PowerUp.Boia || powerUp == PowerUp.Porta || powerUp == PowerUp.Capivara){
			block = 1;
		} else if (powerUp == PowerUp.Geladeira) {
			block = 2;
		} else {
			block = 0;
		}
		
		duration = 30;
	}
	
	// Caiu no Bueiro
	public static void bueiro(){
		// TODO: Animação do Bueiro
		gameOver();
	}
	
	// GameOver
	private static void gameOver(){
		reset();
		Application.LoadLevel(Application.loadedLevel);
	}
	
	private static void reset(){
		vida = 3;
		maxVida = 3;
		block = 0;
		powerUp = PowerUp.Nada;
		
		duration = 0;
		maxDuration = 30;
		MainScript.gameVelocity = 5;
	}
	
	// HitAnimation
	private static void hitAnimation(){
		
	}
}
