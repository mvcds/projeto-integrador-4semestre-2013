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
		
		Position.x = ScreenUtil.FixForHundred(Position.x);
		Position.y = ScreenUtil.FixForHundred(Position.y);			
		Position.width = ScreenUtil.FixForHundred(Position.width, true);
		Position.height = ScreenUtil.FixForHundred(Position.height, true);	
	}
		
	void OnGUI()
	{	
		if (!_show)
			return;
		
		Rect imagePosition = new Rect(ScreenUtil.FitOnWidth(Position.x), ScreenUtil.FitOnHeight(Position.y),
			ScreenUtil.FitOnWidth(Position.width), ScreenUtil.FitOnHeight(Position.height));		
		
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
