//---------------------------------------------------------------
//--------------- SCRIPT DE AUDIOPLAYER DE MÚSICA ---------------
//------------- ESCRITO POR RONY KETCHUM ------------------------
//------------- VERSÃO 1.6 - 26/11/2013 -------------------------
//---------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class AudioLooper : MonoBehaviour {
	//Aqui é pra carregar o PreFab do AudioPlayer
	public AudioSource player;
	//Esses arrays são para colocar as músicas do game
	public AudioClip[] transicoes;
	public AudioClip[] loops;
	public AudioClip Victory;
	public AudioClip GameOver;
	//Indicador para música atual
	private int mus_atual;
	//Variável para controle de troca externa
	private bool trocar;
	
	//Variáveis de Controle
	private bool fazendo_transicao;
	private bool ja_trocou;
	private float velocidade_jogo;
	//variáveis para controle do pitch (Power-Ups)
	private bool pitch_up;
	private bool pitch_down;
	private int time_pitch;
	private double step_pitch;
	
	//variáveis para controle de volume do pause
	private bool mudou;
	private float vol_mudado;
	
	//variáveis para controle de transição alternativa
	private int indice_troca;
	private bool fade_out;
	private bool trans_alternativa;
	private bool tocouend;
	public AudioSource player_amb;

	
	int distancia;
	
	// Use this for initialization
	void Start () {
		mus_atual = 0;
		fazendo_transicao=false;
		ja_trocou = true;
		trocar = false;
		time_pitch = 10;
		player.volume = 0.20f;
		tocouend = false;
		
	}
	
	// Update is called once per frame
	
	void Update(){
		//Pause
		if(Director.Instance.isPaused){
			player.volume = 0.05f;
		}
		else{
			player.volume = 0.45f;
		}
		
		if(Director.Instance.isGameOver){
			TocaGameOver();
		}
		if(Director.Instance.isEnding || Director.Instance.isVictory){
			TocaVictory();
		}
	}
	
	void FixedUpdate () {
		print ("TOCOUEND: "+tocouend.ToString());
		//Aqui eu coloco a velocidade da música conforme a velocidade do game.
		if(MainScript.gameVelocity<MainScript.maxspeed){
			velocidade_jogo = 0.90f + ((MainScript.gameVelocity-MainScript.minspeed)/50);
			trocar = false;
		}
		
		//Aqui eu verifico a distancia percorrida pra trocar a música (quando andar cada 10)
		distancia = (int) Director.Instance.GameRank.Distance+1;
		if((distancia%10)==0){
			Troca();
		}
		
		
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
			velocidade_jogo = velocidade_jogo+0.15f;
			if(step_pitch>time_pitch){
				pitch_up = false;
			}
			step_pitch+=Time.deltaTime;
		}
		
		if(pitch_down){
			velocidade_jogo = velocidade_jogo - 0.15f;
			if(step_pitch>time_pitch){
				pitch_down = false;
			}
			step_pitch+=Time.deltaTime;
		}
		
		player.pitch = velocidade_jogo;
		
		//TESTES
		//Por motivos óbvios apagar esse bloco inteiro quando for pro game mesmo
		if(Debug.isDebugBuild){
			if(Input.GetKey(KeyCode.Z)){
				acelera ();
			}
			if(Input.GetKey(KeyCode.X)){
				diminui();
			}
			if(Input.GetKey(KeyCode.T)){
				Troca ();
			}
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
	
	public void TocaGameOver(){
		fazendo_transicao=false;
		ja_trocou = true;
		trocar = false;
		player_amb.volume = 1.0f;
		player.volume = 0.01f;
		if(!tocouend){
			player_amb.clip = GameOver;
			player_amb.Play();
			tocouend = true;
			player_amb.loop = true;
		}
	}
	
	public void TocaVictory (){
		fazendo_transicao=false;
		ja_trocou = true;
		trocar = false;
		player_amb.volume = 1.0f;
		player.volume = 0.01f;
		if(!tocouend){
			player_amb.clip = Victory;
			player_amb.Play();
			tocouend = true;
			player_amb.loop = true;
		}
	}
	//Seta um novo tempo para os Power-Ups, diferente do padrão (atualmente 10 segundos).
	public void seta_tempo(int segundos){
		this.time_pitch = segundos;
	}
}
