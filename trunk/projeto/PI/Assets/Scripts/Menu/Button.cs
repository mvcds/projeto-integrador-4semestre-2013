using UnityEngine;
using System.Collections;
using System;

abstract public class Button : MonoBehaviour {	
	public GUIStyle _style;

    public Menu _myMenu;
	public AudioSource actived_sound,
		hover_sound;
	private static string _lastButton = "";
		
	private Texture2D _shown_image;
	
	public Rect place_size  = new Rect(0,0,100,100);
	public Texture2D actived,
					inactived,
					hover;
	protected DateTime time;
	protected bool show;

    public bool _revertShown = false;
	
	void Start()
	{
		time = DateTime.Now;
		_style.normal.background = inactived;
		_style.hover.background = hover;
		_style.active.background = actived;
	}
	
	void Update()
	{
        place_size.x = place_size.x.FixForHundred();
        place_size.y = place_size.y.FixForHundred();
        place_size.width = place_size.width.FixForHundred();
        place_size.height = place_size.height.FixForHundred();
	}
	
	private void PlaySound(AudioSource s, bool once = false){		
		
		if (once)
		{
			if (_lastButton == name)
				return;
		}
		
		if (s != null)
		{
			s.Play();
		}
		_lastButton = name;
	}
	
	public void Show(bool show)
	{
		this.show = show;
		GUI.depth = 11;
	}

    protected virtual void Action()
    {
		PlaySound(actived_sound);
        HideBottomUp();
    }


    private void HideBottomUp()
    {
        if (_myMenu == null)
            return;
        foreach (Button btn in _myMenu.buttons)
        {
            if (btn == null)
                continue;

            btn.Show(false);
        }
    }
		
	void OnGUI()
	{
		if (show)
		{
            Rect r = new Rect(place_size.x.FitOnWidth(), place_size.y.FitOnHeight(),
                place_size.width.FitOnWidth(), place_size.height.FitOnHeight());
            
			if (r.Contains(new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y)))
				PlaySound(hover_sound, true);
			
			if (GUI.Button(r, _shown_image, _style))
				Action();
		}
	}
}
