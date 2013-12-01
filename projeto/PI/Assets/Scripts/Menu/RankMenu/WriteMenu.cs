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

    protected override bool canShow
    {
        get
        {
            return base.canShow;
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

    protected override void FixPosition()
    {
        base.FixPosition();
        FixRect(ref firstButtonPlaceSize);
    }
}
