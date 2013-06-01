using UnityEngine;
using System.Collections;

public class Apresentacao : MonoBehaviour {
	
	bool finished = false;
	public Texture[] img;
	int now = 0;
	
	void OnGUI(){	
		if (!finished){
			try
			{
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
	}	
	
	private void Finish()
	{		
		GamePlay.Instance.ShowHUD();
		GamePlay.Instance.UnlockPlayer();
		finished = true;
	}
}
