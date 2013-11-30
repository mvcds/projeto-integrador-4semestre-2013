using UnityEngine;
using System.Collections;

public class UpArrow : MonoBehaviour {

    static private int time;

    [SerializeField]
    private bool _destructionByJumping = true,
        _destructionByTime = true;
    [SerializeField]
    private int _times = 3;
    [SerializeField]
    private float _startY = 2.5f,
        _endY = 4,
        _speedY = 0.05f;
    private float? _y = null;

	void Start () {
        time = _times - 1;
	}
	
	void Update () {
        if (_y != null)
        {
            Show(ref _y);

            if (Input.GetKey(KeyCode.UpArrow) && _destructionByJumping)
                End();
        }
	}

    void Show(ref float? position)
    {
        gameObject.transform.position =
            new Vector3(gameObject.transform.position.x,
                (float)position,
                gameObject.transform.position.z);
        position += _speedY;

        if (position > _endY)
        {
            if (_destructionByTime)
            {
                if (time-- <= 0)
                    End();
            }

            position = _startY;
        }
    }

    void OnBecameVisible()
    {
        if (_y == null)
            _y = _startY;
    }

    void OnBecameInvisible()
    {
        End();
    }

    void End()
    {
        Destroy(gameObject);
    }
}
