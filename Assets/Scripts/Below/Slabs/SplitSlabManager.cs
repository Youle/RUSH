using UnityEngine;
using System.Collections;

public class SplitSlabManager : BelowManager {
	private bool turnRight;
	// Use this for initialization
	void Start () {
		turnRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Move(GameObject Cube){
		Cube.GetComponent<BasicMoves>().Move();
	}

	void OnMetronomeEnd(GameObject Cube)
	{
		float modifier = (turnRight == true) ? -1 : 1;
		Vector3 dir = Cube.GetComponent<CubeMainManager>().directionReference;
		Cube.GetComponent<CubeMainManager>().directionReference = new Vector3(dir.z * modifier, dir.y, dir.x * modifier);
		float rot = (dir == Vector3.forward) ? 0   * modifier :
					(dir == Vector3.right)   ? 90  * modifier :
					(dir == Vector3.back)    ? 180 * modifier :
											   270 * modifier ;
		Cube.GetComponent<CubeMainManager>().rot = rot;
		turnRight = !turnRight;
		Cube.GetComponent<BasicMoves>().EndMetronome();
	}
}
