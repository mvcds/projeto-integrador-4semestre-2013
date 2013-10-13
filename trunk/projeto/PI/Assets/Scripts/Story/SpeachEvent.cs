using UnityEngine;
using System.Collections;

public class SpeachEvent : MonoBehaviour {
		
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
            if (!Director.Instance.canShowDialog)
                return false;

			switch(On)
			{
				case Trigger.PhaseBeginning:
                    return Director.Instance.isStarting;
                case Trigger.PhaseEnding:
                    return Director.Instance.isVictory;
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
				
		RightArrow.x = RightArrow.x.FixForHundred();
		RightArrow.y = RightArrow.y.FixForHundred();			
		RightArrow.width = RightArrow.width.FixForHundred();
		RightArrow.height = RightArrow.height.FixForHundred();
		
		LeftArrow.x = LeftArrow.x.FixForHundred();
		LeftArrow.y = LeftArrow.y.FixForHundred();			
		LeftArrow.width = LeftArrow.width.FixForHundred();
        LeftArrow.height = LeftArrow.height.FixForHundred();
		
		if (pages[_current] != null)
			pages[_current].Show();
	}
	
	void OnGUI()
	{
		if (!Run)
			return;
		        
		Rect left = new Rect(LeftArrow.x.FitOnWidth(), LeftArrow.y.FitOnHeight(),
			LeftArrow.width.FitOnWidth(), LeftArrow.height.FitOnHeight());		
		Rect right = new Rect(RightArrow.x.FitOnWidth(), RightArrow.y.FitOnHeight(),
			RightArrow.width.FitOnWidth(), RightArrow.height.FitOnHeight());
		
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

    public virtual void Action()
    {
        Director.Instance.Run();
    }
}
