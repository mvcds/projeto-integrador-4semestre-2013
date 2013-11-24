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

    void Start()
    {
        Validate();
        missionMessageTime = messageTime * conditions.Length;
    }

    void Update()
    {
        Validate();
        FixPosition();
        
        if (conditions.Where(p => !p.hasWon).Count() == 0)
            Director.Instance.GameOver(true);
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
