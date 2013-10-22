using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class AudioSelecter: MonoBehaviour {
	
	public AudioSource player_efeitos;
	
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
	
	public AudioClip Boia;
	public AudioClip Capivara;
	public AudioClip Geladeira;
	public AudioClip Porta;
	
	public AudioClip Patinho;
		
	void OnTriggerEnter(Collider other) {
		
		player_efeitos.volume = 1;
		
		switch(other.name)
		{
			case "ArvoreCaida":
				player_efeitos.clip = ArvoreCaida;
			break;
			
			case "Carro1":
				player_efeitos.clip = Carro1;
			break;
			
			case "Carro":
				player_efeitos.clip = Carro;
			break;
			
			case "Carro2":
				player_efeitos.clip = Carro2;
			break;
			
			case "Caçamba":
				player_efeitos.clip = Cacamba;
			break;
			
			case "Caminhao":
				player_efeitos.clip = Caminhao;
			break;
			
			case "Entulho":
				player_efeitos.clip = Entulho;
			break;
			
			case "Fio":
				player_efeitos.clip = Fio;
			break;
			
			case "Lixo":
				player_efeitos.clip = Lixo;
			break;
			
			case "Portao":
				player_efeitos.clip = Portao;
			break;
			
			case "Poste":
				player_efeitos.clip = Poste;
			break;
			
			case "Capivara":
				player_efeitos.clip = Capivara;
			break;
			
			case "Boia":
				player_efeitos.clip = Boia;
			break;				

			case "Geladeira":
				player_efeitos.clip = Geladeira;
			break;
			
			case "Porta":
				player_efeitos.clip = Porta;
			break;				
			
			case "Patinho":
				player_efeitos.clip = Patinho;
			break;
			
			default:
				Debug.Log(other.name);
				return;
		}
		player_efeitos.Play();
    }
}
