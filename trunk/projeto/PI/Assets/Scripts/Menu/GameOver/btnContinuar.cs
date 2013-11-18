using UnityEngine;
using System.Collections;

public class btnContinuar : Button {

    public string next = "2-Menu";
    public bool reset;

	protected override void Action ()
	{
        if (Debug.isDebugBuild && reset)
            Director.Instance.ResetLevel();
        else
        {
            //*
            try
            {
                if (string.IsNullOrEmpty(next))
                    throw new System.Exception();

                Director.Instance.LoadLevel(next);
            }
            catch
            {
                Director.Instance.LoadLevel("2-Menu");
            }
            //*/
        }
    }
	
}
