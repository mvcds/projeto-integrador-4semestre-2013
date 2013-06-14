using UnityEngine;
using System.Collections;

public static class GuardaChuva{
	private static bool gc  = false;
	private static bool cdAtivo = false;
	static float tGC  = 0;//tempo de guarda-chuva ativo
	static float tDuracao = 10;// tempo de duração do guarda-chuva aberto
	static float tCD = 5; //tempo de cooldown do guarda-chuva
	static float cdGC  = 0;
	
	public static void abrirGC(){		
		if(Input.GetKeyDown(KeyCode.E )){
			if(cdGC <= 0){
				if (gc){
					Debug.Log("Fechando gc");
					gc = false;
					tGC = 0;
					cdGC = tCD;
				   	cdAtivo = true;
					//animação de guarda chva fechando AQUI
				}else{
					Debug.Log("Abrindo gc");
					gc = true;
					//animação de guarda-chuva abrindo AQUI
				}
			}else{
				Debug.Log("Cooldown de GC correndo");
			}
		}
	}
	
	public static void verificaGC(){
		if(gc){
			tGC += Time.deltaTime;
			if(tGC >= tDuracao){
				Debug.Log("Fechando guarda chuva por fim de tempo de ativacaoo");
				gc = false;
				tGC = 0;
				cdGC = tCD;
			   	cdAtivo = true;
				//animação de guarda chva fechando AQUI
			}
			
		}else{
			if(cdAtivo && cdGC > 0){
				cdGC -= Time.deltaTime;
			}
			if(cdGC < 0){
				cdAtivo = false;
			}
		}	
	}
	
	public static bool getGC(){
		return gc;
	}
}
