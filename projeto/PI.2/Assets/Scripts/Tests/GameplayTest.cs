using UnityEngine;
using System.Collections;
using PI.Backend;

public class GameplayTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Gameplay.Instance.Quests.QuestByID(2).MakeAvailable();
		//Gameplay.Instance.Quests.Start(2);
		//Gameplay.Instance.Quests.Complete(2);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Gameplay.Instance.Quests.QuestByID(2).isInSituation(Quest.Status.Done));
	}
}
