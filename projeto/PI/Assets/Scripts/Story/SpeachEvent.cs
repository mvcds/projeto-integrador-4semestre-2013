using UnityEngine;
using System.Collections;

public class SpeachEvent : MonoBehaviour {
    private GUIStyle _styleRight = new GUIStyle(),
        _styleLeft = new GUIStyle(),
        _styleEnd = new GUIStyle();
    private Texture2D _voidImage;
		
	public enum Trigger
	{
		PhaseBeginning,
		PhaseEnding
	}
    
    public Texture _background;

	[SerializeField] private int _current = 0;
	public SpeachItem[] pages;
    public Texture2D Right, Left, End;
    public Texture2D RightHover, LeftHover, EndHover;
	public Rect RightArrow, LeftArrow, EndArrow;	
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

    void SetStyle(ref GUIStyle s, Texture2D n, Texture2D h)
    {
        s.normal.background = n;
        s.hover.background = h;
        s.active.background = h;
    }
	
	void Update()
	{   
		if (!Run)
			return;

        SetStyle(ref _styleRight, Right, RightHover);
        SetStyle(ref _styleLeft, Left, LeftHover);
        SetStyle(ref _styleEnd, End, EndHover);

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
        Rect bg = CreateFixed(new Rect(0,0,100,100));
        bool canSkip = Director.Instance.canSkipDialog(On);
                
        if (_background != null)
            GUI.DrawTexture(bg, _background);

		if (_current > 0)
		{
            if (GUI.Button(left, _voidImage, _styleLeft))
				Backward();
		}
		
		if (_current < pages.Length - 1)
		{
            if (GUI.Button(right, _voidImage, _styleRight))
				Forward();
		}
		else if (pages.Length > 0)
		{
            canSkip = false;
            if (GUI.Button(right, _voidImage, _styleEnd))
				Action();
		}
        
        
        if (canSkip || Debug.isDebugBuild)
        {
            if (GUI.Button(skip, _voidImage, _styleEnd))
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
