using UnityEngine;
using System.Collections;
using System;

public class SplashScreen : MonoBehaviour {

    public Texture[] splashImages;
    public float[] splashDuration;

    private int pseudoFrame = 0;
    DateTime now = DateTime.Now;
    	
	void Update () {
        if (!Director.Instance.wasSplashShown)
            ShowSplash();
        else
            Application.LoadLevel(Application.loadedLevel + 1);
	}

    void OnGUI()
    {
        if (pseudoFrame < splashImages.Length)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), splashImages[pseudoFrame]);
        else
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), splashImages[splashImages.Length - 1]);
    }
	

    void ShowSplash()
    {
        TimeSpan diferenca = DateTime.Now - now;
        if (diferenca.TotalMilliseconds > splashDuration[pseudoFrame])
        {
            if (pseudoFrame + 1 >= splashImages.Length)
                Director.Instance.FinishSplash();
            pseudoFrame++;
            now = DateTime.Now;
        }

        if (Input.anyKey)
            Director.Instance.FinishSplash();
    }
}
