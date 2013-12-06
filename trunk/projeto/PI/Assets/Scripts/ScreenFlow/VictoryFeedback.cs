using UnityEngine;
using System.Collections;

public class VictoryFeedback : MonoBehaviour {
	
    [SerializeField]
    private float _startY = 2.5f,
        _endY = 4,
        _speedY = 0.03f,
		_time = 2;
    private float? _y = null;
	private bool _stopped = false;
	
	void Start () {
		gameObject.transform.localScale = new Vector3(0,
			gameObject.transform.localScale.y,
			gameObject.transform.localScale.z);
	}
	
	void Update () {	
		transform.position = new Vector3(transform.position.x, 3.143483f, transform.position.y);
        
		if (_y != null)
		{
          	Show(ref _y);
		}		
		else if (PlayerStatus.hasGameOverHappend && !PlayerStatus.BadGameOver)
		{			
			gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.y * 2,
				gameObject.transform.localScale.y,
				gameObject.transform.localScale.z);
            _y = _startY;
		}
	}
	
    void Show(ref float? position)
    {		
        if (position > _endY)
		{
			if (!_stopped)
			{
				_stopped = true;
			}
			else if (Director.Instance.isRunning)
			{
				_time -= Time.deltaTime;
				if (_time < 0)
					Director.Instance.GameOver(true);
			}
		}
		
		if (_stopped)
			return;
				
        gameObject.transform.position =
            new Vector3(gameObject.transform.position.x,
                (float)position,
                gameObject.transform.position.z);
        position += _speedY;
    }		
}
