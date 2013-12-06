using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class Victory : MonoBehaviour {

    public Font font;

    public Rect LevelPosition, ObjectivePosition;
    public bool foreverMessage;

    public static string LevelObjective;

    public WinningCondition[] conditions;
    public float messageTime = 5;
    private float missionMessageTime;
    public int fase;
	
	private Texture powerUpFill;
	private Texture powerUpBarraFolego;
	
	private int duckMissionIndex = 0;

    void Start()
    {
        Validate();
        missionMessageTime = messageTime * conditions.Length;
		
		powerUpFill = (Texture)Resources.Load("Images/HUD/BarraObjetivo");
		powerUpBarraFolego = (Texture)Resources.Load("Images/HUD/BordaObjetivo");
		
		for (int i = 0; i < conditions.Length; i++)
		{
			if (conditions[i].unit == WinningCondition.Unit.Duck)
			{
				duckMissionIndex = i;
				break;
			}
		}
    }

    void Update()
    {
        Validate();
        FixPosition();

        if (!Director.Instance.isRunning)
            return;

        if (conditions.Where(p => !p.hasWon).Count() == 0)
			PlayerStatus.EndGame(false);
    }

    void Validate()
    {
        if (conditions.Length <= 0)
            throw new Exception("No winning condition");
    }

    void FixPosition()
    {
        LevelPosition.x = ScreenUtil.FixForHundred(LevelPosition.x, true);
        LevelPosition.y = ScreenUtil.FixForHundred(LevelPosition.y, true);
        LevelPosition.width = ScreenUtil.FixForHundred(LevelPosition.width);
        LevelPosition.height = ScreenUtil.FixForHundred(LevelPosition.height);

        ObjectivePosition.x = ScreenUtil.FixForHundred(ObjectivePosition.x, true);
        ObjectivePosition.y = ScreenUtil.FixForHundred(ObjectivePosition.y, true);
        ObjectivePosition.width = ScreenUtil.FixForHundred(ObjectivePosition.width);
        ObjectivePosition.height = ScreenUtil.FixForHundred(ObjectivePosition.height);
    }

    void OnGUI()
    {
        if (!Director.Instance.isRunning)
            return;

        if (!(Debug.isDebugBuild && foreverMessage))
            missionMessageTime -= Time.deltaTime;

        //* Label Inicial
        if (missionMessageTime > 0)
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.font = font;
            myStyle.fontSize = 27;
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.normal.textColor = Color.white;
            myStyle.border.bottom = 1;

            Rect lp = new Rect(ScreenUtil.FitOnWidth(LevelPosition.x), ScreenUtil.FitOnHeight(LevelPosition.y),
                ScreenUtil.FitOnWidth(LevelPosition.width), ScreenUtil.FitOnHeight(LevelPosition.height));
            GUI.Label(lp, "FASE " + fase, myStyle);

            myStyle.fontSize = 23;
            Rect op = new Rect(ScreenUtil.FitOnWidth(ObjectivePosition.x), ScreenUtil.FitOnHeight(ObjectivePosition.y),
                ScreenUtil.FitOnWidth(ObjectivePosition.width), ScreenUtil.FitOnHeight(ObjectivePosition.height));
            GUI.Label(op, Objective, myStyle); 
		}
		//*/
		float altura = ((Director.Instance.GameRank.Ducks / conditions[duckMissionIndex].value) * powerUpFill.height) * 0.90f;
		GUI.DrawTexture (new Rect (Screen.width * 0.042f, Screen.height * 0.662f + 5 - altura, powerUpFill.width + 4.5f, altura), powerUpFill);
		drawImage(Screen.width * 0.03f, Screen.height * 0.3f, powerUpBarraFolego);
		//conditions[0].va
    }

	void drawImage(float x, float y, Texture texture){
		GUI.DrawTexture (new Rect (x, y, texture.width, texture.height), texture);
	}
	
    private string Objective
    {
        get
        {
            string obj = "";

            foreach (WinningCondition win in conditions)
                TreatString(ref obj, win.msg);

            LevelObjective = obj;

            return LevelObjective;
        }
    }


    void TreatString(ref string str, string appended)
    {
        if (!string.IsNullOrEmpty(str))
            str += "\n";

        str += appended;
    }
}
