using UnityEngine;
using System.Collections;

//AudioAmbient V.1.0 by Rony Ket - 04/11/2013

public class AudioAmbient : MonoBehaviour {
			public AudioSource player;
			public AudioClip chuva1;
			public AudioClip chuva2;
			public AudioClip chuva3;
			public AudioClip correnteza1;
			public AudioClip correnteza2;
			public AudioClip trovao1;
			public AudioClip trovao2;
			public AudioClip LOL;
			private int seletor;
			private bool trovao;
			private bool correnteza;
			private bool chuva;
			private bool escolheu;
	// Use this for initialization
	void Start () {
		player.volume = 0.5f;
		escolheu = false;
		trovao = true;
		chuva = false;
		correnteza = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!player.isPlaying){
			escolheu = false;
			while(!escolheu){
				seletor = Random.Range (1,8);
				if(correnteza){
					if(!(seletor == 2 || seletor == 5)){
						escolheu = true;
					}
				}
				if(trovao){
					if(!(seletor == 3 || seletor == 6)){
						escolheu = true;
					}
				}
				if(chuva){
					if(!(seletor == 1 || seletor == 4 || seletor == 7)){
						escolheu = true;
					}
				}
			}
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
