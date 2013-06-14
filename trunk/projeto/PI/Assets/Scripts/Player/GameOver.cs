using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	int gameOverLevel = 2;
	bool gameover = false;
	
	void Update () {
		if (Application.loadedLevelName.Equals("GameOver")){
			if (!gameover)
			{		
				GamePlay.Instance.recoverHealth (GamePlay.Instance.getMaxHealth());
				CameraFade.StartAlphaFade(Color.clear, false, 0f, 0f, () => {
				});
				gameover = true;
			}
		}
		else 
		{
			if (GamePlay.Instance.getHealth() <= 0 && !gameover){
				gameover = true;
				CameraFade.StartAlphaFade(Color.red, false, 1f, 0f, () => {
					Application.LoadLevel(gameOverLevel);
				});
				
			}
		}
	}
}
