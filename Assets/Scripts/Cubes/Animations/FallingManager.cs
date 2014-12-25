using UnityEngine;
using System.Collections;

public class FallingManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(float metronomeRatio, Vector3 positionReference)
	{
		transform.position = positionReference + Vector3.down * metronomeRatio;
	}
}
