using UnityEngine;
using System.Collections;

public class TurnSlabManager : BelowManager {
	
	void Move(GameObject Cube)
	{
		Cube.GetComponent<BasicMoves>().Move();
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		Cube.GetComponent<CubeMainManager>().directionReference = transform.forward;
		Cube.GetComponent<CubeMainManager>().rot = transform.eulerAngles.y + 90;
		Cube.GetComponent<BasicMoves>().EndMetronome();
	}
}
