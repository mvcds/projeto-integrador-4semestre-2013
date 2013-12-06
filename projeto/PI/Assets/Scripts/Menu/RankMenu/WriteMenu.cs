using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WriteMenu : Menu {

    List<btnLetra> botoes = new List<btnLetra>();
    public const int A = 65,
        LETTERS = 26,
        EXTRA = 2;
    [SerializeField]
    private Rect firstButtonPlaceSize = new Rect();
    [SerializeField]
    private int columns = 4;
    [SerializeField]
    private float xDistance = 0.5f,
        yDistance = 0.5f;
    public Texture2D actived,
                    inactived,
                    hover;
	
	public string levelName;
	
	private Texture duckIcon;
	private Texture distanceIcon;
	private Texture continuar;

    protected override bool canShow
    {
        get
        {
            return Director.Instance.isWriting;
        }
    }

    GUIStyle MyFont
    {
        get
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.normal.textColor = Color.black;
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = 18;

            return myStyle;
        }
    }

    void Start()
    {
        SetAble();

        btnLetra.ResetName();
        buttons = new Button[LETTERS + EXTRA];

        for (int i = 0; i < LETTERS; i++)
            CreateLetterButton(i, (char)(i + A));
        CreateLetterButton(LETTERS, btnLetra.ERASE);
		
		duckIcon = (Texture)Resources.Load("Images/Menu/game-over/final_bom/patinho");
		distanceIcon = (Texture)Resources.Load("Images/Menu/game-over/final_bom/natacao");
		continuar = (Texture)Resources.Load("Images/Menu/ranking/btn_generico");
    }
    
    void CreateLetterButton(int i, char letter)
    {
        GameObject newButton = new GameObject(letter.ToString());
        newButton.AddComponent<btnLetra>();

        buttons[i] = newButton.GetComponent<btnLetra>();
        buttons[i].transform.parent = transform;
        buttons[i].actived = actived;
        buttons[i].inactived = inactived;
        buttons[i].hover = hover;
    }

    void Update()
    {
        FixPosition();
        PutButtonsInPosition();
    }

    void PutButtonsInPosition()
    {
        int l = 0;
        int rows = (LETTERS / columns) + 1;
        for (int r = 0; r < rows; r++)
        {
            if (l == buttons.Length - EXTRA)
                break;
            for (int col = 0; col < columns; col++)
            {
                try
                {
                    if (buttons[l].GetType() != typeof(btnLetra))
                        continue;

                    buttons[l].place_size.x = firstButtonPlaceSize.x + (buttons[l].place_size.width + xDistance) * col;
                    buttons[l].place_size.y = firstButtonPlaceSize.y + (buttons[l].place_size.height + yDistance) * r;

                    buttons[l].place_size.width = firstButtonPlaceSize.width;
                    buttons[l].place_size.height = firstButtonPlaceSize.height;
                }
                catch
                {
                    break;
                }
                l++;
            }
        }
        l--;
        buttons[l].place_size.x += buttons[l].place_size.width + xDistance;
    }
	
	protected override void ShowAtGUI ()
	{
		base.ShowAtGUI ();
		
		//GUI.skin.GetStyle("label").normal.textColor = Color.black;
		//GUI.skin.GetStyle("label").fontSize = 80;
		
		GUIStyle myStyle = new GUIStyle();
            //myStyle.font = font;
            myStyle.normal.textColor = Color.black;
            myStyle.alignment = TextAnchor.MiddleLeft;
            myStyle.fontSize = 40;
		
		// Duck
		drawImage(Screen.width * 0.23f, Screen.height * 0.7f, duckIcon);
		GUI.Label(new Rect(Screen.width * 0.33f, Screen.height * 0.7f, 120, 60), "" + Director.Instance.GameRank.Ducks, myStyle);
		
		// Distance
		drawImage(Screen.width * 0.50f, Screen.height * 0.7f, distanceIcon);
		GUI.Label(new Rect(Screen.width * 0.63f, Screen.height * 0.7f, 120, 60), "" + Director.Instance.GameRank.Distance, myStyle);
		
		GUI.Label(new Rect(Screen.width * 0.67f, Screen.height * 0.4f, 160, 60), levelName, myStyle);
	
		GUI.Button(new Rect(Screen.width * 0.35f, Screen.height * 0.165f, continuar.width, continuar.height), continuar, myStyle);
		
		//GUI.skin.GetStyle("label").normal.textColor = Color.white;
	}
	
	void drawImage(float x, float y, Texture texture){
		GUI.DrawTexture (new Rect (x, y, texture.width, texture.height), texture);
	}

    protected override void FixPosition()
    {
        base.FixPosition();
        FixRect(ref firstButtonPlaceSize);
    }
}
