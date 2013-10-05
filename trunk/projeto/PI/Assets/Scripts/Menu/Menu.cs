using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GameController.GameStatus On = GameController.GameStatus.None;
	
	public Button[] buttons;
				
	void Awake () 
	{
		DontDestroyOnLoad(this);
	}
	
	void Update()
	{
		if (GameAsApplication.hasBegun)
			Show();
	}

	protected void Show()
	{		
		foreach(Button btn in buttons)
		{
			if (btn != null)			
				btn.Show(On == GameController.Status);
		}
	}
}
