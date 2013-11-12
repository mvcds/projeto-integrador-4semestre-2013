using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	
	
    private Rigidbody MyBody
    {
        get
        {
            return gameObject.rigidbody;
        }
    }

    void FixedUpdate()
    {
        if (Director.Instance.isPaused)
        {
            MyBody.isKinematic = true;
            MyBody.useGravity = false;
        }
        else
        {
            MyBody.isKinematic = !true;
            MyBody.useGravity = !false;
        }
    }

	void Update () {
        if (Director.Instance.isRunning)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
                Director.Instance.Pause();
        }
        else if (Director.Instance.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
                Director.Instance.Run();
        }
		
		if (Debug.isDebugBuild)
		{
			if (Input.GetKeyDown(KeyCode.R))
				Director.Instance.ResetLevel();
			else if (Input.GetKeyDown(KeyCode.E))
				Director.Instance.GameOver(false);
			else if (Input.GetKeyDown(KeyCode.W))
				Director.Instance.GameOver(true);
		}
	}
}