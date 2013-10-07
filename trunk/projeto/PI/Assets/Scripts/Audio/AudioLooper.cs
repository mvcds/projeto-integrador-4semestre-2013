using UnityEngine;
using System.Collections;

public class AudioLooper : MonoBehaviour {
	//Aqui é pra carregar o PreFab do AudioPlayer
	public AudioSource player;
	//Esses arrays são para colocar as músicas do game
	public AudioClip[] transicoes;
	public AudioClip[] loops;
	//Indicador para música atual
	public int mus_atual;
	//Variável para controle de troca externa
	private bool trocar;
	//Variáveis de Controle
	private bool fazendo_transicao;
	private bool ja_trocou;
	// Use this for initialization
	void Start () {
		mus_atual = 0;
		fazendo_transicao=false;
		ja_trocou = true;
		trocar = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//ATENÇÃO TIRAR A CONDICIONAL DESSE IF ABAIXO:
		//Input.GetKey(KeyCode.T)
		//QUANDO FOR PRO GAME DE VERDADE, POR MOTIVOS OBVIOS
		if((Input.GetKey (KeyCode.T) || trocar)&& !fazendo_transicao){
			if(mus_atual<8){
				mus_atual++;
			}
			else{
				mus_atual = 0;
			}
			fazendo_transicao=true;
			ja_trocou = false;
			trocar = false;
		}
		
		//------------------------------------------
		//-------- TESTES DE PITCH -----------------
		//------------------------------------------
		if(Input.GetKey (KeyCode.S)){
			player.pitch +=0.05f;
		}
		if(Input.GetKey (KeyCode.D)){
			player.pitch-=0.05f;
		}
		//------------------------------------------
		//-------- FIM DOS TESTES DE PITCH ---------
		//------------------------------------------
		
		if(fazendo_transicao){
			if(!ja_trocou){
				if(!player.isPlaying){
					if(mus_atual>0)
						player.clip = transicoes[mus_atual-1];
					else
						player.clip = transicoes[8];
					
					player.Play ();
					ja_trocou = true;
				}
			}
			else{
				if(!player.isPlaying){
					player.clip = loops[mus_atual];
					player.Play ();
					ja_trocou = false;
					fazendo_transicao = false;
				}
			}
		}
		//Faz o Loop Automático quando não tá fazendo uma transição
		if(!player.isPlaying && !fazendo_transicao){
			player.Play ();
		}
	
	}
	public void Troca(){
		trocar = true;
	}
}
