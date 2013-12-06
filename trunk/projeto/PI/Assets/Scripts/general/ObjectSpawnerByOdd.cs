using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObjectSpawnerByOdd : MonoBehaviour {
	
	public bool testOdd = false;
    private bool oddTested = false;
	private static Dictionary<string, int> dicObj;
	public GameObject[] SpawnableObejcts;	
	public float[] Odds;
	
	[SerializeField]	
	private float OddTotal;
	
	[SerializeField]
	private float OddToHundred;	
	
	//[SerializeField]
	private float[] proportionalOdds;
	
	//[SerializeField]
	/// <summary>
	/// It's not showing exactly what it was supposed to, but it's working
	/// </summary>
	private GameObject[] cleanObjects;

    void Start()
    {
        dicObj = new Dictionary<string, int>();
    }

	void Update ()
	{
		
		if (PlayerStatus.hasGameOverHappend)
			return;
			
		//*User helper
		OddTotal = SumUp(Odds);
		OddToHundred = 100 - OddTotal;
		//*/
		
		try
		{
			/*if (OddTotal < 0 || OddTotal > 100)
				throw new System.Exception("Odds must be between 0 and 100.");*/
			
			if (SpawnableObejcts.Length < Odds.Length)
				throw new System.Exception("Each spawnable object must have an odd. " +
					"Add " + (Odds.Length - SpawnableObejcts.Length) + " objects to keep swimming.");		
		}
		catch (System.Exception e)
		{
			Application.Quit();
			throw e;
		}
		
		proportionalOdds = NormalizeOdds(Odds);	
		
		if (testOdd)
		{
            if (Input.GetKeyDown(KeyCode.P) || ShowOdd)
                CheckOdd();
		}
	}

    private bool ShowOdd
    {
        get
        {
            return (Director.Instance.isGameOver || Director.Instance.isEnding) && !oddTested;
        }
    }
	
	private void CheckOdd()
	{
		if (!Debug.isDebugBuild)
			return;
			
		float total = 0;
		foreach(string n in dicObj.Keys)
			total += dicObj[n];
		
		foreach(string n in dicObj.Keys)
		{
			Debug.Log("S:" + n + " - " + dicObj[n] + " - " + ((float)dicObj[n]/total).ToString() + "%");
		}

        oddTested = true;
		throw new System.Exception();
	}
	
	/// <summary>
	/// Adds all the floats inside the vector 
	/// and normalize it (values between 0 and 100)
	/// </summary>
	private float SumUp(float[] v)
	{
		float me = 0;
		
		for (int i = 0; i < v.Length; i++)
		{
			if (v[i] < 0)
				v[i] = 0;
			else if (v[i] > 100)
				v[i] = 100;
			
			me += v[i];
		}
		
		return me;
	}	
	
	/// <summary>
	/// Gets the normalized odds (it always sum up 100[%]).
	/// </summary>
	/// <value>
	/// The normalized odds.
	/// </value>
	private float[] NormalizeOdds(float[] v)
	{
		List<float> me = new List<float>();
		
		//*Copy the user inputed odds and sum it up
		for(int i = 0; i < v.Length; i++)
		{
			me.Add(v[i]);
		}			
		float total = SumUp(me.ToArray());
		//*/
					
		
		//*Normalize
		for(int i = 0; i < me.Count; i++)
		{
			me[i] = (me[i] * 100/total);
		}
		//*/
		
		return me.ToArray();
	}
	
	private float MinOdd(float[] v)
	{
		try
		{
			float min = v[0];
			
			foreach(float f in v)
			{
				if (f < min)
					min = f;
			}
			return min;
		}
		catch
		{}
		return 0;		
	}
	
	private float MaxOdd(float[] v)
	{
		try
		{
			float max = v[0];
			
			foreach(float f in v)
			{
				if (f > max)
					max = f;
			}
			
			return max;
		}
		catch
		{}
		return 0;
	}
	
	public GameObject getObject()
	{	
		return getObject(SpawnableObejcts, NormalizeOdds(Odds));
	}
	
	private GameObject getObject(GameObject[] spawnables, float[] odd)
	{		
		float min = MinOdd(odd);
		
		//*Take off all the 0 odds
		if (min == 0)
		{				
			List<float> realOdd = new List<float>();
			List<GameObject> realSpawnables = new List<GameObject>();
			
			for (int i = 0; i < odd.Length; i++)
			{
				if (odd[i] > 0)
				{		
					realSpawnables.Add(spawnables[i]);
					realOdd.Add(odd[i]);
				}
			}
			
			cleanObjects = realSpawnables.ToArray();
			GameObject obj = getObject(cleanObjects, NormalizeOdds(realOdd.ToArray()));
			
			if (cleanObjects.Length > 0)
				return obj;
			
			return null;
		}
		//*/
		cleanObjects = spawnables;	
		
		//TODO: organize list by odd?
		
		float rand = Random.value * SumUp(odd);
		int r = -1;
		
		for(int i = 0; i < odd.Length; i++)
		{
			if (rand < odd[i])
			{
				r = i;
				break;
			}
			else
				rand -= odd[i];
		}
		
		if (r < 0)
			return null;
				
		GameObject obj1 = (GameObject)spawnables[r];
		return obj1;
	}
	
	public void FeedDictionary(GameObject obj)
	{
		if (!dicObj.ContainsKey(obj.name))
			dicObj.Add(obj.name, 1);
		else
			dicObj[obj.name]++;
	}
}
