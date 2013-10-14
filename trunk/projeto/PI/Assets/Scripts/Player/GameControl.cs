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
        MyBody.useGravity = (Director.Instance.isRunning);
        MyBody.isKinematic = !MyBody.useGravity;
    }

	void Update () 
    {
        if (Director.Instance.isRunning)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Director.Instance.Pause();
            if (Input.GetKeyDown(KeyCode.R))
                Director.Instance.ResetLevel();
        }
        else if (Director.Instance.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Director.Instance.Run();
        }
	}
}
