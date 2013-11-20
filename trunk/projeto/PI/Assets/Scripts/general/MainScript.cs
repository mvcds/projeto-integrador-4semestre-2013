using UnityEngine;
using System.Collections;

public class MainScript {

	public static float gameVelocity = 10;
	public static float floatSpeed = 1.5f;
	public static float Maxfolego = 5.0f;
	public static float folego = Maxfolego;
	public static string levelToLoad;
	
	public static void loadLevel(string level){
		levelToLoad = level;
		Application.LoadLevel("Loading");
	}
}
