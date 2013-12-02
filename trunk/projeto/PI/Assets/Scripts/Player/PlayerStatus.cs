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
	public static int vida;
	public static int maxVida = 3;
	public static int block = 0;

	public static float duration;
	public static float maxDuration = 30;
	
	// Use this for initialization
	void Start () {
		Reset();
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

    public static void gotPowerUp(PowerUp gotten)
    {
		// ----- BOIA -----
		if (gotten == PowerUp.Boia && powerUp == PowerUp.Boia){
			// Se o powerUp que foi pego é a boia, e o atual tbm, faz nada
		} else if (gotten == PowerUp.Boia && powerUp != PowerUp.Boia){
			// Se o PowerUp que foi pego é a boia, e o atual não for a boia, diminue a velocidade
			MainScript.gameVelocity /= MainScript.floatSpeed;
		} else if (powerUp == PowerUp.Boia){
			// Se o PowerUp que foi pego não é a boia, e o atual é a boia, volta para a velocidade normal
			MainScript.gameVelocity *= MainScript.floatSpeed;
		}
		
		powerUp = gotten;
		
		// Blocks
		if (powerUp == PowerUp.Boia || powerUp == PowerUp.Porta || powerUp == PowerUp.Capivara){
			block = 1;
		} else if (powerUp == PowerUp.Geladeira) {
			block = 2;
		} else {
			block = 0;
		}
		
		/*
		if (powerUp == PowerUp.Porta)
			gotDoor();*/
		
		duration = maxDuration;
	}
	
	// Caiu no Bueiro
	public static void bueiro(){
		// TODO: Animação do Bueiro
		gameOver();
	}
	
	// GameOver
	private static void gameOver(){
		Director.Instance.GameOver(false);
	}
	
	private static void Reset()
    {
        vida = maxVida;
        duration = maxDuration;
        block = 0;
        powerUp = PowerUp.Nada;
		MainScript.gameVelocity = MainScript.minspeed;
		MainScript.folego = MainScript.Maxfolego;
	}
	
	// HitAnimation
	private static void hitAnimation(){
		
	}
}
