using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public Button[] buttons;	
	public Texture2D _bgMenu = null;
	[SerializeField]
    private Rect place_size = new Rect(0, 0, 100, 100);

    public bool Able
    {
        get;
        private set;
    }
    		
	void Update()
	{
        FixPosition();
	}

    protected virtual void FixPosition()
    {
        FixRect(ref place_size);
    }
	
    protected void FixRect(ref Rect r)
    {
        r.x = r.x.FixForHundred();
        r.y = r.y.FixForHundred();
        r.width = r.width.FixForHundred();
        r.height = r.height.FixForHundred();
    }

    protected Rect Fit(Rect r)
    {
        return new Rect(r.x.FitOnWidth(), r.y.FitOnHeight(),
                r.width.FitOnWidth(), r.height.FitOnHeight());
    }

	protected virtual bool canShow
	{
		get
		{
			return true;
		}
	}

	protected virtual void Show()
	{
		foreach(Button btn in buttons)
		{
            if (!canShow)
                return;

			if (btn == null)
				continue;
			
            if (!btn._revertShown)
			    btn.Show(Able);
            else
                btn.Show(!Able);
        }
	}
    	
	void OnGUI()
    {
        if (!canShow)
            return;

        ShowAtGUI();
	}

    protected virtual void ShowAtGUI()
    {
        GUI.depth = 0;

        if (_bgMenu != null)
        {
            Rect r = Fit(place_size);
            GUI.DrawTexture(r, _bgMenu);
        }

        Show();
    }

    public void SetAble(bool able = true)
    {
        Able = able;
    }

    void Start()
    {
        SetAble();
    }
}
