using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public GameObject nadando;
	public GameObject boiando;
    public GameObject naPorta;
    public GameObject capivara;
	
	void Update(){
	
		// Ativando e desativando os modelos correspondentes ao PowerUp
        nadando.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Nada);
        boiando.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia);
        naPorta.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Porta);
        capivara.SetActiveRecursively(PlayerStatus.powerUp == PlayerStatus.PowerUp.Capivara);
                
        //* Pausando e Despausando a animação
        if (Director.Instance.isPaused || Director.Instance.isGameOver){
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
        //*/

        /*Pausando e Despausando a animação
        if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Nada){
		
            if (Director.Instance.isPaused){
                Time.timeScale = 0;
                GameObject.Find("Player+Nadando").animation.Stop();
            } else {
                Time.timeScale = 1;
                GameObject.Find("Player+Nadando").animation.Play();
            }
			
        } else if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			
            if (Director.Instance.isPaused){
                GameObject.Find("Player+Boia").animation.Stop();
            } else {
                GameObject.Find("Player+Boia").animation.Play();
            }
			
        } else if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Porta){
			
            if (Director.Instance.isPaused){
                GameObject.Find("Player+Porta").animation.Stop();
            } else {
                GameObject.Find("Player+Porta").animation.Play();
            }
			
        } else {
			
            if (Director.Instance.isPaused){
                GameObject.Find("toy+capivara").animation.Stop();
            } else {
                GameObject.Find("toy+capivara").animation.Play();
            }
        }
        //*/
    }
}
