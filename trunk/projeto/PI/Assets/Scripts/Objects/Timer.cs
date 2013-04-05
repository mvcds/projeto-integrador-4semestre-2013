using UnityEngine;
using System.Collections;

public class QuestTimer {

	private static long tempo;
	private static int secs;
	   
    public QuestTimer(int segundos){
        secs = segundos;
    }
	
	public void Run()
	{
		tempo = (long)Time.time;
	}
	
    public bool checkTime() {
        if ((int)(secs - (Time.time - tempo))%60 <= 0){
            if ((int)(secs - (Time.time - tempo))/60 <= 0){
                // Acabou o tempo da quest
                return true;
            }
        }
		return false;
    }
	
	
    public int getSegundos(){
        return (int)(secs - (Time.time - tempo))%60 ;
    }
    
    public int getMinutos(){
        return (int)(secs - (Time.time - tempo))/60 ;
    }
	
	public string getTempo(){
		string t;
		
		if (getSegundos() >= 0){
			t = string.Format ("{0:00} : {1:00}", getMinutos(), getSegundos());
		} else {
			t = "00 : 00";
		}
		 
		return t;
	}
}
