using UnityEngine;
using System.Collections;

public class SplitManager : MonoBehaviour {
	private string _direction = "left";
	// Use this for initialization
	void Start () {
		_direction = "right";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string whichSide()
	{
		_direction = (_direction == "turnRight") ? "turnLeft" : "turnRight";
		return _direction;
	}
}
