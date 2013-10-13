using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public Button[] buttons;
	
	void Update()
	{
		Show();
	}

	protected void Show()
	{
		foreach(Button btn in buttons)
		{
			if (btn == null)
				continue;
			btn.Show(true);
		}
	}
}
