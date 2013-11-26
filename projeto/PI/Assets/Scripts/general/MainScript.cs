using UnityEngine;
using System.Collections;

public class MainScript {

	public static float gameVelocity = minspeed;
	public static float floatSpeed = 1.5f;
	public static float Maxfolego = 3.0f;
	public static float folego = Maxfolego;
	public static string levelToLoad;
	public static int maxspeed = 15 ;
	public static int minspeed = 8;
	
	public static void loadLevel(string level){
		levelToLoad = level;
		Application.LoadLevel("Loading");
	}
}
