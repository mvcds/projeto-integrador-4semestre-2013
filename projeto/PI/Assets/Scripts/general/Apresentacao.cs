using UnityEngine;
using System.Collections;
using System;

public class Apresentacao : MonoBehaviour {
	
	bool finished = false;
	public Texture[] img;
	int now = 0;
	
	void OnGUI(){	
		if (!finished){
			try
			{				
				if (GamePlay.Instance.canShowHUD)
				{
					throw new Exception();
				}
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), img[now]);
			}
			catch
			{
				Finish();
			}			
		}
	}
	
	void Update(){
		if (!finished)
		{
			if (Input.anyKeyDown)
			{
				if (now + 1 >= img.Length)
				{
					Finish();
				}
				now++;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				CameraFade.StartAlphaFade( Color.white, false, 1f, 0f, () => {
					GamePlay.Instance.recoverHealth(GamePlay.Instance.getMaxHealth());
					//GuardaChuva.Reset();
					//CameraFade.StartAlphaFade( Color.clear, false, 1f, 0f, () => {												
						
					//});
					Application.LoadLevel(1);
				});
			}
		}
	}	
	
	private void Finish()
	{		
		GamePlay.Instance.ShowHUD();
		GamePlay.Instance.UnlockPlayer();
		finished = true;
	}
}
