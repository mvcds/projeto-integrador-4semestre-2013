using UnityEngine;
using System.Collections;
using System;

abstract public class Button : MonoBehaviour {
	
	public enum States
	{
		Inactived,
		Hover,
		Actived
	}
		
	private States _state;
	
	public AudioSource actived_sound,
		hover_sound;
	private AudioSource _sound;
	
	public States State
	{
		get {return _state;}
		protected set {_state = value;}
	}
	
	private Texture2D _shown_image;
	
	public Rect place_size  = new Rect(0,0,100,100);
	public Texture2D actived,
					inactived,
					hover;
	protected DateTime time;
	protected bool show;
	
	void Start()
	{
		time = DateTime.Now;
		_state = States.Inactived;
	}
	
	void Update()
    {
        place_size.x = place_size.x.FixForHundred();
        place_size.y = place_size.y.FixForHundred();
        place_size.width = place_size.width.FixForHundred();
        place_size.height = place_size.height.FixForHundred();

		ChangeTexture();
	}
	
	protected void ChangeTexture()
	{
		switch (State)
		{
			case States.Hover:
				PlaySound(hover_sound);	
				_shown_image = hover;
			break;
			case States.Inactived:
				PlaySound(null);
				_shown_image = inactived;
			break;
			case States.Actived:
				PlaySound(actived_sound);
				_shown_image = actived;
				Action();
			break;
		}
	}
	
	private void PlaySound(AudioSource s){		
		if (s == _sound)
			return;
		
		if (s != null)
		{
			//TODO: ajustar pitch de acordo com configuração
			s.Play();
		}
		_sound = s;
	}
	
	
	public void Show(bool show)
	{
		GUI.depth = 1;
		this.show = show;
	}
	
	protected abstract void Action();
		
	void OnGUI()
	{
		if (show)
		{
            Rect r = new Rect(place_size.x.FitOnWidth(), place_size.y.FitOnHeight(),
                place_size.width.FitOnWidth(), place_size.height.FitOnHeight());
            
			GUIStyle s = new GUIStyle();
			s.border = new RectOffset(0, 0,0,0);
			s.padding = new RectOffset(0,0,0,0);
			s.margin = new RectOffset(0,0,0,0);
			
			if (GUI.RepeatButton(r, _shown_image, s))
				State = States.Actived;
			else if (isMouseOver(r))
				State = States.Hover;
			else
				State = States.Inactived;
		}
	}
	
	private bool isMouseOver(Rect r)
	{		
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.y = Screen.height - mousePosition.y;
		return (r.Contains(mousePosition));
	}
}
