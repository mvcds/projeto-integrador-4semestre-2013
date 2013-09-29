using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpeachEvent))]
public class SpeachItem : MonoBehaviour {
	
	public SpeachFace Face1, Face2;
	public string Speach1 = "", Speach2 = "";
	public Rect SpeachPosition1, SpeachPosition2;
	private bool _show = false;
		
	void Update()
	{
		if (!_show)
			return;
				
		SpeachPosition1.x = ScreenUtil.FixForHundred(SpeachPosition1.x);
		SpeachPosition1.y = ScreenUtil.FixForHundred(SpeachPosition1.y);			
		SpeachPosition1.width = ScreenUtil.FixForHundred(SpeachPosition1.width);
		SpeachPosition1.height = ScreenUtil.FixForHundred(SpeachPosition1.height);
		
		SpeachPosition2.x = ScreenUtil.FixForHundred(SpeachPosition2.x);
		SpeachPosition2.y = ScreenUtil.FixForHundred(SpeachPosition2.y);	
		SpeachPosition2.width = ScreenUtil.FixForHundred(SpeachPosition2.width);
		SpeachPosition2.height = ScreenUtil.FixForHundred(SpeachPosition2.height);
	}
	
	void FixedUpdate()
	{
		_show = false;
	}
	
	void OnGUI()
	{
		if (!_show)
			return;
		
		try
		{
			Show(Face1, SpeachPosition1, Speach1);
		}
		catch
		{
		}
		
		try
		{
			Show(Face2, SpeachPosition2, Speach2);
		}
		catch
		{
		}
	}
	
	public void Show()
	{
		_show = true;
	}
	
	private void Show(SpeachFace face, Rect position, string speach)
	{
		if (face != null)
			face.Show();
		
		if (!string.IsNullOrEmpty(speach))
		{
			speach = speach.Trim();
			
			Rect speachPosition = new Rect(ScreenUtil.FitOnWidth(position.x), ScreenUtil.FitOnHeight(position.y),
				ScreenUtil.FitOnWidth(position.width), ScreenUtil.FitOnHeight(position.height));
			
			GUI.Label(speachPosition, speach);
		}
	}
}
