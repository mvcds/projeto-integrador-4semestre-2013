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

        SpeachPosition1.x = SpeachPosition1.x.FixForHundred();
        SpeachPosition1.y = SpeachPosition1.y.FixForHundred();
        SpeachPosition1.width = SpeachPosition1.width.FixForHundred();
        SpeachPosition1.height = SpeachPosition1.height.FixForHundred();

        SpeachPosition2.x = SpeachPosition2.x.FixForHundred();
        SpeachPosition2.y = SpeachPosition2.y.FixForHundred();
        SpeachPosition2.width = SpeachPosition2.width.FixForHundred();
        SpeachPosition2.height = SpeachPosition2.height.FixForHundred();
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
			
			Rect speachPosition = new Rect(position.x.FitOnWidth(), position.y.FitOnHeight(),
				position.width.FitOnWidth(), position.height.FitOnHeight());
			
			GUI.Label(speachPosition, speach);
		}
	}
}
