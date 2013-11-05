using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//AudioSelecter V.1.2 by Rony Ket - 05/11/2013

[RequireComponent(typeof(AudioSource))]
public class AudioSelecter: MonoBehaviour {
	
	public AudioSource player_efeitos;
	
	
	//Adicionar ou remover itens aqui conforme a necessidade do game.
	
	//Obstaculos
	public AudioClip ArvoreCaida;
	public AudioClip Carro1;
	public AudioClip Caminhao;
	public AudioClip Carro;
	public AudioClip Carro2;
	public AudioClip Cacamba;
	public AudioClip Entulho;
	public AudioClip Fio;
	public AudioClip Lixo;
	public AudioClip Portao;
	public AudioClip Poste;
	//PowerUps
	public AudioClip Boia;
	public AudioClip Capivara;
	public AudioClip Geladeira;
	public AudioClip Porta;
	//Diversos
	public AudioClip Patinho;
	

	
	//PARA OS SONS DE POWERUP E GRUNHIDO DE DOR:
	//Precisam ser feitos em dois AudioSources Diferentes
	//Para não cortar o audio da colisão com o som correspondente
	
	public AudioSource hits_player;
	public AudioClip[] dor;
	public AudioClip powerup;
	
	//Aqui eu tenho um vetor de sons de dores.
	//Sorteio conforme os demais para naõ repetir.
	void PlayDor(){
		int max = dor.Length;
		int selecionado = (int) Random.Range (0.0f,max);
		hits_player.clip = dor[selecionado];
		hits_player.Play ();
	}
	
	//Som de PowerUp só vai ter um... Toca Direto mesmo
	public void PlayPowerUp(){
		hits_player.clip = powerup;
		
		hits_player.Play();
	}
		
	void OnTriggerEnter(Collider other) {
		
		//SEMPRE resetar o volume e o pitch por causa do random do som do patinho
		player_efeitos.volume = 1;
		player_efeitos.pitch = 1.0f;
		
		//O Algoritmo funciona descobrindo o nome do PreFab com o qual o Player se colidiu e tem esse
		//Select para tocar o som correspondente.
		switch(other.name)
		{
			case "ArvoreCaida":
				player_efeitos.clip = ArvoreCaida;
				PlayDor();
			break;
			
			case "Carro1":
				player_efeitos.clip = Carro1;
			PlayDor();
			break;
			
			case "Carro":
				player_efeitos.clip = Carro;
			PlayDor();
			break;
			
			case "Carro2":
				player_efeitos.clip = Carro2;
			PlayDor();
			break;
			
			case "Caçamba":
				player_efeitos.clip = Cacamba;
			PlayDor();
			break;
			
			case "Caminhao":
				player_efeitos.clip = Caminhao;
			PlayDor();
			break;
			
			case "Entulho":
				player_efeitos.clip = Entulho;
			PlayDor();
			break;
			
			case "Fio":
				player_efeitos.clip = Fio;
			PlayDor();
			break;
			
			case "Lixo":
				player_efeitos.clip = Lixo;
			PlayDor();
			break;
			
			case "Portao":
				player_efeitos.clip = Portao;
			PlayDor();
			break;
			
			case "Poste":
				player_efeitos.clip = Poste;
			PlayDor();
			break;
			
			case "Capivara":
				player_efeitos.clip = Capivara;
			PlayPowerUp();
			break;
			
			case "Boia":
				player_efeitos.clip = Boia;
			PlayPowerUp();
			break;				

			case "Geladeira":
				player_efeitos.clip = Geladeira;
			PlayPowerUp();
			break;
			
			case "Porta":
				player_efeitos.clip = Porta;
			PlayPowerUp();
			break;				
			
			case "Patinho":
				player_efeitos.pitch = Random.Range (0.8f,1.3f);
				player_efeitos.clip = Patinho;
			break;
			
			//Se colidir com algo estranho saberemos e não será tocado som
			default:
				Debug.Log(other.name);
				return;
		}
		//Se não sair no som estranho, toda vez será tocado um audio.
		player_efeitos.Play();
    }
}
