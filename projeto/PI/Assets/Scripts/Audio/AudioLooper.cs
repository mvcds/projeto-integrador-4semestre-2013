//---------------------------------------------------------------
//--------------- SCRIPT DE AUDIOPLAYER DE MÚSICA ---------------
//------------- ESCRITO POR RONY KETCHUM ------------------------
//------------- VERSÃO 1.2 - 08/10/2013 -------------------------
//---------------------------------------------------------------

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
	
	//variáveis para controle do pitch (Power-Ups)
	private bool pitch_up;
	private bool pitch_down;
	private int time_pitch;
	private double step_pitch;
	
	//variáveis para controle de transição alternativa
	private int indice_troca;
	private bool fade_out;
	private bool trans_alternativa;
	
	// Use this for initialization
	void Start () {
		mus_atual = 0;
		fazendo_transicao=false;
		ja_trocou = true;
		trocar = false;
		time_pitch = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		//Ativação da Transição normal
		if(trocar && !fazendo_transicao && !trans_alternativa){
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
		
		//Ativação da Transição Alternativa
		//Alterado aqui para volume de corte na metade e dobro do tempo
		if(trans_alternativa){
			if(fade_out){
				if(player.volume>0.5f){
				player.volume -=0.005f;
				}
				else{
					fade_out = false;
					player.clip = loops[indice_troca];
					mus_atual = indice_troca;
					player.volume = 0.5f;
					player.Play ();
				}
			}
			else{
				if(player.volume<1.0f){
					player.volume+=0.005f;
				}
				else{
					trans_alternativa = false;
				}
			}
		}
		
		//Faz o Loop Automático quando não tá fazendo uma transição
		if(!player.isPlaying && !fazendo_transicao && !trans_alternativa){
			player.Play ();
		}
	
		//FUNÇÃO DE TROCA ALTERNATIVA
		
		
		//------------------------------------------------------------
		//--------------- Funções de Pitch ---------------------------
		//------------------------------------------------------------
		if(pitch_up){
			player.pitch = 1.15f;
			if(step_pitch>time_pitch){
				player.pitch = 1.0f;
				pitch_up = false;
			}
			step_pitch+=Time.deltaTime;
		}
		
		if(pitch_down){
			player.pitch = 0.85f;
			if(step_pitch>time_pitch){
				player.pitch = 1.0f;
				pitch_down = false;
			}
			step_pitch+=Time.deltaTime;
		}
		
		//TESTES
		//Por motivos óbvios apagar esse bloco inteiro quando for pro game mesmo
		if(Input.GetKey(KeyCode.Z)){
			acelera ();
		}
		if(Input.GetKey(KeyCode.X)){
			diminui();
		}
		if(Input.GetKey(KeyCode.T)){
			Troca ();
		}
		if(Input.GetKey(KeyCode.Alpha1)){
			Troca (1);
		}
	    if(Input.GetKey(KeyCode.Alpha2)){
			Troca (2);
		}
		if(Input.GetKey(KeyCode.Alpha3)){
			Troca (3);
		}
	    if(Input.GetKey(KeyCode.Alpha4)){
			Troca (4);
		}
		if(Input.GetKey(KeyCode.Alpha5)){
			Troca (5);
		}
	    if(Input.GetKey(KeyCode.Alpha6)){
			Troca (6);
		}
		if(Input.GetKey(KeyCode.Alpha7)){
			Troca (7);
		}
	    if(Input.GetKey(KeyCode.Alpha8)){
			Troca (8);
		}	    
		if(Input.GetKey(KeyCode.Alpha9)){
			Troca (9);
		}
		//TESTES
	
	}
	
	
	//----------------------------------------------------------------
	//Funções Públicas, interagir com o script usando somente essas
	//rotinas.
	//----------------------------------------------------------------
	
	//Faz a troca com a transição normal (segue a ordem das músicas);
	public void Troca(){
		trocar = true; 
	}
	
	//NÃO PASSAR ZERO NESSA PORRA DE JEITO NENHUM!!!!
	public void Troca(int musica){
		this.indice_troca = musica - 1;
		this.trans_alternativa = true;
		this.fade_out = true;
	}
	
	//Aumenta a velocidade da música conforme o tempo setado anteriormente;
	public void acelera(){
		if(pitch_down){
			pitch_down = false;
		}
		pitch_up = true;
		step_pitch = 0.0f;
	}
	//Diminui a velocidade da música conforme o tempo setado anteriormente;
	public void diminui(){
		if(pitch_up){
			pitch_up = false;
		}
		pitch_down = true;
		step_pitch = 0.0f;
	}
	
	//Seta um novo tempo para os Power-Ups, diferente do padrão (atualmente 10 segundos).
	public void seta_tempo(int segundos){
		this.time_pitch = segundos;
	}
}
