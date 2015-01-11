using UnityEngine;
using System.Collections;

public class StopSlabManager : BelowManager {
	private bool blocked;
	// Use this for initialization
	void Start () {
		blocked = false;
	}
	void Move(GameObject Cube)
	{
		if(blocked == false)
		{
			Cube.GetComponent<BasicMoves>().Move();
		}
	}
	void OnMetronomeEnd(GameObject Cube)
	{
		blocked = !blocked;
		Cube.GetComponent<BasicMoves>().EndMetronome();
	}
}
