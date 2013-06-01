using UnityEngine;
using System.Collections;

	public class HUD : MonoBehaviour {
		
		public Texture2D star;
		public GUIStyle customBox;
		public GUIStyle customBox2;
		private Texture2D greenBar;
		private Texture2D redBar;
		private Texture2D greenBorder;
		private Texture2D redBorder;
	
		private Texture2D moneyOn;
		private Texture2D moneyOff;
		private Texture2D umbOn;
		private Texture2D umbOff;
		private Texture2D diveOn;
		private Texture2D diveOff;
		private bool moneyDisplay;
	    private bool diveDisplay;
		private bool umbDisplay;
			
		private Texture2D redTimer;
		private Texture2D greenTimer;
		public Font font;
	
		private Texture2D pauseContinue;
		private Texture2D pauseExit;
			
		// Use this for initialization
		void Start () {
		
		
			greenBar = (Texture2D)Resources.Load("Images/HUD/LifeBar/greenBar");
			redBar = (Texture2D)Resources.Load("Images/HUD/LifeBar/redBar");
			greenBorder = (Texture2D)Resources.Load("Images/HUD/LifeBar/greenBorder");
			redBorder = (Texture2D)Resources.Load("Images/HUD/LifeBar/redBorder");
		
			moneyOn = (Texture2D)Resources.Load("Images/HUD/Inventory/moneyOn");
			moneyOff = (Texture2D)Resources.Load("Images/HUD/Inventory/moneyOff");
			umbOn = (Texture2D)Resources.Load("Images/HUD/Inventory/umbOn");
			umbOff = (Texture2D)Resources.Load("Images/HUD/Inventory/umbOff");
			diveOn = (Texture2D)Resources.Load("Images/HUD/Inventory/diveOn");
			diveOff = (Texture2D)Resources.Load("Images/HUD/Inventory/diveOff");
		
			greenTimer = (Texture2D)Resources.Load("Images/HUD/Timer/greenTimer");
			redTimer = (Texture2D)Resources.Load("Images/HUD/Timer/redTimer");
		
			pauseContinue = (Texture2D)Resources.Load("Images/HUD/Pause/pauseContinue");
			pauseExit = (Texture2D)Resources.Load("Images/HUD/Pause/pauseExit");
		
		
		}
		
		void OnGUI(){
			if (!GamePlay.Instance.canShowHUD)
				return;
			// QUEST
			if (GamePlay.Instance.PlayerQuest != null){
			
				GUIStyle myStyle = new GUIStyle();
				myStyle.font = font;
				myStyle.fontSize = 22;
			
				if (GamePlay.Instance.PlayerQuest.Timer.checkTime()){
					// Cabo o tempo da quest
					GamePlay.Instance.QuestById((uint)GamePlay.Instance.PlayerQuest.ID).Failure();
				}
				if (GamePlay.Instance.PlayerQuest.Timer.getMinutos() == 0 & GamePlay.Instance.PlayerQuest.Timer.getSegundos() < 20){
					GUI.Label (new Rect (Screen.width / 2 - (redTimer.width / 2), 5, redTimer.width, redTimer.height), redTimer);
					myStyle.normal.textColor = Color.white;
				} else {
					GUI.Label (new Rect (Screen.width / 2 - (greenTimer.width / 2), 5, greenTimer.width, greenTimer.height), greenTimer);
			    }
			
				GUI.Box (new Rect (Screen.width / 2 - (greenTimer.width / 2) + 15, 23, 120, 30), GamePlay.Instance.PlayerQuest.Timer.getTempo(), myStyle);
				
				GUI.Box (new Rect (Screen.width - 200, Screen.height / 2, 200, 150), GamePlay.Instance.PlayerQuest.Name);
				GUI.Label (new Rect ( Screen.width - 180, Screen.height / 2 + 20, 180, 150), GamePlay.Instance.PlayerQuest.Description);
			} 
			
			// HEALTH BAR
			if (GamePlay.Instance.getHealth() > GamePlay.Instance.getMaxHealth() / 5){
				customBox.normal.background = greenBar;
				customBox2.normal.background = greenBorder;	
			
			} else {
				customBox.normal.background = redBar;
				customBox2.normal.background = redBorder;	
			}
			GUI.Box (new Rect (Screen.width - 409, 20, (GamePlay.Instance.getHealth() * GamePlay.Instance.getMaxHealth() * 4) / 100 , 30), "", customBox);
			GUI.Box (new Rect (Screen.width - 410, 10, 400, 50), "", customBox2);
			
			// INVENTORY
			if (GuardaChuva.getGC()){
				if (GUI.Button (new Rect ( 20, Screen.height - 20 - umbOn.height, umbOn.width, umbOn.height), umbOn, new GUIStyle() )){
					umbDisplay = false;
				}
			} else {
				if (GUI.Button (new Rect ( 20, Screen.height - 20 - umbOff.height, umbOff.width, umbOff.height), umbOff, new GUIStyle() )){
					umbDisplay = true;
				}
			}
		
			if (moneyDisplay){
				if (GUI.Button (new Rect ( 30 + moneyOn.width, Screen.height - 20 - moneyOn.height, moneyOn.width, moneyOn.height), moneyOn, new GUIStyle())){
					moneyDisplay = false;
				}
			} else {
				if (GUI.Button (new Rect ( 30 + moneyOff.width, Screen.height - 20 - moneyOff.height, moneyOff.width, moneyOff.height), moneyOff, new GUIStyle())){
					moneyDisplay = true;
				}
			}
			
			if (diveDisplay){
				if (GUI.Button (new Rect ( 40 + (diveOn.width * 2), Screen.height - 20 - diveOn.height, diveOn.width, diveOn.height), diveOn, new GUIStyle())){
					diveDisplay = false;
				}
			} else {
				if (GUI.Button (new Rect ( 40 + (diveOff.width * 2), Screen.height - 20 - diveOff.height, diveOff.width, diveOff.height), diveOff, new GUIStyle())){
					diveDisplay = true;
				}
			}
		
			// PAUSE
			if (GamePlay.Instance.isPaused){
				
				if (GUI.Button( new Rect ( Screen.width / 2 - (pauseContinue.width / 2) - 100, Screen.height / 2 - 80, pauseContinue.width, pauseContinue.height), pauseContinue, new GUIStyle())){
					GamePlay.Instance.Pause(false);
					GameObject.Find("Background Camera").camera.enabled = GamePlay.Instance.isPaused;
			
				}
				if (GUI.Button (new Rect ( Screen.width / 2 - (pauseExit.width / 2) + 100, Screen.height / 2 - 80, pauseExit.width, pauseExit.height), pauseExit, new GUIStyle())){
					Application.Quit();
				}
			}
		
		
		}
		
		
		// Update is called once per frame
		void Update () {
			/*if (vida >= 0){
				vida--;
			}*/
			
			
			// QUEST
			if (GamePlay.Instance.PlayerQuest != null){
				if (GamePlay.Instance.PlayerQuest.Timer.checkTime()){
			    	//TODO: timer's behaviour
				//GamePlay.Instance.PlayerQuest.MakeAvailable();
					//GamePlay.Instance.PlayerQuest = null;
					
				}
			}
		}
	}