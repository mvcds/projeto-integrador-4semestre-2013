using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioProx: MonoBehaviour {
	
	static AudioSource[] sources;
	
	//Obstaculos
	static AudioClip cachorro;
	static AudioClip caminhao;
	static AudioClip carro1;
	static AudioClip carro2;
	static AudioClip portao;
	
	string Path1 = "Sounds/Proximo/";
	
	void Start()
	{
		sources = new AudioSource[5];
		
		for (int i = 0; i < 5; i++){
			sources[i] = gameObject.AddComponent<AudioSource>();
		}
		
		cachorro = (AudioClip)Resources.Load(Path1 + "Cachorro_prox");
		caminhao = (AudioClip)Resources.Load(Path1 + "Caminhao_prox");
		carro1 = (AudioClip)Resources.Load(Path1 + "Carro1_prox");
		carro2 = (AudioClip)Resources.Load(Path1 + "Carro2_prox");
		portao = (AudioClip)Resources.Load(Path1 + "Portao_prox");
	}
	
	// Plays
	public static void playCachorro()
	{
		//print ("Tocando Som do Cachorro");
		sources[1].clip = cachorro;
		sources[1].Play();
	}
	
	public static void playCaminhao()
	{
		sources[2].clip = caminhao;
		sources[2].Play();
	}
	
	public static void playCarro1()
	{
		sources[3].clip = carro1;
		sources[3].Play();
	}
	
	public static void playCarro2()
	{
		sources[4].clip = carro2;
		sources[4].Play();
	}
	
	public static void playPortao()
	{
		sources[0].clip = portao;
		sources[0].Play();
	}
	
	// Volumes
	public static void setVolumeCachorro(float vol)
	{
		if(Director.Instance.isRunning){
			
		sources[1].volume = vol;
		}
		else{
			sources[1].volume = 0.01f;
		}
	}
	
	public static void setVolumeCaminhao(float vol)
	{
		if(Director.Instance.isRunning){
			
		sources[2].volume = vol;
		}
		else{
			sources[2].volume = 0.01f;
		}
	}
	
	public static void setVolumeCarro1(float vol)
	{
		if(Director.Instance.isRunning){
			
		sources[3].volume = vol;
		}
		else{
			sources[3].volume = 0.01f;
		}
	}
	
	public static void setVolumeCarro2(float vol)
	{
		if(Director.Instance.isRunning){
			
		sources[4].volume = vol;
		}
		else{
			sources[4].volume = 0.01f;
		}
	}
	
	public static void setVolumePortao(float vol)
	{
		if(Director.Instance.isRunning){
			
		sources[0].volume = vol;
		}
		else{
			sources[0].volume = 0.01f;
		}
	}
}
