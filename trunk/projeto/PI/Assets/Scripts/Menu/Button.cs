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
		this.show = show;
	}
	
	protected abstract void Action();
	
	void OnGUI()
	{
		if (show)
		{
			//TODO: MAPPING
			int x = (int) place_size.x;
			int y = (int) place_size.y;
			int width = (int) place_size.width;
			int height = (int) place_size.height;
			
			Rect r = new Rect(x, y, width, height);
			
			if (GUI.RepeatButton(r, _shown_image, new GUIStyle()))
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
