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
	
	public static PowerUp powerUpAtual = PowerUp.Nada;
	public static int vida = 3;
	public static int maxVida = 3;
	public static int block = 0;
	
	public static float duration = 0;
	public static float maxDuration = 30;
	
	// Use this for initialization
	void Start () {
		reset ();
	}

	// Update is called once per frame
	void Update () {
		if (duration > 0){
			duration -= Time.deltaTime;
			
		} else {
			
			if (powerUpAtual == PowerUp.Boia)
				MainScript.gameVelocity *= MainScript.floatSpeed;
			
			duration = 0;
			block = 0;
			powerUpAtual = PowerUp.Nada;
		}
	}
	
	// Acertado por um obstáculo
	public static void gotHit(){
		if (block > 0){
			block --;
			if (block == 0){
				
				if (powerUpAtual == PowerUp.Boia)
					MainScript.gameVelocity *= MainScript.floatSpeed;
				
				powerUpAtual = PowerUp.Nada;
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
		if ((PowerUp)pwerUp == PowerUp.Boia && powerUpAtual == PowerUp.Boia){
			// Se o powerUp que foi pego é a boia, e o atual tbm, faz nada
		} else if ((PowerUp)pwerUp == PowerUp.Boia && powerUpAtual != PowerUp.Boia){
			// Se o PowerUp que foi pego é a boia, e o atual não for a boia, diminue a velocidade
			MainScript.gameVelocity /= MainScript.floatSpeed;
		} else if (powerUpAtual == PowerUp.Boia){
			// Se o PowerUp que foi pego não é a boia, e o atual é a boia, volta para a velocidade normal
			MainScript.gameVelocity *= MainScript.floatSpeed;
		}
		
		powerUpAtual = (PowerUp)pwerUp;
		
		// Blocks
		if (powerUpAtual == PowerUp.Boia || powerUpAtual == PowerUp.Porta || powerUpAtual == PowerUp.Capivara){
			block = 1;
		} else if (powerUpAtual == PowerUp.Geladeira) {
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
        Director.Instance.GameOver();
	}
	
	private static void reset(){
		//*TODO: acho que pode tirar, pois está recarregando a fase; ver funcionamento
        vida = 3;
		maxVida = 3;
		block = 0;
		powerUpAtual = PowerUp.Nada;
		
		duration = 0;
		maxDuration = 30;
        //*/
		MainScript.gameVelocity = 5;
	}
	
	// HitAnimation
	private static void hitAnimation(){
		
	}
}
