using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public Button[] buttons;	
	public Texture2D _bgMenu = null;
	[SerializeField]
	private Rect place_size = new Rect(0,0, 0, 100);
		
	void Update()
	{
        place_size.x = place_size.x.FixForHundred();
        place_size.y = place_size.y.FixForHundred();
        place_size.width = place_size.width.FixForHundred();
        place_size.height = place_size.height.FixForHundred();
		
		Show();
	}
	
	protected virtual bool canShow
	{
		get
		{
			return true;
		}
	}

	protected void Show()
	{
		//if (!canShow)
		//	return;
		
		GUI.depth = -1;
		foreach(Button btn in buttons)
		{
			if (btn == null)
				continue;
			btn.Show(canShow);
		}
	}
	
	void OnGUI()
	{
		if (!canShow)
			return;
		
		if (_bgMenu != null)
		{
			
            Rect r = new Rect(place_size.x.FitOnWidth(), place_size.y.FitOnHeight(),
                place_size.width.FitOnWidth(), place_size.height.FitOnHeight());
			//GUI.depth = 2;
			GUI.DrawTexture(r, _bgMenu);
		}
	}
}
