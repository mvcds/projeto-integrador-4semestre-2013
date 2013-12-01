using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HUD))]
public class Breath : MonoBehaviour {

    [SerializeField]
    private Texture2D _full,
        _reserve,
        _background;
    [SerializeField]
    private Rect placeAndSize = new Rect(0, 0, 100, 100),
        _adjust = new Rect(0, 0, 0, 0);
    [SerializeField]
    float _red = 1;

    private Texture2D Bar
    {
        get
        {
            if (MainScript.folego >= _red)
                return _full;
            return _reserve;
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Fix();
	}
    
    protected void Fix()
    {
        placeAndSize.x = placeAndSize.x.FixForHundred();
        placeAndSize.y = placeAndSize.y.FixForHundred();
        placeAndSize.width = placeAndSize.width.FixForHundred();
        placeAndSize.height = placeAndSize.height.FixForHundred();
    }

    void OnGUI()
    {
        if (Director.Instance.isRunning)
            Draw();
    }

    protected virtual void Draw()
    {
        Rect bg, r, a;
        r = bg = placeAndSize;
        
        bg = new Rect(bg.x.FitOnWidth(), bg.y.FitOnHeight(),
                 bg.width.FitOnWidth(), bg.height.FitOnHeight());
        a = new Rect(_adjust.x.FitOnWidthF(), _adjust.y.FitOnHeightF(),
                 _adjust.width.FitOnWidthF(), _adjust.height.FitOnHeightF());

        r = new Rect((r.x + a.x).FitOnWidthF(), 
                (r.y + a.y).FitOnHeightF(),
                (r.width + a.width).FitOnWidthF() * (MainScript.folego / MainScript.Maxfolego),
                (r.height + a.height).FitOnHeightF());

        GUI.DrawTexture(r, Bar);
        GUI.DrawTexture(bg, _background);
    }
}
