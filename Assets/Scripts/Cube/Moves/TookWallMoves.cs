using UnityEngine;
using System.Collections;

public class TookWallMoves : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Move(){

	}

	public void ManageEndMetronome()
	{
		CubeMainManager mainManager = GetComponent<CubeMainManager>();

		mainManager.rot += 90;
		transform.rotation = Quaternion.Euler(0, mainManager.rot, 0);
		mainManager.directionReference = new Vector3(mainManager.directionReference.z, mainManager.directionReference.y, -mainManager.directionReference.x);
	}
}
