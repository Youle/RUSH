using UnityEngine;
using System.Collections;

public class EndManager : MonoBehaviour {
	public AnimationCurve disappearCurve;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(float metronomeRatio)
	{
		float scale = 1 - disappearCurve.Evaluate(metronomeRatio);
		transform.localScale = new Vector3(scale, scale, scale);
		if(metronomeRatio > 0.9)
		{
			Destroy(gameObject);
		}
	}
}
