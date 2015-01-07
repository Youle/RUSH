using UnityEngine;
using System.Collections;

public class ConveyorSlabManager : BelowManager {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Move(GameObject Cube)
	{
		Cube.GetComponent<ConveyorMoves>().Move(transform.forward);
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		Cube.GetComponent<BasicMoves>().EndMetronome();
	}
}
