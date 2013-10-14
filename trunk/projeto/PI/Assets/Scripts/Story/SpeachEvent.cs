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
	[SerializeField] private Rect RightArrow, LeftArrow, EndArrow;	
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
         EndArrow = RightArrow;
         EndArrow.y = 0;
	}
	
	void Update()
	{
        
		if (!Run)
			return;

        FixForHundred(RightArrow);
        FixForHundred(LeftArrow);
        FixForHundred(EndArrow);
		
		if (pages[_current] != null)
			pages[_current].Show();
	}

    void FixForHundred(Rect r)
    {
        r.x = r.x.FixForHundred();
        r.y = r.y.FixForHundred();
        r.width = r.width.FixForHundred();
        r.height = r.height.FixForHundred();
    }

    Rect CreateFixed(Rect r)
    {
        return new Rect(r.x.FitOnWidth(), r.y.FitOnHeight(),
               r.width.FitOnWidth(), r.height.FitOnHeight());		
    }

	void OnGUI()
	{
		if (!Run)
			return;

        Rect left = CreateFixed(LeftArrow);
        Rect right = CreateFixed(RightArrow);
        Rect skip = CreateFixed(EndArrow);
        bool canSkip = Director.Instance.canSkipDialog(On);

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
            canSkip = false;
			if (GUI.Button(right, End))
				Action();
		}
        
        
        if (canSkip)
        {
            if (GUI.Button(skip, End))
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
        Destroy(this);
    }
}
