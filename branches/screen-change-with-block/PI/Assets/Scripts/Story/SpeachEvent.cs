using UnityEngine;
using System.Collections;

public abstract class SpeachEvent : MonoBehaviour {
		
	public enum Trigger
	{
		PhaseBeginning,
		PhaseEnding
	}
	
	[SerializeField] private int _current = 0;
	public SpeachItem[] pages;
	public  Texture Right, Left, End;
	[SerializeField] private Rect RightArrow, LeftArrow;	
	//[SerializeField] private bool _show = true;
	public Trigger On;	
	
	private bool Run
	{
		get
		{
			if (!GameAsApplication.hasBegun)
				return false;
			
			switch(On)
			{
				case Trigger.PhaseBeginning:
					return GameController.isStarting;
				case Trigger.PhaseEnding:
					break;
			}
			
			return false;
		}
	}
	
	void Start()
	{
		 LeftArrow = new Rect(0,90,50,10);
		 RightArrow = new Rect(50,90,50,10);
	}
	
	void Update()
	{
		if (!Run)
			return;
				
		RightArrow.x = ScreenUtil.FixForHundred(RightArrow.x);
		RightArrow.y = ScreenUtil.FixForHundred(RightArrow.y);			
		RightArrow.width = ScreenUtil.FixForHundred(RightArrow.width);
		RightArrow.height = ScreenUtil.FixForHundred(RightArrow.height);
		
		LeftArrow.x = ScreenUtil.FixForHundred(LeftArrow.x);
		LeftArrow.y = ScreenUtil.FixForHundred(LeftArrow.y);			
		LeftArrow.width = ScreenUtil.FixForHundred(LeftArrow.width);
		LeftArrow.height = ScreenUtil.FixForHundred(LeftArrow.height);
		
		if (pages[_current] != null)
			pages[_current].Show();
	}
	
	void OnGUI()
	{
		if (!Run)
			return;
		
		Rect left = new Rect(ScreenUtil.FitOnWidth(LeftArrow.x), ScreenUtil.FitOnHeight(LeftArrow.y),
			ScreenUtil.FitOnWidth(LeftArrow.width), ScreenUtil.FitOnHeight(LeftArrow.height));		
		Rect right = new Rect(ScreenUtil.FitOnWidth(RightArrow.x), ScreenUtil.FitOnHeight(RightArrow.y),
			ScreenUtil.FitOnWidth(RightArrow.width), ScreenUtil.FitOnHeight(RightArrow.height));
		
		if (_current > 0)
		{
			if (GUI.Button(left, Left))
				Backward();
		}
		
		if (_current < pages.Length - 1)
		{
			if (GUI.Button(right, Right))
				Forward();
		}
		else if (pages.Length > 0)
		{
			if (GUI.Button(right, End))
				Action();
		}
	}
	
	public void Forward()
	{
		_current++;		
	}
	
	public void Backward()
	{
		_current--;
	}
	
	public abstract void Action();	
}
