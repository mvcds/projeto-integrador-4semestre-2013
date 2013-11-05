using UnityEngine;
using System.Collections;

//AudioAmbient V.1.1 by Rony Ket - 05/11/2013

public class AudioAmbient : MonoBehaviour {
	
			//Puxar o audiosource direto do prefab que este script está inserido
			public AudioSource player;
	
			//Puxar o aúdio correspondente a variável correta se precisar recolocar o script.
			public AudioClip chuva1;
			public AudioClip chuva2;
			public AudioClip chuva3;
			public AudioClip correnteza1;
			public AudioClip correnteza2;
			public AudioClip trovao1;
			public AudioClip trovao2;
	
			//LOL!!!!
			public AudioClip LOL;
	
			//variável para sortear som ambiente random
			private int seletor;
			//flags utilizadas para controle do som do trovão não se repetir
			private bool trovao;
			private bool correnteza;
			private bool chuva;
			private bool escolheu;
	
	// Use this for initialization
	void Start () {
		player.volume = 0.3f;
		escolheu = false;
		trovao = true;
		chuva = false;
		correnteza = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Pause
		if(Director.Instance.isPaused){
			player.volume = 0.01f;
		}
		else{
			player.volume = 0.3f;
		}
		
		//Precisa estar dentro da condicional abaixo senão nun vai tocar nada
		//(Sempre vai passar direto e trocar o som sempre).
		if (!player.isPlaying){
			escolheu = false;
			
			//Esta parte é para não deixar tocar dois trovões seguidos.
			while(!escolheu){
				seletor = Random.Range (1,8);
				if(trovao){
					if(!(seletor == 3 || seletor == 6)){
						escolheu = true;
					}
				}
				if(correnteza){
					escolheu = true;
					correnteza = false;
				}
				if(chuva){
					escolheu = true;
					correnteza = false;
				}

			}
			//Selecionando o som conforme o número sorteado
			switch(seletor){
			case 1:
				player.clip = chuva1;
				player.Play();
				chuva = true;
				correnteza = false;
				trovao = false;
				break;
			case 2:
				player.clip = correnteza1;
				player.Play();
				correnteza = true;
				chuva = false;
				trovao = false;
				break;
			case 3:
				player.clip = trovao1;
				player.Play();
				trovao = true;
				correnteza = false;
				chuva = false;
				break;
			case 4:
				player.clip = chuva2;
				player.Play();
				chuva = true;
				correnteza = false;
				trovao = false;
				break;
			case 5:
				player.clip = correnteza2;
				player.Play();
				correnteza = true;
				chuva = false;
				trovao = false;
				break;
			case 6:
				player.clip = trovao2;
				player.Play();
				trovao = true;
				correnteza = false;
				chuva = false;
				break;
			case 7:
				player.clip = chuva3;
				player.Play();
				chuva = true;
				correnteza = false;
				trovao = false;
				break;			
			}
		}
		/* 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * */
		if (PlayerStatus.vida == 2){
			player.clip = LOL;
			player.volume = 1.0f;
			player.Play();
		}
		/* 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * */

	}
}
