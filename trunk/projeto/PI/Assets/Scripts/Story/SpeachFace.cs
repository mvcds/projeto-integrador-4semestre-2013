using UnityEngine;
using System.Collections;

public class SpeachFace : MonoBehaviour {
	
	public Texture Image;
	public Rect Position;
	[SerializeField] private bool _show = false;
	[SerializeField] private bool _lockForTest = false;
		
	void Update()
	{	
		if (!_show)
			return;
		
		Position.x = Position.x.FixForHundred();
        Position.y = Position.y.FixForHundred();			
		Position.width = Position.width.FixForHundred(true);
        Position.height = Position.height.FixForHundred(true);
	}
		
	void OnGUI()
	{	
		if (!_show)
			return;

        Rect imagePosition = new Rect(Position.x.FitOnWidth(), Position.y.FitOnHeight(),
            Position.width.FitOnWidth(), Position.height.FitOnHeight());		
		
		GUI.DrawTexture (imagePosition, Image);
	}
	
	void FixedUpdate()
	{
		if (!_lockForTest)
			_show = false;
	}
	
	public void Show()
	{
		_show = true;
	}
}
